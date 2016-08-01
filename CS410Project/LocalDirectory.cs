//Main Contributor: Mohammed Inoue

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS410Project
{
    public class LocalDirectory
    {
        private static readonly log4net.ILog Log = LogHelper.GetLogger();

        //Default Constructor
        public LocalDirectory()
        {
            path = new List<string>();
            parseLocalDirectory();
            /*by default, the parent directory of the starting folder is just null*/
            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            workingDir = new FolderObj("","","",0,dinfo.CreationTime.ToString(),dinfo.Name,getPath(), null);

            initializeDirectory();
        }

        void parseLocalDirectory()
        {
            string currDir = Directory.GetCurrentDirectory();
            char[] delimiterchars = { '/', '\\' };
            string[] parsed = currDir.Split(delimiterchars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in parsed)
            {
                path.Add(s);
            }
        }

        //Grabs the contents of the directory of the workingDir
        //And creates file objects and folder objects when needed
        public void initializeDirectory()
        {
            FileInfo currFile;
            DirectoryInfo currDirInfo;
            string currDir = Directory.GetCurrentDirectory();
            //Grab the list of files in the current directory
            foreach(string folders in Directory.GetDirectories(currDir))
            {
                currDirInfo = new DirectoryInfo(folders);
                workingDir.subdirectory.Add(new FolderObj(" ", "", "", 0, currDirInfo.CreationTime.ToString(), currDirInfo.Name, getPath(), workingDir));
            }
            foreach (string files in Directory.GetFiles(currDir))
            {
                currFile = new FileInfo(files);
                workingDir.subdirectory.Add(new FileObj(currFile.IsReadOnly.ToString(), "", "", (UInt64)currFile.Length, currFile.CreationTime.ToString(), currFile.Name, getPath()));
            }
            workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
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

        public List<string> searchLocalDirectory(string searchKey)
        {
            List<FileObj> visited = new List<FileObj>();
            List<string> output = new List<string>();
            Queue<FolderObj> queue = new Queue<FolderObj>();
            workingDir.setMarked(true);
            visited.Add(workingDir);
            queue.Enqueue(workingDir);
            FolderObj currDir;
            while(queue.Count != 0)
            {
                currDir = queue.Dequeue();
                for (int i = 0; i < currDir.subdirectory.Count; i++)
                {
                    if (currDir.subdirectory[i].fileinfo.name.ToLower() == searchKey.ToLower())
                    {
                        string temp = currDir.subdirectory[i].fileinfo.path;
                        temp += searchKey;
                        output.Add(temp);
                    }
                    if (currDir.subdirectory[i].fileinfo.directory && !currDir.subdirectory[i].getMarked())
                    {
                        currDir.subdirectory[i].setMarked(true);
                        visited.Add((FolderObj)currDir.subdirectory[i]);
                        queue.Enqueue((FolderObj)currDir.subdirectory[i]);
                    }
                }
            }
            for(int i = 0; i < visited.Count; i++)
            {
                visited[i].setMarked(false);
            }
            return output;
        }


        //This function changes the currDirectory of the Client
        //To a new one, and initializes new folders to be created
        public bool changeToDirectory(string destination)
        {
            FileObj newWorkingDir = workingDir.subdirectory.Find(x => x.fileinfo.name == destination);

            if (newWorkingDir == null)
            {
                //Get new folder information if the folder has not been added to the structure yet
                
                return true;
            }
            else
            {
                if (newWorkingDir.fileinfo.directory)
                {
                    //Just move the working directory over to the new one
                    workingDir = (FolderObj)newWorkingDir;
                    //Append new directory name
                    path.Add(destination);
                    //checks existing structure so it doesn't have to keep rebuilding the structure from scratch if it was already built
                    updateConsistency();
                    return true;
                }
                else
                {
                    //Selected object is not a folder
                    //As of right now, do nothing
                    //However we could return something so it decides to download the file or whatever
                    return false;
                }
            }
        }

        //Creates a working path to use with the Directory library of C# by inserting \ into the strings between each 
        //element of path
        private string getPath()
        {
            string output = "";
            foreach (string s in path)
            {
                output += s;
                output += '/';
            }
            return output;
        }

        /*Update consistency is going to look through current version of its subdirectory
        * then compares the names of every file on the server's directory with what it has 
         * saved, If there is something new not added, it will add it, if thing has been removed
        * it will remove it*/
        //NOTE: This needs to be more throughly tested once we have upload/delete implemented
        public void updateConsistency()
        {

            List<FileObj> fileData = new List<FileObj>();
            FileInfo currFile;
            DirectoryInfo currDir;
            //create fileData for current local directory
            string currWorkingDir = getPath();

            foreach (string folders in Directory.GetDirectories(getPath()))
            {
                currDir = new DirectoryInfo(folders);
                fileData.Add(new FolderObj(" ", "", "", 0, currDir.CreationTime.ToString(), currDir.Name, getPath(), null));
            }
            foreach (string files in Directory.GetFiles(getPath()))
            {
                currFile = new FileInfo(files);
                fileData.Add(new FileObj(currFile.IsReadOnly.ToString(), "", "", (UInt64)currFile.Length, currFile.CreationTime.ToString(), currFile.Name, getPath()));
            }

            //If the directory we are going to is empty, we don't need to do anything, except clear.
            if (fileData == null)
            {
                workingDir.subdirectory.Clear();
                return;
            }
            if (fileData.Count == 0)
            {
                workingDir.subdirectory.Clear();
                return;
            }
            //Sort the two list before performing the algorithm
            fileData.OrderBy(x => x.fileinfo.name);
            workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
            int i = 0; //marker for currConsistency
            int j = 0; //marker for workingDir

            //The idea with this algorithm is to traverse both list simultaneously and 
            //find any disparities
            while (i < fileData.Count && j < workingDir.subdirectory.Count)
            {
                if (string.Compare(fileData[i].fileinfo.name, workingDir.subdirectory[j].fileinfo.name) == 0)
                {
                    //Item exist in both list, so skip it
                    i++;
                    j++;
                }
                else if (string.Compare(fileData[i].fileinfo.name, workingDir.subdirectory[j].fileinfo.name) > 0)
                {
                    //remove working directory's jth entry
                    workingDir.subdirectory.RemoveAt(j);
                    j++;
                }
                else if (string.Compare(fileData[i].fileinfo.name, workingDir.subdirectory[j].fileinfo.name) < 0)
                {
                    //Add to working directory
                    if (fileData[i].fileinfo.directory)
                    {
                        workingDir.subdirectory.Add(new FolderObj(fileData[i].fileinfo.permissions, "", "", fileData[i].fileinfo.size, fileData[i].fileinfo.dateCreated, fileData[i].fileinfo.name, getPath(), workingDir));
                    }
                    else
                    {
                        workingDir.subdirectory.Add(new FileObj(fileData[i].fileinfo.permissions, "", "", fileData[i].fileinfo.size, fileData[i].fileinfo.dateCreated, fileData[i].fileinfo.name, getPath()));
                    }
                    workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                    j++;
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
                if (fileData[i].fileinfo.directory)
                {
                    workingDir.subdirectory.Add(new FolderObj(fileData[i].fileinfo.permissions, "", "", fileData[i].fileinfo.size, fileData[i].fileinfo.dateCreated, fileData[i].fileinfo.name, getPath(), workingDir));
                }
                else
                {
                    workingDir.subdirectory.Add(new FileObj(fileData[i].fileinfo.permissions, "", "", fileData[i].fileinfo.size, fileData[i].fileinfo.dateCreated, fileData[i].fileinfo.name, getPath()));
                }
                workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                i++;
            }
        }

        //To the parent directory, (if it exist)
        public void changeToParentDirectory()
        {
            if (workingDir.parentDir != null)
            {
                //Remove the directory from the currDirectory string
                //The length +2 is to account for the starting '/' and ending '/'
                path.RemoveAt(path.Count - 1);
                workingDir = workingDir.parentDir;
            }
            else
            {
                //check if parent exist
                DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "/../");

                if (dinfo.Exists)
                {

                    //remove at end
                    if (path.Count > 1)
                    path.RemoveAt(path.Count - 1);

                    //checks existing structure so it doesn't have to keep rebuilding the structure from scratch if it was already built
                    //save a temp of the current working directory

                    FolderObj parent = new FolderObj("", "", "", 0, dinfo.CreationTime.ToString(), dinfo.Name, getPath(), null);
                    workingDir.parentDir = parent;
                    parent.subdirectory.Add(workingDir);
                    workingDir = workingDir.parentDir;
                    updateConsistency();

                }
                else
                {
                    Console.WriteLine("ERROR: Current Directory has no Parent");
                }
            }
        }

        //Used to refresh directory in case there was any changes
        public void refreshDirectory()
        {
            updateConsistency();
        }

        //The current working directory
        private FolderObj workingDir;
        //Current path
        List<string> path;

    }
}
