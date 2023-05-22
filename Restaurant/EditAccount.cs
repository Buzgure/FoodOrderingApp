using System;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class EditAccount : Form
    {
        private User user;
        private Repository<User> userRepo;
        private Service.Service service;
        public EditAccount()
        {
            InitializeComponent();
            userRepo = new UserRepository();
            service = new Service.Service(null, userRepo, null, null);

        }

        public User User
        {
            get => user;
            set => user = value;
        }

        private void editAccountLoad(object sender, EventArgs e)
        {
            label5.Text = user.Username;
            label7.Text = user.Password;
            label9.Text = user.ActualName;
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Repository<User> userRepo = new UserRepository();
            //Service.Service service = new Service.Service(null, userRepo, null, null);
            //User newUser = new User();
            //newUser.UserId = user.UserId;
            string username = textBox3.Text;
            string password = textBox2.Text;
            string name = textBox1.Text;
            User updatedUser = new User(user.UserId, username, password, name);
            
            if (service.UserUpdate(updatedUser) != null)
            {
                MessageBox.Show("User updated successful!");
                MainMenu mainMenu = new MainMenu();
                mainMenu.User = updatedUser;
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Update failed!");
            }

        }

        private void returnToMain(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.User = user;
            mainMenu.Show();
            this.Hide();
        }
    }
}