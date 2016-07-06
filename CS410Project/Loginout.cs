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

        public Loginout()
        {
            loggedin = false;
        }

        public Loginout(string username, string password, string destination)
        {
            this.username = username;
            this.password = password;
            this.destination = destination;
            this.loggedin = false; //By default we are not logged into the system
            parseDestination(destination);
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
            //Conventional ftp link is "ftp://whatever.what/"
            //So we need to parse through 3 '/' to get base link, then everything else is the currDirectory
            char[] delimiterchars = { '/', '\\' }; //chars to use with parsing
            string[] parsed = target.Split(delimiterchars, StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;
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
        public bool Login(Client client)
        {
            if (!checkValidURI(destination))
                return false;
            if (client.establishConnection(username, password, destination, currDirectory))
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
    }
}
