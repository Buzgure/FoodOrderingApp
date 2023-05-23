using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class MenuWindowForm : Form
    {
        private User user;
        private List<Food> foods;
        private Restaurant restaurant;
        private List<Food> cart;
        static int productNo = 0;
        private static float total = 0;
        public MenuWindowForm()
        {
            InitializeComponent();
            cart = new List<Food>();


        }

        public User User
        {
            get => user;
            set => user = value;
        }

        public List<Food> Food
        {
            get => foods;
            set => foods = value;
        }

        public Restaurant Restaurant
        {
            get => restaurant;
            set => restaurant = value;
        }


        private void menuWindowLoad(object sender, EventArgs e)
        {
            menuGridView.AutoGenerateColumns = false;
            menuGridView.Columns.Clear();
        
               
            DataGridViewTextBoxColumn columnName = new DataGridViewTextBoxColumn();
            columnName.DataPropertyName = "foodName"; 
            columnName.HeaderText = "Food Name";
            menuGridView.Columns.Add(columnName);
        
               
            DataGridViewTextBoxColumn columnPrice = new DataGridViewTextBoxColumn();
            columnPrice.DataPropertyName = "price"; 
            columnPrice.HeaderText = "Price";
            menuGridView.Columns.Add(columnPrice);

            DataGridViewTextBoxColumn columnDescription = new DataGridViewTextBoxColumn();
            columnDescription.DataPropertyName = "foodDescription";
            columnDescription.HeaderText = "Description";
            menuGridView.Columns.Add(columnDescription);
        
                
        
            menuGridView.DataSource = foods;
            cartProductsNO.Text = productNo.ToString();
            totalLabel.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food selected = menuGridView.CurrentRow.DataBoundItem as Food;
            
            if (selected == null)
            {
                MessageBox.Show("You have to select a food type!");
            }
            else if (quantityLabel.Text == null)
            {
                MessageBox.Show("Choose quantity!");
            }
            else
            {
                string quantityStr = quantityTextBox.Text;
                int quantity = int.Parse(quantityStr);
                total += selected.Price * quantity;
                productNo += quantity;
                while (quantity != 0)
                {
                    cart.Add(selected);
                    quantity--;
                }
                
                cartProductsNO.Text = productNo.ToString();
                totalLabel.Text = total.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (total > restaurant.MinimumOrder)
            {
                OrderWindow orderWindow = new OrderWindow();
                orderWindow.User = user;
                orderWindow.Food = cart;
                orderWindow.Restaurant = restaurant;
                this.Hide();
                orderWindow.Show();
            }
            else
            {
                MessageBox.Show("Minimum order not reached!");
            }
            
            

        }
    }
}