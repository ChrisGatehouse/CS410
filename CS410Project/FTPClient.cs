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
            request = (FtpWebRequest)WebRequest.Create(this.destination);
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
				Log.Error("Error getting file", e);
				Console.WriteLine(e.ToString());
				return false;
			}
			return true;
		}

        //attempts to get a file from the FTP server. returned boolean denotes success or failure.
        public override bool getFile(string targetFile, string savePath, BackgroundWorker backgroundWorker1)
        {
            long offset = 0;
            string target = destination + currDirectory + targetFile;
            string test = savePath + "\\" + targetFile;
            if (File.Exists(test))
            {
                FileInfo fInfo = new FileInfo(test);
                offset = fInfo.Length;
                MessageBox.Show("File already exists");
            }
            /*
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
                Log.Error("Error getting file", e);
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
            */
            //string target = destination + currDirectory + targetFile;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Proxy = null;

            long fileSize; // this is the key for ReportProgress
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
                    if (offset == 0)
                    {
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
                                bytes += bytesRead; // don't forget to increment bytesRead !
                                int totalSize = (int) (fileSize/1024); // Kbytes
                                if (totalSize == 0)
                                {
                                    writeStream.Write(buffer, 0, bytesRead);

                                    backgroundWorker1.ReportProgress(100);
                                    return true;
                                }
                                backgroundWorker1.ReportProgress((bytes/1024)*100/totalSize, totalSize);
                            }
                        }
                    }
                    else
                    {
                        Uri url2 = new Uri(target);
                        RestartDownloadFromServer(test, url2, offset);
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

        public override bool RestartDownloadFromServer(string fileName, Uri serverUri, long offset)
        {
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Credentials = getCredentials();
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.ContentOffset = offset;
            request.UseBinary = true;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
                Console.WriteLine(e.Message);
                return false;
            }

            var localfileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            var bw = new BinaryWriter(localfileStream);
            
            Stream responseStream = response.GetResponseStream();
            byte[] buffer = new byte[1024];
            int bytesRead = responseStream.Read(buffer, 0, 1024);
            while (bytesRead != 0)
            {
                bw.Write(buffer, 0, bytesRead);
                bytesRead = responseStream.Read(buffer, 0, 1024);
            }
            //switch these to using so we don't have to worry about closing them
            bw.Close();
            localfileStream.Close();
            response.Close();

            Log.Info("Download restart - status: " + response.StatusDescription);
            Console.WriteLine("Download restart - status: {0}", response.StatusDescription);
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
				Log.Info("Directory deleted " + response.StatusDescription);
            }
			catch (WebException ex)
            {
				Log.Error("Failed to delete directory", ex);
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
		public override void putFile(string filename, string path)
		{
			//Get the file name from the full path
			string file = Path.GetFileName(filename);
			request = (FtpWebRequest)WebRequest.Create(destination + path + file);
			request.Credentials = getCredentials();
			request.Method = WebRequestMethods.Ftp.UploadFile;
			//Copy the contents of the file to a byte array
			byte[] fileContents = File.ReadAllBytes(filename);
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
            request.UseBinary = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;

            //Copy the contents of the file to a byte array
            byte[] fileContents = File.ReadAllBytes(filePath);
            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                using (FileStream inputStream = File.OpenRead(filePath))
                {
                    //Set the buffersize to 2kb
                    int BufferSize = 2048;
                    var buffer = new byte[BufferSize];

                    var fileSize = fileContents.Length;
                    var totalSize = (fileSize / 1024);

                    long SentBytes = 0;
                    int BytesRead = inputStream.Read(buffer, 0, BufferSize);
                    while (BytesRead > 0)
                    {
                        try
                        {
                            requestStream.Write(buffer, 0, BytesRead);
                            SentBytes += BytesRead;
                            backgroundWorker1.ReportProgress(((int)SentBytes / 1024) * 100 / totalSize, totalSize);
                        }
                        catch (Exception e)
                        {
                            Log.Error("Upload Error", e);
                        }
                        BytesRead = inputStream.Read(buffer, 0, BufferSize);
                    }
                }
            }
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
