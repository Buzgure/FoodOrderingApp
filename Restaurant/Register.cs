using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = userTextBox.Text;
            string pass = passTextBox.Text;
            string name = nameTextbox.Text;
            Repository<User> userRepo = new UserRepository();
            
            Service.Service service = new Service.Service(null, userRepo, null, null);
            List<User> users = service.getAllUsers();
            
            if (username.Length <= 2)
            {
                MessageBox.Show("Username must contain at least 3 characters!");
                return;
            }

            if (pass.Length <= 2)
            {
                MessageBox.Show("Password must contain at least 3 characters!");
                return;
            }
            
            foreach (User u in users)
            {
                    if (u.Username.Equals(username))
                    {
                        MessageBox.Show("Username already exists!");
                        return;
                    }
                
                
            }


            User user = new User(username, pass, name);
            if (service.UserAdd(user) != null)
            {
                MessageBox.Show("Register successful!");
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Register failed!");
            }
        }
    }
}