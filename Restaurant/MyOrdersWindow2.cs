using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Restaurant.Repository;


namespace Restaurant
{
    public partial class MyOrdersWindow2 : Form
    {
        private Repository<Orders> ordersRepo;
        private Repository<User> usersRepo;
        private User user;
        private Service.Service service;


        public User User
        {
            get => user;
            set => user = value;
        }

        public Repository<Orders> OrdersRepo
        {
            get => ordersRepo;
            set => ordersRepo = value;
        }

        public Repository<User> UsersRepo
        {
            get => usersRepo;
            set => usersRepo = value;
        }

        public Service.Service Service
        {
            get => service;
            set => service = value;
        }

        public MyOrdersWindow2()
        {
            InitializeComponent();
        }

        private void ordersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void MyOrdersWindow2_Load(object sender, EventArgs e)
        {
             
            string connString = "Data Source=DESKTOP-08FV6VI\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
    
                string query = "SELECT u.username as Name, f.food_name as Item_Ordererd, o.order_mentions as Mentions, o.order_status as Status, (o.quantity*f.food_price) as Price   FROM Orders o INNER JOIN Food f ON o.food_id = f.food_id INNER JOIN Users u ON o.users_id = u.users_id WHERE u.users_id = @users_id ";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@users_id", user.UserId);
                SqlDataReader reader = command.ExecuteReader();
    
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                ordersGridView.DataSource = dataTable;
                float total = 0;
                foreach (DataGridViewRow row in ordersGridView.Rows)
                {
                    if (row.Cells["Price"].Value != null &&
                        float.TryParse(row.Cells["Price"].Value.ToString(), out float value))
                    {
                        total += value;
                    }
                        
                    
                }

                List<Orders> orders = service.findOrdersByUser(user.UserId);
                Restaurant r = service.FindRestaurantByFoodId(orders[0].FoodId);

                float maxDistance = r.DeliveryMaxDistance;
                foreach (Orders order in orders)
                {
                    if (order.Distance > maxDistance)
                    {
                        float additionalFee = r.ExtraDeliveryFee * (order.Distance - r.DeliveryMaxDistance);
                        total += additionalFee;
                    }
                }
                label2.Text = total.ToString();



            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented");
        }

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            /*
            var selected = ordersGridView.CurrentRow.DataBoundItem as Orders;

            if (selected != null)
            {
                Orders orderToDelete = service.findOrdersByUserIdAndFoodId(selected.UserId, selected.FoodId);
                service.deleteOrder(orderToDelete);
                MessageBox.Show("Order deleted successfully!");
            }
            else
            {
                MessageBox.Show("You have to select an order.");
            }*/


            MessageBox.Show("Function not implemented");
            
        }

        private void returnToMain(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Service = service;
            mainMenu.OrdersRepo = ordersRepo;
            mainMenu.User = user;
            Hide();
            mainMenu.Show();
        }
    }
}