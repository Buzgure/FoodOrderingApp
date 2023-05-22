using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class OrderWindow : Form
    {
        User user;
        private Repository<Restaurant> restaurantRepo;
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
            string streetNo = StreetNoTextBox.Text;
            string mentions = MentionsTextBox.Text;

            string location = city + ", " + street + ", " + streetNo + ";";
            
            //Orders order = new Orders(service.getMaxIDOrder, user.ActualName, location,);
            Orders order = new Orders(service.getMaxIDOrder(), user.Username, location,
                float.Parse(distanceTextBox.Text), mentions, "Taken", user, food);
            service.addOrder(order);
            MainMenu mainMenu = new MainMenu();
            mainMenu.User = user;
            this.Hide();
            mainMenu.Show();



        }


    }
}