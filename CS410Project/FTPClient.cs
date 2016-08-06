//Main Contributor: Mohammed Inoue
//Secondary Contributer: Miles Sanguinetti
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
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
        public override bool establishConnection(string username, string password, string destination, string currDirectory)
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
                Log.Error("Cannot connect to FTP Server", err);
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
                Log.Error("Cannot logg off from FTP Server", err);
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
                Log.Error("Not a valid target", err);
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
                Log.Error("Not a valid target", err);
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
                Log.Error("Targeted file not directory", err);
                Console.WriteLine(err.ToString());
                return false;
            }
            //Done with the response, so we are closing them now
            testResponse.Close();
            return true;
        }

        //attempts to get a file from the FTP server. returned boolean denotes success or failure.
        public override bool getFile(string targetFile, string savePath, BackgroundWorker backgroundWorker1)
        {         
            string target = destination + currDirectory + targetFile;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Proxy = null;

            long fileSize; 
            try
            {
                using (WebResponse resp = request.GetResponse())
                {
                    fileSize = resp.ContentLength;
                }
            }
            catch (WebException e)
            {
                //Target file and/or destination are erroneous
                Log.Error("Error getting file", e);
                Console.WriteLine(e.ToString());
                MessageBox.Show("Cannot download directory");
                return false;
            }
            try
            {
                request = (FtpWebRequest)WebRequest.Create(target);
                request.Credentials = getCredentials();
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                using (FtpWebResponse responseFileDownload = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = responseFileDownload.GetResponseStream())
                using (FileStream writeStream = new FileStream(savePath + "\\" + targetFile, FileMode.Create))
                {

                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    int bytes = 0;

                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                        bytes += bytesRead;
                        int totalSize = (int)(fileSize / 1024);
                        // If the file is empty download and report 100% progress 
                        if (totalSize == 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            backgroundWorker1.ReportProgress(100);
                            return true;
                        }
                        backgroundWorker1.ReportProgress((bytes / 1024) * 100 / totalSize, totalSize);
                    }
                }
            }
            catch (WebException e)
            {
                //Target file and/or destination are erroneous
                Log.Error("Error getting file", e);
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
            try
            {
                var response = (FtpWebResponse)request.GetResponse();
                Log.Info("Directory created " + response.StatusDescription);
                //TODO: Need to check response code.. 2xx should be OK
            }
            catch (WebException ex)
            {
                Log.Error("Failed to create directory", ex);
                return false;
            }
            return true;
        }

        public override bool deleteRemoteFile(string targetFile)
        {
            var request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + targetFile);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            try
            {
                var response = (FtpWebResponse)request.GetResponse();
                Log.Info("File deleted " + response.StatusDescription);
                //TODO: Need to check response code.. 2xx should be OK
            }
            catch (WebException ex)
            {
                Log.Error("Failed to delete file", ex);
                return false;
            }
            return true;
        }

        public override bool deleteRemoteDir(string targetFile)
        {
            var request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + targetFile);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;

            try
            {
                var response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override void putFile(string fullPathFilename)
        {
            //Get the file name from the full path
            string filename = Path.GetFileName(fullPathFilename);
            request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + filename);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.UploadFile;
            //Copy the contents of the file to a byte array
            byte[] fileContents = File.ReadAllBytes(fullPathFilename);
            request.ContentLength = fileContents.Length;
            //Upload file to FTP server
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            response = (FtpWebResponse)request.GetResponse();
            Log.Info("Upload File Complete, status " + response.StatusDescription);
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
        }
        public override void putFile(string filePath, BackgroundWorker backgroundWorker1)
        {
            //Get the file name from the full path
            string filename = Path.GetFileName(filePath);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + filename);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.UploadFile;
            //Copy the contents of the file to a byte array
            byte[] fileContents = File.ReadAllBytes(filePath);
            request.ContentLength = fileContents.Length;

            //Open the local file for reading
            var inputStream = File.OpenRead(filePath);
            var requestStream = request.GetRequestStream();
            //Set the buffer to 2kb
            var buffer = new byte[2048];
            int totalReadBytesCount = 0;
            int readBytesCount;
            int fileSize = fileContents.Length;
            while ((readBytesCount = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                requestStream.Write(fileContents, 0, readBytesCount);
                totalReadBytesCount += readBytesCount;
                int totalSize = (fileSize / 1024);
                if (totalSize == 0)
                {
                    requestStream.Write(fileContents, 0, readBytesCount);
                    backgroundWorker1.ReportProgress(100);
                    break;
                }
                backgroundWorker1.ReportProgress((totalReadBytesCount / 1024) * 100 / totalSize, totalSize);
            }
            inputStream.Close();
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Log.Info("Upload File Complete, status " + response.StatusDescription);
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
        }
        public override void renameRemoteFile(string currentFileName, string newFileName)
        {
            request = (FtpWebRequest)WebRequest.Create(destination + currDirectory + currentFileName);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newFileName;
            response = (FtpWebResponse)request.GetResponse();
            response.Close();

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
