﻿//Main Contributor: Mohammed Inoue

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

    public class RemoteDirectory
    {
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
        //Default Constructor
        public RemoteDirectory()
        {
            /*by default, the parent directory of the starting folder is just null*/
            workingDir = new FolderObj("", null);
        }

        //Grabs the contents of the directory of the workingDir
        //And creates file objects and folder objects when needed
        public void initializeDirectory(Client client)
        {
            List<string> directory = new List<string>();
            //Grab the list of files in the current directory
            directory = client.getCurrDetailedDirectory();
            if (directory == null)
            {
                Console.WriteLine("ERROR: invalid directory");
                return;
            }
            else
            {
                directory.Sort();
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

        public List<string> searchRemoteDirectory(Client client, string searchKey)
        {
            List<FileObj> visited = new List<FileObj>();
            List<string> output = new List<string>();
            Queue<FolderObj> queue = new Queue<FolderObj>();
            workingDir.setMarked(true);
            visited.Add(workingDir);
            queue.Enqueue(workingDir);
            FolderObj currDir;
            while (queue.Count != 0)
            {
                currDir = queue.Dequeue();
                updateConsistency(client, currDir, currDir.fileinfo.path);
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
            for (int i = 0; i < visited.Count; i++)
            {
                visited[i].setMarked(false);
            }
            return output;
        }

        //This function changes the currDirectory of the Client
        //To a new one, and initializes new folders to be created
        public bool changeToDirectory(Client client, string destination)
        {
            FileObj newWorkingDir = workingDir.subdirectory.Find(x => x.fileinfo.name == destination);

            if (newWorkingDir == null)
            {
                //Get new folder information if the folder has not been added to the structure yet
                initializeDirectory(client);
                return true;
            }
            else
            {
                if (newWorkingDir.fileinfo.directory)
                {
                    //Just move the working directory over to the new one
                    workingDir = (FolderObj)newWorkingDir;
                    //Append new directory name
                    client.currDirectory += destination + "/";
                    //checks existing structure so it doesn't have to keep rebuilding the structure from scratch if it was already built
                    updateConsistency(client);
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
        /*Update consistency is going to look through current version of its subdirectory
        * then compares the names of every file on the server's directory with what it has 
        * passed in as a currPath, If there is something new not added, it will add it, if thing 
         * has been removed it will remove it*/
        public void updateConsistency(Client client, FolderObj workingDir, string currPath)
        {
            string tempPath = client.currDirectory;
            client.currDirectory = currPath;
            List<string> currConsistency = client.getCurrDetailedDirectory();
            //If the directory we are going to is empty, we don't need to do anything, except clear.
            if (currConsistency == null)
            {
                workingDir.subdirectory.Clear();
                return;
            }
            if (currConsistency.Count == 0)
            {
                workingDir.subdirectory.Clear();
                return;
            }

            List<FileObj.FileInfo> fileData = FileObj.parseFileInfo(currConsistency, client.currDirectory);
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
                    workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                    j++;
                    i++;
                }
                else if (string.Compare(fileData[i].name, workingDir.subdirectory[j].fileinfo.name) < 0)
                {
                    //Add to working directory
                    workingDir.AddToSubDirectory(fileData[i]);
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
                workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                j++;
            }
            while (i < fileData.Count)
            {
                //Add to working directory
                workingDir.AddToSubDirectory(fileData[i]);
                workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                i++;
            }
            client.currDirectory = tempPath;
        }
        /*Update consistency is going to look through current version of its subdirectory
        * then compares the names of every file on the server's directory with what it has 
         * saved, If there is something new not added, it will add it, if thing has been removed
        * it will remove it*/
        public void updateConsistency(Client client)
        {
            List<string> currConsistency = client.getCurrDetailedDirectory();
            //If the directory we are going to is empty, we don't need to do anything, except clear.
            if (currConsistency == null)
            {
                workingDir.subdirectory.Clear();
                return;
            }
            if (currConsistency.Count == 0)
            {
                workingDir.subdirectory.Clear();
                return;
            }

            List<FileObj.FileInfo> fileData = FileObj.parseFileInfo(currConsistency, client.currDirectory);
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
                    workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                    j++;
                    i++;
                }
                else if (string.Compare(fileData[i].name, workingDir.subdirectory[j].fileinfo.name) < 0)
                {
                    //Add to working directory
                    workingDir.AddToSubDirectory(fileData[i]);
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
                workingDir.subdirectory.Sort((x, y) => x.fileinfo.name.CompareTo(y.fileinfo.name));
                j++;
            }
            while (i < fileData.Count)
            {
                //Add to working directory
                workingDir.AddToSubDirectory(fileData[i]);
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
                    FolderObj temp = workingDir;
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
            updateConsistency(client);
        }

        //The current working directory
        private FolderObj workingDir;

    }
}
