using System;
using System.Data;
using System.Data.SqlClient;
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
    
                string query = "SELECT o.users_name as Name, f.food_name as Item_Ordererd, o.order_mentions as Mentions, o.order_status as Status, (o.quantity*f.food_price) as Price   FROM Orders o INNER JOIN Food f ON o.food_id = f.food_id WHERE users_name = @users_name";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@users_name", user.Username);
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

                label2.Text = total.ToString();



            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}