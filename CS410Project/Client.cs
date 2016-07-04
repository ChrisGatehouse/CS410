//Main Contributor: Mohammed Inoue
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
        public Client(){}
        //Copy Constructor
        public Client(Client toCopy)
        {
            this.username = toCopy.username;
            this.password = toCopy.password;
            this.destination = toCopy.destination;
            this.currDirectory = toCopy.currDirectory;
        }
        //For each functionality, the FTP client needs a new method
        //Call the new object that performs that functionality
        //TODO:list directory, login, logoff etc as virtual functions to add definitions to in FTPClient
        public abstract bool establishConnection(); //performs the initial/test connection
        public abstract List<string> getCurrDirectory(); //returns a list with the current directory's files
        public abstract bool isFile(); //Checks if working dir is a file or not

        protected string username;
        protected string password;
        //Destination of the FTP server
        public string destination {get;set;}
        /*CurrDirectory will function as what gets appended to the destination to
         *provide the full path of the "destination" this allows us to keep destination 
         *as the root directory*/
        public string currDirectory {get;set;}
    }
}