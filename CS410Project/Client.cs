﻿//Main Contributor: Mohammed Inoue
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;

/*
 * This object stores, username, password and destination
 * And other things when they are needed
 * If we need to also incorporate SFTP, this will act as a base class
*/

namespace CS410Project
{
    public abstract class Client
    {
        //Default constructor
        public Client() { }
        //Copy Constructor
        public Client(Client toCopy)
        {
            this.destination = toCopy.destination;
            this.currDirectory = toCopy.currDirectory;
        }
        //For each functionality, the FTP client needs a new method
        //Call the new object that performs that functionality
        //TODO:list directory, login, logoff etc as virtual functions to add definitions to in FTPClient
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
        public abstract bool establishConnection(string username, string password, string destination, string currDirectory); //performs the initial/test connection
        public abstract bool eliminateConnection();  //Disconnects from FTP server by setting keep alive off and then doing a dummy command
        public abstract List<string> getCurrDirectory(); //returns a list with the current directory's files(OBSOLETE)
        public abstract List<string> getCurrDetailedDirectory(); //returns a list with the current directory's files with extra details
        public abstract bool isFile(string targetDirectory); //Checks if working dir is a file or not (VERY SLOW, USE WITH CAUTION)
		public abstract bool getFile(string targetFile, string savePath);
		public abstract bool getFile(string targetFile, string savePath, BackgroundWorker backgroundWorker1); //attempts to get a file from the FTP server. returned boolean denotes success or failure.
        public abstract bool RestartDownloadFromServer(string fileName, Uri serverUri, long offset);
        public abstract bool createRemoteDir(string newDir);
        public abstract bool deleteRemoteFile(string targetFile);
        public abstract bool deleteRemoteDir(string targetFile);
        public abstract void putFile(string fullPathFilename);
		public abstract void putFile(string filename, string path);
        public abstract void putFile(string filePath, BackgroundWorker backgroundWorker1);
        public abstract void renameRemoteFile(string currentFileName, string newFileName);


        //Destination of the FTP server
        public string destination { get; set; }
        /*CurrDirectory will function as what gets appended to the destination to
         *provide the full path of the "destination" this allows us to keep destination 
         *as the root directory*/
        public string currDirectory { get; set; }
    }
}