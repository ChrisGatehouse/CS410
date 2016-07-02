using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //TODO: set FTPClient.username to new username
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            //TODO: set FTPClient.password to new password
        }

        private void Destination_TextChanged(object sender, EventArgs e)
        {
            //TODO: set FTPClient.destination to new destination
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //TODO do stuff when log in is pressed like connect to whatever
        }
    }
}
