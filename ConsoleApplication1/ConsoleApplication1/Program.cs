using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{

    /*
    public class FileUploadsManager
    {
        //pass in the list of file paths which u want to upload.
        public static async void UploadFilesAsync(string[] filePaths)
        {
            try
            {
                List<Task> fileUploadingTasks = new List<Task>();

                foreach (var filePath in filePaths)
                {
                    Console.WriteLine("fucker");
                    fileUploadingTasks.Add(UploadFileAsync(filePath));
                }

                await Task.WhenAll(fileUploadingTasks);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
            }
        }

        public static Task UploadFileAsync(string filePath)
        {
            return Task.Run(async () =>
            {
                try
                {
                    Console.WriteLine("YO");
                    string secret = "ftp://abyss.mynetgear.com/files/";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(
                                     secret + Path.GetFileName(filePath)
                                  );
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    request.Credentials = new NetworkCredential("benleelawrence", "CS410_");

                    Console.WriteLine("I'm IN");
                    StreamReader sourceStream = new StreamReader(filePath);
                    byte[] fileContents = Encoding.UTF8.GetBytes(await sourceStream.ReadToEndAsync());
                    sourceStream.Close();
                    request.ContentLength = fileContents.Length;

                    Stream requestStream = await request.GetRequestStreamAsync();
                    Console.WriteLine("Hello Buddy");
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    Console.WriteLine("Success");
                    requestStream.Close();

                    FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();

                    Console.WriteLine("STOCK Upload File Complete, status {0}", response.StatusDescription);

                    response.Close();
                    /*
                    byte[] fileContents = File.ReadAllBytes(filePath);
                    request.ContentLength = fileContents.Length;
                    //Upload file to FTP server
                    Stream requestStream = await request.GetRequestStreamAsync();
                    requestStream.Write(fileContents, 0, fileContents.Length);

                    requestStream.Close();

                    FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();
                    Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                    response.Close();
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e.Message);
                }
            }
            );
        }
        static void Main(string[] args)
        {
            try
            {

                string[] paths = new string[] { @"C:\Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile3.txt", @"C: \Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile4.txt", @"C: \Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile5.txt" };
                UploadFilesAsync(paths);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
            }
        }

    }
}
*/

    /*
    StreamReader sourceStream = new StreamReader(filePath);
    byte[] fileContents = Encoding.UTF8.GetBytes(await sourceStream.ReadToEndAsync());
    sourceStream.Close();
    request.ContentLength = fileContents.Length;

    Stream requestStream = await request.GetRequestStreamAsync();
    requestStream.Write(fileContents, 0, fileContents.Length);
    requestStream.Close();

    FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();

    Console.WriteLine("STOCK Upload File Complete, status {0}", response.StatusDescription);

    response.Close();

    */




    public class Hello
    {
        public static void Main(string[] args)
        {
            string[] paths = new string[] { @"C:\Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile3.txt", @"C: \Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile4.txt", @"C: \Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile6.txt" };

            string destination = "ftp://abyss.mynetgear.com/files/";
            foreach (string filePath in paths)
            {



                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destination + Path.GetFileName(filePath));
                FtpWebResponse response;
                //Get the file name from the full path
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("benleelawrence", "CS410_");


                //@"C:\Users\lawrenb\Source\Repos\CS410\ConsoleApplication1\ConsoleApplication1\TextFile1.txt"

                //Copy the contents of the file to a byte array

                /*
                StreamReader sourceStream = new StreamReader(filePath);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                */

                byte[] fileContents = File.ReadAllBytes(filePath);
                request.ContentLength = fileContents.Length;
                //Upload file to FTP server
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();


                response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                response.Close();
            }
        }
    }
}

    