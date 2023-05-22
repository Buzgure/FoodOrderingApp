using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class User
    {
        private static int count = 0;
        private int userID;
        private string username;
        private string password;
        private string actualName;
        public ICollection<Orders> Orders { get; set; }


        public User(int userId, string username, string password, string actualName)
        {
            userID = userId;
            this.username = username ?? throw new ArgumentNullException(nameof(username));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
            this.actualName = actualName ?? throw new ArgumentNullException(nameof(actualName));
        }

        public User(string username, string password, string actualName)
        {
            UserId = count++;
            this.username = username;
            this.password = password;
            this.actualName = actualName;
        }

        public User()
        {
        }

        public int UserId
        {
            get => userID;
            set => userID = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string ActualName
        {
            get => actualName;
            set => actualName = value;
        }
        

        public void Deconstruct(out int userId, out string username, out string password, out string actualName)
        {
            userId = userID;
            username = this.username;
            password = this.password;
            actualName = this.actualName;
        }

        public override string ToString()
        {
            return $"User ID: {userID}\n" +
                   $"Username: {Username}\n" +
                   $"Password: {Password}\n" +
                   $"Actual Name: {ActualName}\n";
        }
    }
}