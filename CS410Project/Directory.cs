//Main Contributor: Mohammed Inoue

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS410Project
{
    /* Directory is the data structure to keep track of the directory tree in the FTP
     * This will be used to pull data such as location of a specific file
     * The data is organized like a tree to emulate the actual structure of how
     * directories are stored in an actual FTP
     */

    public class Directory
    {
        //Default Constructor
        public Directory()
        {
            /*by default, the parent directory of the starting folder is just null*/
            workingDir = new Folder("", null);
            head = workingDir;
        }

        //Grabs the contents of the directory of the workingDir
        //And creates file objects and folder objects when needed
        public void initializeDirectory(Client client)
        {
            //Check if connection is valid
            if (client.establishConnection())
            {
                List<string> directory = new List<string>();
                //Grab the list of files in the current directory
                directory = client.getCurrDetailedDirectory();
                directory.Sort();
                if (directory == null)
                {
                    Console.WriteLine("ERROR: invalid directory");
                    return;
                }
                workingDir.AddToSubDirectory(client, directory);
                workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
            }
        }


        public List<string> getDirectoryStructure()
        {
            List<string> output = new List<string>();
            for (int i = 0; i < workingDir.subdirectory.Count; i++)
            {
                output.Add(workingDir.subdirectory[i].fileinfo.name);
            }
            return output;
        }


        //This function changes the currDirectory of the Client
        //To a new one, and initializes new folders to be created
        public void changeToDirectory(Client client, string destination)
        {
            File newWorkingDir = workingDir.subdirectory.Find(x => x.fileinfo.name == destination);

            if (newWorkingDir == null)
            {
                //Get new folder information if the folder has not been added to the structure yet
                initializeDirectory(client);
            }
            else
            {
                if (client.isFile(destination))
                {
                    //Just move the working directory over to the new one
                    workingDir = (Folder)newWorkingDir;
                    //Append new directory name
                    if (!client.currDirectory.EndsWith("/"))
                    {
                        client.currDirectory += "/";
                    }
                    client.currDirectory += destination;
                    //checks existing structure so it doesn't have to keep rebuilding the structure from scratch if it was already built
                    updateConsistency(client);
                }
                else
                {
                    //Selected object is not a file
                    //As of right now, do nothing
                    //However we could return something so it decides to download the file or whatever
                }
            }
        }
        /*Update consistency is going to look through current version of its subdirectory
        * then compares the names of every file on the server's directory with what it has 
         * saved, If there is something new not added, it will add it, if thing has been removed
        * it will remove it*/
        //NOTE: This needs to be more throughly tested once we have upload/delete implemented
        public void updateConsistency(Client client)
        {
            List<string> currConsistency = client.getCurrDetailedDirectory();
            //If the directory we are going to is empty, we don't need to do anything, except clear.
            if (currConsistency.Count == 0)
            {
                workingDir.subdirectory.Clear();
                return;
            }

            List<File.FileInfo> fileData = File.parseFileInfo(currConsistency);
            //Sort the two list before performing the algorithm
            fileData.Sort((x, y) => x.name.CompareTo(y.name));
            workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
            int i = 0; //marker for currConsistency
            int j = 0; //marker for workingDir

            //The idea with this algorithm is to traverse both list simultaneously and 
            //find any disparities
            while (i < currConsistency.Count && j < workingDir.subdirectory.Count)
            {
                if (string.Compare(fileData[i].name, workingDir.subdirectory[j].fileinfo.name) == 0)
                {
                    //Item exist in both list, so skip it
                    i++;
                    j++;
                }
                else if (string.Compare(fileData[i].name, workingDir.subdirectory[j].fileinfo.name) > 0)
                {
                    //remove working directory's jth entry
                    workingDir.subdirectory.RemoveAt(j);
                    j++;
                }
                else if (string.Compare(fileData[i].name, workingDir.subdirectory[j].fileinfo.name) < 0)
                {
                    //Add to working directory
                    workingDir.AddToSubDirectory(client, currConsistency[i]);
                    workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                    i++;
                }
            }
            while (j < workingDir.subdirectory.Count)
            {
                //remove remaining items
                //remove working directory's jth entry
                workingDir.subdirectory.RemoveAt(j);
                j++;
            }
            while (i < fileData.Count)
            {
                //Add to working directory
                workingDir.AddToSubDirectory(client, currConsistency[i]);
                workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                i++;
            }
        }

        //This function changes the currDirectory of the Client 
        //To the parent directory, (if it exist)
        public void changeToParentDirectory(Client client)
        {
            if (workingDir.parentDir != null)
            {
                //Remove the directory from the currDirectory string
                //The length +2 is to account for the starting '/' and ending '/'
                client.currDirectory = client.currDirectory.Remove(client.currDirectory.Length - (workingDir.fileinfo.name.Length + 1), (workingDir.fileinfo.name.Length + 1));
                workingDir = workingDir.parentDir;
            }
            else
            {
                //TODO: fix edge cases with this
                if (client.isFile(".."))
                {
                    //Append new directory name, and then move
                    if (!client.currDirectory.EndsWith("/"))
                    {
                        client.currDirectory += "/";
                    }
                    client.currDirectory += "..";
                    //checks existing structure so it doesn't have to keep rebuilding the structure from scratch if it was already built
                    //save a temp of the current working directory
                    Folder temp = workingDir;
                    workingDir.subdirectory.Clear();
                    workingDir.subdirectory.Add(temp);
                    temp.parentDir = workingDir;
                    updateConsistency(client);

                }
                Console.WriteLine("ERROR: Current Directory has no Parent");
            }
        }

        //Used to refresh directory in case there was any changes
        public void refreshDirectory(Client client)
        {
            workingDir.subdirectory.Clear();
            initializeDirectory(client);
        }

        //A folder is a type of file that also contains more files 
        //This object represents folders on the server
        public class Folder : File
        {
            public Folder(string name)
                : base(name)
            {
                subdirectory = new List<File>();
                this.parentDir = new Folder("..");
            }
            public Folder(string permissions, string owner, string group, uint size, string dateCreated, string name, Folder parentDir)
                : base(permissions, owner, group, size, dateCreated, name)
            {
                subdirectory = new List<File>();
                this.parentDir = parentDir;
            }
            public Folder(string name, Folder parentDir)
                : base(name)
            {
                subdirectory = new List<File>();
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
                        subdirectory.Add(new File(fileData[i].permissions, fileData[i].owner, fileData[i].group, fileData[i].size, fileData[i].dateCreated, fileData[i].name));
                    }
                    else
                    {
                        subdirectory.Add(new Folder(fileData[i].permissions, fileData[i].owner, fileData[i].group, fileData[i].size, fileData[i].dateCreated, fileData[i].name, this));
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
                    subdirectory.Add(new File(fileData.permissions, fileData.owner, fileData.group, fileData.size, fileData.dateCreated, fileData.name));
                }
                else
                {
                    subdirectory.Add(new Folder(fileData.permissions, fileData.owner, fileData.group, fileData.size, fileData.dateCreated, fileData.name, this));
                }
            }
            public List<File> subdirectory;
            //Folders need to remember their parents ;_;
            //By default its the root directory
            public Folder parentDir { set; get; }
        }
        //An object to represent a file on the server
        public class File
        {
            public File() { }
            public File(string name) { fileinfo.name = name; }
            public File(string permissions, string owner, string group, uint size, string dateCreated, string name)
            {
                fileinfo.permissions = permissions;
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
                public uint size { get; set; }
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
                File nonStatic = new File();
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
                File nonStatic = new File();
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
                uint sizeOutput; //used to store converted int value from string
                //Unix style directory details look like:
                //(File|Directory)(Permissions)[](hardlink *SKIP*)[](owner)[](group)[](size)[](month)[](day)[](year)[](name)
                for (int i = 0; i < fileData.Count; i++)
                {
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
                    if (UInt32.TryParse(parsed[4], out sizeOutput))
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
                    temp.name = parsed[8];
                    output[i] = temp;
                }
                return output;
            }
            //Parses unix style file information
            public FileInfo parseUnixInfo(string fileData)
            {
                FileInfo output = new FileInfo();
                char[] delimiterchars = { ' ', '\t' }; //characters to skip past
                uint sizeOutput; //used to store converted int value from string
                //Unix style directory details look like:
                //(File|Directory)(Permissions)[](hardlink *SKIP*)[](owner)[](group)[](size)[](month)[](day)[](year)[](name)
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
                if (UInt32.TryParse(parsed[4], out sizeOutput))
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
                temp.name = parsed[8];
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

        //The current working directory
        public Folder workingDir;
        //The root of the tree keeps track of the top
        private Folder head;

    }
}
