//Main Contributor: Mohammed Inoue

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CS410Project
{
    /*Loginout is the object that manages and keeps track of:
     * username, password, FTP server address
     * loginout also, provides functionality for logging in, and logging off
     * loginout keeps track of the time between actions and will force a logoff after X amount of time
     * loginout parses to grab the root link and sends the rest to the client as the currdirectory
     * loginout will also be the one responsible for saving connection info into files, encrypting/decrypting them for future uses
     */
    public class Loginout
    {
        private string username;
        private string password;
        private string destination;
        public string currDirectory { get; set; } 
        //If a user checks if we are logged on, it means we are doing stuff, so we also reset the timeout timer
        private bool loggedin;
        public bool LoggedIn { get { RestartTimer(); return loggedin; } set {/*This does nothing, because you shouldn't be able to set this outside of the object. */} }
        private Timer timeout = new Timer();

        private List<SessionInfo> sessions; //The list of sessions that are loaded/saved for past connections
        private struct SessionInfo
        {
            public string name;
            public string domain;
            public string username;
            public string password;
            
        };

        public Loginout()
        {
            sessions = new List<SessionInfo>();
            loggedin = false;
        }
        
        //Enable the Timeout Timer
        public void EnableTimeoutTimer(ElapsedEventHandler e,uint seconds)
        {
            timeout.Elapsed += e;  //Hooks the timer to an eventhandler function in the main window
            timeout.Interval = seconds * 1000;  //Sets time to seconds * miliseconds
            timeout.Start();
        }

        //Restart Timer
        public void RestartTimer()
        {
            timeout.Stop();
            timeout.Start();
        }

        //Place this method in the timeout event in the main window
        public void Timeout()
        {
            loggedin = false;
            timeout.Stop();
        }

        //Separates the base link from the directory listing and returns a string of the directory listing
        private void parseDestination(string target)
        {
            if (target == null)
                return;

            //Conventional ftp link is "ftp://whatever.what/"
            //So we need to parse through 3 '/' to get base link, then everything else is the currDirectory
            char[] delimiterchars = { '/', '\\' }; //chars to use with parsing
            string[] parsed = target.Split(delimiterchars, StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;
            //Set currDirectory to default as ""
            currDirectory = "";
            foreach (string s in parsed)
            {
                if (counter == 1)
                {
                    this.destination += s;
                    this.destination += "/";
                    counter++;
                    continue;
                }
                if (counter == 0)
                {
                    this.destination = s;
                    this.destination += "//";
                    counter++;
                    continue;
                }
                currDirectory += s;
                currDirectory += "/";
            }
            //Regardless of how the destination is typed, the finished string will have a '/' at the end
        }

        //Logs into the the FTP server using client's establishConnection method
        //This function also passes destination and currDirectory information to Client
        public bool Login(Client client, string username, string password, string destination)
        {
            this.username = username;
            this.password = password;
            this.destination = destination;
            parseDestination(this.destination);

            if (!checkValidURI(this.destination))
                return false;
            if (client.establishConnection(username, password, this.destination, currDirectory))
            {
                loggedin = true; //we are now logged on
                return true; //Returns true when log in success and sets loggedinout to true
            }
            else
            {
                //failed to log on
                loggedin = false;
                return false;
            }
        }

        private bool checkValidURI(string target)
        {
            Uri uriTest;
            //Checks to see if provided destination is a valid URI for an FTP
            bool testResult = Uri.TryCreate(target, UriKind.Absolute, out uriTest) && (uriTest.Scheme == Uri.UriSchemeFtp);
            return testResult;
        }

        public bool Logout(Client client)
        {
            if (client.eliminateConnection())
            {
                loggedin = false; //we are now logged off
                timeout.Stop();   //Stop the timer
                return true;
            }
            else
            {
                //unsuccessful log off, though we can assume we have lost connection to the server so set loggedinout to false
                loggedin = false;
                timeout.Stop();   //Stop the timer
                return false; 
            }
        }

        //Reads and loads saved connections from an external file and store them into the sessions List
        public void readSessions()
        {
            int counter = 0; //We use this counter to know whether or not we are reading name,domain,user or password
            string reading;
            if(!System.IO.File.Exists(@"sessions"))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"sessions", true);
                file.Close();
            }
            
            
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"sessions"))
            {

                SessionInfo tempSession = new SessionInfo();

                while ((reading = file.ReadLine()) != null)
                {
                    //First we need to decrypt our stuff
                    switch (counter)
                    {
                        case 0:
                            tempSession.name = encryptdecrypt(reading);
                            counter++;
                            continue;
                        case 1:
                            tempSession.domain = encryptdecrypt(reading);
                            counter++;
                            continue;
                        case 2:
                            tempSession.username = encryptdecrypt(reading);
                            counter++;
                            continue;
                        case 3:
                            tempSession.password = encryptdecrypt(reading);
                            counter = 0;
                            sessions.Add(tempSession);
                            continue;

                    }
                }

            }
        }

        //Writes and saves sessions into an external file
        public void writeSessions()
        {
            //For ease, we are just going to overwrite the file everytime as a way to support deleting from the saved files quickly
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"sessions",false))
            {
                for (int i = 0; i < sessions.Count;i++)
                {
                    //First we need to encrypt out stuff before writing it
                    file.WriteLine(encryptdecrypt(sessions[i].name));
                    file.WriteLine(encryptdecrypt(sessions[i].domain));
                    file.WriteLine(encryptdecrypt(sessions[i].username));
                    file.WriteLine(encryptdecrypt(sessions[i].password));
                }
            }
        }

        //Load saved connections using the name as a key and returning a List with the destination, username and password
        //[0] = name, [1] = domain, [2] = username, and [3] = password
        public List<string> loadSessions(string name)
        {
            SessionInfo targetInfo = sessions.Find(x => x.name == name);
            List<string> output = new List<string>();
            output.Add(targetInfo.name);  //output[0] = name
            output.Add(targetInfo.domain); //output[1] = domain
            output.Add(targetInfo.username); //output[2] = username
            output.Add(targetInfo.password); //output[3] = password
            return output;
        }

        //Adds a session to the session list
        public void saveSessions(string name,string domain, string username, string password)
        {
            if (domain == null | domain == "")
            {
                return; //Don't bother saving if there is no domain
            }
            SessionInfo newInfo = sessions.Find(x => x.name == name);

            newInfo.username = username;
            newInfo.password = password;
            //We don't want null fields with username + password
            if (username == null)
                newInfo.username = "";
            if (password == null)
                newInfo.password = "";

            if (newInfo.name == null)
            {
                newInfo.name = name; //Name isn't being used, so lets use it
            }else{
                //It exist, so overwrite
                var remove = sessions.Single(x => x.name == name);
                sessions.Remove(remove);
            }

            //let's fill in the data
            newInfo.name = name;
            newInfo.domain = domain;

            sessions.Add(newInfo);
        }

        public void deleteSession(string name)
        {
            var remove = sessions.Single(x => x.name == name);
            sessions.Remove(remove);
        }

        //This returns a list of each domain name per session to be used for the GUI
        public List<string> getSessionDomains()
        {
            List<string> domainList = new List<string>();
            for (int i = 0; i < sessions.Count; i++)
            {
                domainList.Add(sessions[i].name);
            }
                return domainList;
        }

        //This funcction takes in a string and applies a bitwise operation on each character to encrypt it
        //Doing so will also decrypt encrypted strings so it works both ways, super nice
        private string encryptdecrypt(string secretToEveryone)
        {
            var secret = secretToEveryone.ToCharArray();
            //Please don't use the information here to reverse engineer our hot bitfliping encryption security
            for (int i = 0; i < secret.Length;i++)
            {
                secret[i] ^= 'p';  //You didn't see this. Please don't tell anyone.
            }
            string secretstring = new string(secret);
            return secretstring;
        }
    }
}
