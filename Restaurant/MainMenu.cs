using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class MainMenu : Form
    {   
        User user;
        private Repository<Restaurant> restaurantRepo;
        private Repository<Food> foodRepo;
        private Repository<Orders> ordersRepo;
        private Service.Service service;

        public User User
        {
            get => user;
            set => user = value;
        }

        public MainMenu()
        {
            
            InitializeComponent();
            restaurantRepo = new RestaurantRepository();
            foodRepo = new FoodRepository();
            ordersRepo = new OrdersRepository();
            service = new Service.Service(restaurantRepo, null, foodRepo, ordersRepo);


        }
        

        private void editButton_Click(object sender, EventArgs e)
        {
            EditAccount editAccountForm = new EditAccount();
            editAccountForm.User = user;
            editAccountForm.Show();
            this.Hide();

        }

        private void MainMenuLoad(object sender, EventArgs e)
        {
            label2.Text = user.ActualName;
            List<Restaurant> restaurantList = restaurantRepo.findAll().ToList();
            restaurantGridView.DataSource = restaurantList;
            restaurantGridView.SelectionChanged += restaurantGridView_CellContentClick;
            
            
        }

        private void restaurantGridView_CellContentClick(object sender, EventArgs e)
        {
            try
            {
                
                List<Food> allFood = service.getFoodList();
    
                Restaurant selected = restaurantGridView.CurrentRow.DataBoundItem as Restaurant;
                string schedule = selected.Schedule;
                string pattern = @"(\d{2}:\d{2})\s-\s(\d{2}:\d{2})";
                Match match = Regex.Match(schedule, pattern);
                if (match.Success)
                {
                    string startTimeStr = match.Groups[1].Value;
                    string endTimeStr = match.Groups[2].Value;
                    DateTime startTime = DateTime.ParseExact(startTimeStr, "HH:mm", CultureInfo.InvariantCulture);
                    DateTime endTime = DateTime.ParseExact(endTimeStr, "HH:mm", CultureInfo.CurrentCulture);
                    DateTime now = DateTime.Now;
                    //string currentTimeString = now.ToString("HH:mm");
                    //DateTime currentTime = DateTime.ParseExact(currentTimeString, "HH:mm", CultureInfo.CurrentCulture);
                    if (now < endTime && now > startTime)
                    {
                        if (selected != null)
                        {
                            // List<Food> filteredFoods = allFood.Where(food => food.Restaurant.RestaurantId == selected.RestaurantId).ToList();
                            List<Food> filteredFoods = new List<Food>();
                            foreach (Food f in allFood)
                            {
                                if(f.Restaurant.RestaurantId == selected.RestaurantId)
                                    filteredFoods.Add(f);
                            }
               
                            MenuWindowForm menuWindow = new MenuWindowForm();
                            menuWindow.User = user;
                            menuWindow.Restaurant = selected;
                            menuWindow.Food = filteredFoods;
                            this.Hide();
                            menuWindow.Show();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Restaurant is closed!");
                return;
            }

        }

        private void menuGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void exitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyOrdersWindow2 myOrdersWindow = new MyOrdersWindow2();
            myOrdersWindow.Service = service;
            myOrdersWindow.OrdersRepo = ordersRepo;
            myOrdersWindow.UsersRepo = new UserRepository();
            myOrdersWindow.User = user;
            Hide();
            myOrdersWindow.Show();
        }
    }
}