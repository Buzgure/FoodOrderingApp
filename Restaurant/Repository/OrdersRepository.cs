using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                    int entriesNo = entity.Food1.Count;
                    Dictionary<int, int> foodQuantity = new Dictionary<int, int>();
                    foreach (var food in entity.Food1)
                    {
                        if (foodQuantity.ContainsKey(food.FoodId))
                        {
                            foodQuantity[food.FoodId]++;
                        }
                        else
                        {
                            foodQuantity[food.FoodId] = 0;
                        }
                        
                    }

                    foreach (var kvp in foodQuantity)
                    {
                        int foodId = kvp.Key;
                        int quantity = kvp.Value;
                        command.Parameters.AddWithValue("@users_id", entity.User.UserId);
                        command.Parameters.AddWithValue("@food_id", foodId);
                        command.Parameters.AddWithValue("@users_name", entity.User.Username);
                        command.Parameters.AddWithValue("@users_location", entity.Location);
                        command.Parameters.AddWithValue("@distance", entity.Distance);
                        command.Parameters.AddWithValue("@order_mentions", entity.Mentions);
                        command.Parameters.AddWithValue("@order_status", entity.Status);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.ExecuteNonQuery();
                    }
                    
                  
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
            throw new System.NotImplementedException();
        }

        public Orders findOne(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}