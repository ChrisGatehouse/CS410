using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

//Sample connection
//Playing around with the FTP library of .NET
namespace Sample
{
    class FTPClient
    {
        static void Main()
        {
            //Set destination for request
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.ed.ac.uk/pub");
            request.KeepAlive = true;
            //Log in with anonymous = user, poop1234@gmail.com = pass
            request.Credentials = new NetworkCredential("anonymous", "poop1234@gmail.com");
            //Use command to list directory with details
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            //Get response from FTP
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //Place response into a stream
            Stream responseStream = response.GetResponseStream();
            //Create a reader with the stream
            StreamReader reader = new StreamReader(responseStream);

            List<string> result = new List<string>();

            //Store the results into indexes of the List
            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }

            //Done with the reader & response, close streams
            reader.Close();
            response.Close();

            //Output result
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
            //Only here so cmd doens't close instantly
            Console.Read();
        }
    }
}
