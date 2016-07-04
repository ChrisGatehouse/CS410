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
            /*When first starting, the working Directory is the root
             * This means it has no parent*/
            workingDir = new Folder("", null);
            head = workingDir;
        }

        //Grabs the contents of the directory of the workingDir
        //And creates file objects and folder objects when needed
        public void initializeDirectory(Client client)
        {
            //Check if connection is valid
            if(client.establishConnection())
            {
                List<string> directory = new List<string>();
                //Store the current Directory of the client
                string currDir = client.currDirectory;
                //Grab the list of files in the current directory
                directory= client.getCurrDirectory();
                if (directory == null)
                {
                    Console.WriteLine("ERROR: invalid directory");
                    return;
                }

                //Hold result of the subdirectory
                bool result;
                //Figure out which files are folders/files
                for (int i = 0;i < directory.Count;i++)
                {
                    client.currDirectory += "/" + directory[i] + "/";
                    result = client.isFile();
                    /*If result is false, then the FTP gave an error
                    *when it was treated like a folder so we know its a file.*/
                    if (!result)
                    {
                        workingDir.subdirectory.Add(new File(directory[i]));
                    }
                    else
                    {
                        workingDir.subdirectory.Add(new Folder(directory[i],workingDir));
                    }
                    //Restore original current directory
                    client.currDirectory = currDir;
                }
            }
        }


        public List<string> getDirectoryStructure()
        {
            List<string> output = new List<string>();
            for (int i =0; i < workingDir.subdirectory.Count;i++)
            {
                output.Add(workingDir.subdirectory[i].name);
            }
            return output;
        }


        //This function changes the currDirectory of the Client
        //To a new one, and initializes new folders to be created
        public void changeToDirectory(Client client,string destination)
        {
            //Save old name incase of problems
            string oldDirectory = client.currDirectory;
            //Append new directory name
            client.currDirectory += "/" + destination + "/";
            File newWorkingDir = workingDir.subdirectory.Find(x => x.name == destination);

            if (newWorkingDir == null)
            {
                //Get new folder information if the folder has not been added to the structure yet
                initializeDirectory(client);
            }else
            {
                if (client.isFile())
                {
                    //Just move the working directory over to the new one
                    workingDir = (Folder)newWorkingDir;
                    //TODO: add check so it doesn't have to keep rebuilding the structure if it was already built
                    initializeDirectory(client);
                }
                else
                {
                    //Selected object is not a file
                    //As of right now, do nothing but just restore old name
                    //However we could return something so it decides to download the file or whatever
                    client.currDirectory = oldDirectory;
                }
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
                client.currDirectory = client.currDirectory.Remove(client.currDirectory.Length - (workingDir.name.Length + 2), (workingDir.name.Length + 2));
                workingDir = workingDir.parentDir;
            }
            else
            {
                Console.WriteLine("ERROR: Current Directory has no Parent");
            }
        }

        //A folder is a type of file that also contains more files 
        //This object represents folders on the server
        public class Folder : File
        {
            public Folder(string name): base(name)
            {
                subdirectory = new List<File>();
                this.parentDir = new Folder("");
            }
            public Folder(string name,Folder parentDir):base(name)
            {
                subdirectory = new List<File>();
                this.parentDir = parentDir;
            }

            public List<File> subdirectory;
            //Folders need to remember their parents ;_;
            //By default its the root directory
            public Folder parentDir {set; get;}
        }
        //An object to represent a file on the server
        public class File
        {
            public File(string name) {this.name = name;}
            public string name { set; get; }
        }

        //The current working directory
        public Folder workingDir;
        //The root of the tree keeps track of the top
        private Folder head;
       
    }
}
