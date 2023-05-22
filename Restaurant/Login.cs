using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class Form1 : Form
    {
        
        private Service.Service service;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void Register(object sender, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }
        private void RegisterButtonClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;

            UserRepository userRepo = new UserRepository();
            User user = userRepo.findUserByUserAndPass(username, password);
            if (user != null)
            {
                MessageBox.Show("Login Successful!");
                MainMenu mainMenu = new MainMenu();
                mainMenu.User = user;
                mainMenu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
            
            //throw new System.NotImplementedException();
        }
    }
}