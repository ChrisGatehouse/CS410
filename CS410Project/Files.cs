using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS410Project
{
        //A folder is a type of file that also contains more files 
        //This object represents folders on the server
        public class FolderObj : FileObj
        {
            public FolderObj(string name)
                : base(name)
            {
                subdirectory = new List<FileObj>();
                this.parentDir = new FolderObj("..");
            }
            public FolderObj(string permissions, string owner, string group, UInt64 size, string dateCreated, string name, FolderObj parentDir)
                : base(permissions, owner, group, size, dateCreated, name)
            {
                fileinfo.directory = true;
                subdirectory = new List<FileObj>();
                this.parentDir = parentDir;
            }
            public FolderObj(string name, FolderObj parentDir)
                : base(name)
            {
                subdirectory = new List<FileObj>();
                this.parentDir = parentDir;
            }
            public void AddToSubDirectory(Client client, List<string> newFiles)
            {
                //Hold result of the subdirectory
                bool result;
                if (newFiles.Count == 0)
                {
                    return;
                }
                List<FileInfo> fileData = parseFileInfo(newFiles);
                //Figure out which files are folders/files
                for (int i = 0; i < fileData.Count; i++)
                {
                    result = fileData[i].directory;
                    /*If result is false, then the FTP gave an error
                    *when it was treated like a folder so we know its a file.*/
                    if (!result)
                    {
                        subdirectory.Add(new FileObj(fileData[i].permissions, fileData[i].owner, fileData[i].group, fileData[i].size, fileData[i].dateCreated, fileData[i].name));
                    }
                    else
                    {
                        subdirectory.Add(new FolderObj(fileData[i].permissions, fileData[i].owner, fileData[i].group, fileData[i].size, fileData[i].dateCreated, fileData[i].name, this));
                    }
                }
            }
            public void AddToSubDirectory(Client client, string newFile)
            {
                //Hold result of the subdirectory
                bool result;
                if (newFile == null)
                {
                    return;
                }
                FileInfo fileData = parseFileInfo(newFile);
                result = fileData.directory;
                /*If result is false, then the FTP gave an error
                *when it was treated like a folder so we know its a file.*/
                if (!result)
                {
                    subdirectory.Add(new FileObj(fileData.permissions, fileData.owner, fileData.group, fileData.size, fileData.dateCreated, fileData.name));
                }
                else
                {
                    subdirectory.Add(new FolderObj(fileData.permissions, fileData.owner, fileData.group, fileData.size, fileData.dateCreated, fileData.name, this));
                }
            }
            public List<FileObj> subdirectory;
            //Folders need to remember their parents ;_;
            //By default its the root directory
            public FolderObj parentDir { set; get; }
        }
        //An object to represent a file on the server
        public class FileObj
        {
            public FileObj() { }
            public FileObj(string name) { fileinfo.name = name; }
            public FileObj(string permissions, string owner, string group, UInt64 size, string dateCreated, string name)
            {
                fileinfo.permissions = permissions;
                fileinfo.directory = false;
                fileinfo.owner = owner;
                fileinfo.group = group;
                fileinfo.size = size;
                fileinfo.dateCreated = dateCreated;
                fileinfo.name = name;
            }
            public FileInfo fileinfo = new FileInfo();
            public struct FileInfo
            {
                //Mame of the file
                public string name { get; set; }
                //Permissions of the file
                public string permissions { get; set; }
                //Boolean flag 1 = is directory, 0 = is file
                public bool directory { get; set; }
                //user of the file
                public string group { get; set; }
                //owner of the file
                public string owner { get; set; }
                //The size of a file is saved in bytes
                public UInt64 size { get; set; }
                //date the file was created
                public string dateCreated { get; set; }

            };
           
            /*Parses through a string of unix/windows style directory detail
            *Then returns the struct that will be given to a Folder's addToSubdirectory method
            * Which will pass on the information and use it to determine whether or not
            * to make a folder object or a file object
            * NOTE: For now I will only deal with unix style directory listing
            *  Windows style will be implemented later once unix style is working*/
            public static FileInfo parseFileInfo(string fileData)
            {
                FileObj nonStatic = new FileObj();
                FileInfo output = new FileInfo();
                int style = nonStatic.fileDirectoryStyle(fileData);
                switch (style)
                {
                    case 0: //UNIX STYLE
                        output = nonStatic.parseUnixInfo(fileData);
                        break;
                    case 1: //WINDOWS STYLE
                        output = nonStatic.parseWindowsInfo(fileData);
                        break;
                    case 2: //UNKNOWN
                        //TODO: figure out what to do with this
                        break;
                }
                return output;
            }
            /*Parses through a list of unix/windows style directory details
             *Then returns the struct that will be given to a Folder's addToSubdirectory method
             * Which will pass on the information and use it to determine whether or not
             * to make a folder object or a file object
             * NOTE: For now I will only deal with unix style directory listing
             * Windows style will be implemented later once unix style is working*/
            public static List<FileInfo> parseFileInfo(List<string> fileData)
            {
                FileObj nonStatic = new FileObj();
                List<FileInfo> output = new List<FileInfo>();
                int style = nonStatic.fileDirectoryStyle(fileData[0]);
                switch (style)
                {
                    case 0: //UNIX STYLE
                        output = nonStatic.parseUnixInfo(fileData);
                        break;
                    case 1: //WINDOWS STYLE
                        output = nonStatic.parseWindowsInfo(fileData);
                        break;
                    case 2: //UNKNOWN
                        //TODO: figure out what to do with this
                        break;
                }
                return output;
            }
            //Parses unix style file information
            public List<FileInfo> parseUnixInfo(List<string> fileData)
            {
                List<FileInfo> output = new List<FileInfo>(new FileInfo[fileData.Count]);
                char[] delimiterchars = { ' ', '\t' }; //characters to skip past
                UInt64 sizeOutput; //used to store converted int value from string
                //Unix style directory details look like:
                //(File|Directory)(Permissions)[](hardlink *SKIP*)[](owner)[](group)[](size)[](month)[](day)[](year)[](name)
                for (int i = 0; i < fileData.Count; i++)
                {
                    bool first = true; // When parsing folder names checks if its not on the first word,if its not then adds a space before hand
                    var temp = output[i];
                    //Set directory flag 
                    if (fileData[i][0] == 'd')
                    {
                        temp.directory = true;
                    }
                    else
                    {
                        temp.directory = false;
                    }
                    string[] parsed = fileData[i].Split(delimiterchars, StringSplitOptions.RemoveEmptyEntries);
                    temp.permissions = parsed[0];
                    temp.owner = parsed[2];
                    temp.group = parsed[3];
                    if (UInt64.TryParse(parsed[4], out sizeOutput))
                    {
                        temp.size = sizeOutput;
                    }
                    else
                    {
                        //could not correctly parse int value so just assign the value 0
                        temp.size = 0;
                        Console.WriteLine("ERROR: Could not parse value of size");
                    }
                    temp.dateCreated = parsed[5] + " " + parsed[6] + " " + parsed[7];
                    foreach (string s in parsed.Skip(8))
                    {
                        if (!first)
                            temp.name += " ";
                        temp.name += s;
                        first = false;
                    }
                    output[i] = temp;
                }
                return output;
            }
            //Parses unix style file information
            public FileInfo parseUnixInfo(string fileData)
            {
                FileInfo output = new FileInfo();
                char[] delimiterchars = { ' ', '\t' }; //characters to skip past
                UInt64 sizeOutput; //used to store converted int value from string
                //Unix style directory details look like:
                //(File|Directory)(Permissions)[](hardlink *SKIP*)[](owner)[](group)[](size)[](month)[](day)[](year)[](name)
                bool first = true; // When parsing folder names checks if its not on the first word,if its not then adds a space before hand
                var temp = output;
                //Set directory flag 
                if (fileData[0] == 'd')
                {
                    temp.directory = true;
                }
                else
                {
                    temp.directory = false;
                }
                string[] parsed = fileData.Split(delimiterchars, StringSplitOptions.RemoveEmptyEntries);
                temp.permissions = parsed[0];
                temp.owner = parsed[2];
                temp.group = parsed[3];
                if (UInt64.TryParse(parsed[4], out sizeOutput))
                {
                    temp.size = sizeOutput;
                }
                else
                {
                    //could not correctly parse int value so just assign the value 0
                    temp.size = 0;
                    Console.WriteLine("ERROR: Could not parse value of size");
                }
                temp.dateCreated = parsed[5] + " " + parsed[6] + " " + parsed[7];
                foreach (string s in parsed.Skip(8))
                {
                    if (!first)
                        temp.name += " ";
                    temp.name += s;
                    first = false;
                }
                output = temp;
                return output;
            }
            //Parses Windows style file information
            public List<FileInfo> parseWindowsInfo(List<string> fileData)
            {
                List<FileInfo> output = new List<FileInfo>();
                return output;
            }
            //Parses Windows style file information
            public FileInfo parseWindowsInfo(string fileData)
            {
                FileInfo output = new FileInfo();
                return output;
            }
            //This will parse the start of the string to check
            //What style the directory is listed as
            //0 = Unix, 1 = Windows, 2 = Unknown
            public int fileDirectoryStyle(string fileData)
            {
                return 0; //TODO: Implement this later, for now just return Unix
            }
        }
}
