//Main Contributor: Mohammed Inoue
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CS410Project
{
    /*
     * FTPClient is the base class of Client, this will handle the FTP connection
     * This is also made preemptively incase we also need to incorporate SFTP 
     * connections. If we do, there will be a new class made called SFTPClient that 
     *that will also be derived from Client
     */
    class FTPClient : Client
    {
        public FTPClient(string username, string password, string destination) :base()
        {
            this.username    = username;
            this.password    = password;
            this.destination = destination;
            //At the start the current working directory nothing
            this.currDirectory = "";
            //Establish initial connection to the FTP
            establishConnection();
        }
        //Copy Constructor
        public FTPClient(Client toCopy):base (toCopy)
        {
            establishConnection();
        }
        //Logs on to the FTP, returns true if success, returns false if error
        public override bool establishConnection()
        {
            request = (FtpWebRequest)WebRequest.Create(destination);
            request.Credentials = new NetworkCredential(username, password);
            //Request is going to stay alive, until a timeout, or a logout
            request.KeepAlive = true;
            try
            {
                //Test the connection
                WebResponse response = request.GetResponse();
            }
            catch(WebException err) 
            {
                //Problem connecting, output error to console ad return false
                Console.WriteLine(err.ToString());
                return false;
            }
            //Connection is valid, return true
            return true;
        }
        //This function creates a list of the files/folders in the current directory
        public override List<string> getCurrDirectory()
        {
            List<string> results = new List<string>();
            request = (FtpWebRequest)WebRequest.Create(destination + currDirectory);
            try
            {
                //Check if the file exist on the server
                WebResponse testResponse = request.GetResponse();
            }
            catch (WebException err)
            {
                //Not a valid file, so returning an empty list
                Console.WriteLine(err.ToString());
                return results;
            }
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine());
            }
            return results;
        }
        //TODO: add definitions to virtual functions in base class
        private FtpWebRequest request;

    }
}
