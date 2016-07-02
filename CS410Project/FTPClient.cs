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
*/

namespace CS410Project
{
    class FTPClient
    {
        public FTPClient(string username, string password, string destination);
        public ~FTPClient();
        //For each fucntionality, the FTP client needs a new method
        //Call the new object that performs that functionality
        //TODO:list directory, login, logoff etc
        private string username;
        private string password;
        private string destination;
    }
}
