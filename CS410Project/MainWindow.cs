using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace CS410Project
{
    public partial class Main_Window : Form
    {
        public Main_Window()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            //When the textbox changes, the username string is updated
            username = UsernameTextbox.Text;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            //When the textbox changes, the password string is updated
            password = PasswordTextbox.Text;
        }

        private void Destination_TextChanged(object sender, EventArgs e)
        {
            //When the textbox changes, the destination string is updated
            destination = DestinationTextbox.Text;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //For now by default we will just log on using FTP
            if (checkValidURI(destination))
            {
                client = new FTPClient(username, password, destination);
            }
            else
            {
                //Not a valid FTP link, display error message
                MessageBox.Show("Destination is not a valid FTP", "You fucked up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkValidURI(string target)
        {
            Uri uriTest;
            //Checks to see if provided destination is a valid URI for an FTP
            bool testResult = Uri.TryCreate(target, UriKind.Absolute, out uriTest) && (uriTest.Scheme == Uri.UriSchemeFtp);
            return testResult;
        }

        public Client client;
        public string username = "";
        public string password = "";
        public string destination = "";
    }
}
