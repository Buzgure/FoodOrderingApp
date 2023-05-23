using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Restaurant.Repository
{
    public class OrdersRepository : Repository<Orders>
    {
        private string connString = "Data Source=DESKTOP-08FV6VI\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;";

        public Orders save(Orders entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO Orders(users_id, food_id, users_name, user_location, distance, order_mentions, order_status, quantity) VALUES (@users_id, @food_id, @users_name, @user_location, @distance, @order_mentions, @order_status, @quantity)",
                        connection);
                    command.Parameters.AddWithValue("@users_id", entity.UserId);
                    command.Parameters.AddWithValue("@food_id", entity.FoodId);
                    command.Parameters.AddWithValue("@users_name", entity.Name);
                    command.Parameters.AddWithValue("@user_location", entity.Location);
                    command.Parameters.AddWithValue("@distance", entity.Distance);
                    command.Parameters.AddWithValue("@order_mentions", entity.Mentions);
                    command.Parameters.AddWithValue("@order_status", entity.Status);
                    command.Parameters.AddWithValue("@quantity", entity.Quantity);
                    command.ExecuteNonQuery();
                    
                    
                  
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return entity;
        }

        public Orders delete(Orders entity)
        {
            throw new System.NotImplementedException();
        }
        
        public Orders update(Orders entity)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Orders> findAll()
        { 
            List<Orders> orders = new List<Orders>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Orders order = new Orders();
                        order.UserId = Convert.ToInt32(reader["users_id"]);
                        order.FoodId = Convert.ToInt32(reader["food_id"]);
                        order.Name = Convert.ToString(reader["users_name"]);
                        order.Location = Convert.ToString(reader["user_location"]);
                        order.Distance = Convert.ToSingle(reader["distance"]);
                        order.Mentions = Convert.ToString(reader["order_mentions"]);
                        order.Status = Convert.ToString(reader["order_status"]);
                        order.Quantity = Convert.ToInt32(reader["quantity"]);
                        orders.Add(order);

                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return orders;
        }

        private ICollection<Food> GetFoodByID(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Orders findOne(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}