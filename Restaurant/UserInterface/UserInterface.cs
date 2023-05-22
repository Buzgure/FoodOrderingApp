using System;
using System.Collections.Generic;

namespace Restaurant.UserInterface
{
    public class UserInterface
    {
        private Service.Service service;

        public UserInterface(Service.Service service)
        {
            this.service = service;
        }

        public void testMethod()
        {
            List<User> users = service.getAllUsers();
            Console.WriteLine("Add User: ");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string pass = Console.ReadLine();
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            User user = new User(username, pass, name);
            service.UserAdd(user);
            Console.WriteLine("Users after add: ");
            users = service.getAllUsers();
            foreach (User u in users)
            {
                Console.WriteLine(u.ToString());
            }

        }
    }
}