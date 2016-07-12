//Main Contributor: Mohammed Inoue
//Secondary Contributer: Miles Sanguinetti
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

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
        private string username;
        private string password;
        public FTPClient()
            : base()
        {
            this.destination = "";
            this.currDirectory = "";
        }
        //Copy Constructor
        public FTPClient(Client toCopy)
            : base(toCopy)
        {

        }

        public System.Net.NetworkCredential getCredentials()
        {
            return new NetworkCredential(username, password);
        }

        //Logs on to the FTP, returns true if success, returns false if error
        public override bool establishConnection(string username, string password,string destination, string currDirectory)
        {
            this.destination = destination;
            this.currDirectory = currDirectory;
            this.username = username;
            this.password = password;
            request = (FtpWebRequest)WebRequest.Create(this.destination + this.currDirectory);
            //Request is going to stay alive, until a timeout, or a logout
            request.KeepAlive = true;
            //Set the timeout to only be 5000ms
            request.Timeout = 5000;
            //Use password and username to access FTP
            request.Credentials = new NetworkCredential(username, password);
            //Perform any action just to test to see if it failed
            //In this case we are just using List Directory to see if the directory exist
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                //Test the connection
                testResponse = request.GetResponse();
            }
            catch (WebException err)
            {
                //Problem connecting, output error to console and return false
                Console.WriteLine(err.Status.ToString());
                MessageBox.Show("Cannot connect to FTP server", "Uh-Oh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Connection is valid, return true
            testResponse.Close();
            return true;
        }
        //Gets rid of connection
        public override bool eliminateConnection()
        {
            request.KeepAlive = false;
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                testResponse = request.GetResponse();
            }
            catch (WebException err)
            {
                //Problem connecting, output error to console and return false
                Console.WriteLine(err.Status.ToString());
                MessageBox.Show("Cannot log off from FTP server", "Uh-Oh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Connection is valid, return true
            testResponse.Close();
            return true;
        }

        //This function creates a list of the files/folders in the current directory
        //THIS IS NOW OBSOLETE, USE getCurrDetailedDirectory()
        public override List<string> getCurrDirectory()
        {
            List<string> results = new List<string>();
            string target = destination + currDirectory;
            request = (FtpWebRequest)WebRequest.Create(target);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                //Check if the file exist on the server
                testResponse = request.GetResponse();
            }
            catch (WebException err)
            {
                //Not a valid target, so returning an empty list
                Console.WriteLine(err.ToString());
                return null;
            }
            response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine());
            }

            //Done with the reader and response, so we are closing them now
            reader.Close();
            response.Close();
            return results;
        }
        /*This function creates a list of the files/folders in the current directory 
         * with extra details such as permissions, size, etc */
        public override List<string> getCurrDetailedDirectory()
        {
            List<string> results = new List<string>();
            string target = destination + currDirectory;
            request = (FtpWebRequest)WebRequest.Create(target);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            try
            {
                //Check if the file exist on the server
                testResponse = request.GetResponse();
            }
            catch (WebException err)
            {
                //Not a valid target, so returning an empty list
                Console.WriteLine(err.ToString());
                return null;
            }

            response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine());
            }

            //Done with the reader and response, so we are closing them now
            reader.Close();
            response.Close();
            return results;
        }
        //Checks if working dir is a file or not (VERY SLOW, USE WITH CAUTION)
        public override bool isFile(string targetDirectory)
        {
            List<string> results = new List<string>();
            string target = destination + currDirectory + "/" + targetDirectory + "/";
            request = (FtpWebRequest)WebRequest.Create(target);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                //Check if the file exist on the server
                testResponse = request.GetResponse();
            }
            catch (WebException err)
            {
                //Target is a file, not a folder, returning false
                Console.WriteLine(err.ToString());
                return false;
            }
            //Done with the response, so we are closing them now
            testResponse.Close();
            return true;
        }

        //attempts to get a file from the FTP server. returned boolean denotes success or failure.
        public override bool getFile(string targetFile, string savePath)
        {
            string target = destination + currDirectory + targetFile;
            request = (FtpWebRequest)WebRequest.Create(target);
            Console.WriteLine(target);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            try
            {
                //Check if the target file exists on the server
                response = (FtpWebResponse)request.GetResponse();
                Stream responseDownloadStream = response.GetResponseStream();
               
                //Console.WriteLine(savePath);
                var fileStream = File.Create(savePath + "\\" + targetFile);
                //responseDownloadStream.Seek(0, SeekOrigin.Begin);
                responseDownloadStream.CopyTo(fileStream);
                fileStream.Close();
            }
            catch (WebException e)
            {
                //Target file and/or destination are erroneous
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public override bool createRemoteDir(string newDir)
        {
            var request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + newDir);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.MakeDirectory;

            var response = (FtpWebResponse)request.GetResponse();
            //TODO: Need to check response code.. 2xx should be OK

            //TODO: refresh workingDirectory 

            return true;
        }

        public override bool deleteRemoteFile(string targetFile)
        {
            var request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + targetFile);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            var response = (FtpWebResponse)request.GetResponse();
            //TODO: Need to check response code.. 2xx should be OK

            //TODO: refresh workingDirectory 

            return true;
        }

        //TODO: Add more functionality for the FTP client here
        //Also include the function prototype as an abstract type in the Client base class

        /*The request object stores credentials and performs the methods to
        *to interact with the FTP server*/
        private FtpWebRequest request;
        //This response is used for when testing if the connection is valid
        private WebResponse testResponse;
        //This reponse is used to pull data from the FTP server
        private FtpWebResponse response;
    }
}
