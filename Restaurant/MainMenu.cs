using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    public partial class MainMenu : Form
    {   
        User user;
        private Repository<Restaurant> restaurantRepo;
        private Repository<Food> foodRepo;

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
            

        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
            
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
            List<Food> allFood = foodRepo.findAll().ToList();
            
            Restaurant selected = restaurantGridView.CurrentRow.DataBoundItem as Restaurant;
            if (selected != null)
            {
                List<Food> filteredFoods = allFood.Where(food => food.Restaurant.RestaurantId == selected.RestaurantId)
                    .ToList();
                menuGridView.DataSource = filteredFoods;
            }
            //List<Food> foodList = foodRepo.findAll().ToList();
            //menuGridView.DataSource = foodList;


        }

        private void menuGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new System.NotImplementedException();
        }
    }
}