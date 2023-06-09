﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class OrderWindow : Form
    {
        User user;
        private Repository<Restaurant> restaurantRepo;
        private Restaurant restaurant;
        private List<Food> food;
        private Repository<Orders> ordersRepo;
        private Service.Service service;
        public OrderWindow()
        {
            InitializeComponent();
            restaurantRepo = new RestaurantRepository();
            ordersRepo = new OrdersRepository();
            service = new Service.Service(restaurantRepo, null, null, ordersRepo);
        }

        public Restaurant Restaurant
        {
            get => restaurant;
            set => restaurant = value;
        }

        public User User
        {
            get => user;
            set => user = value;
        }
        

        public Repository<Restaurant> RestaurantRepo
        {
            get => restaurantRepo;
            set => restaurantRepo = value;
        }
        

        public Repository<Orders> OrdersRepo
        {
            get => ordersRepo;
            set => ordersRepo = value;
        }

        public Service.Service Service
        {
            get => service;
            set => service = value;
        }

        public List<Food> Food
        {
            get => food;
            set => food = value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string city = cityTextBox.Text;
            string street = StreetTextBox.Text;
            string streetNo = textBox2.Text;
            string mentions = textBox3.Text;

            string location = city + ", " + street + ", " + streetNo + ";";
            
            //Orders order = new Orders(service.getMaxIDOrder, user.ActualName, location,);
           // Orders order = new Orders(1, user.Username, location,
            //    float.Parse(distanceTextBox.Text), mentions, "Taken", user, food);
            Dictionary<int, int> foodQuantity = new Dictionary<int, int>();

            foreach (Food f in food)
            {
                if (foodQuantity.ContainsKey(f.FoodId))
                {
                    foodQuantity[f.FoodId]++;
                }
                else
                {
                    foodQuantity[f.FoodId] = 1;
                }
            }

            foreach (var kvp in foodQuantity)
            {
                int foodId = kvp.Key;
                int quantity = kvp.Value;
                Orders order = new Orders(user.UserId, foodId, user.Username, location,
                    Convert.ToSingle(distanceTextBox.Text), mentions, "taken",
                    quantity);
                //Add order update;
                service.addOrder(order);
            }
            
            
            MainMenu mainMenu = new MainMenu();
            mainMenu.User = user;
            
            this.Hide();
            mainMenu.Show();



        }


    }
}