using System;
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
                        "INSERT INTO Orders(users_id, food_id, users_name, user_location, distance, order_mentions, order_status) VALUES (@users_id, @food_id, @users_name, @user_location, @distance, @order_mentions, @order_status)",
                        connection);
                    int entriesNo = entity.Food1.Count;
                    while (entriesNo != 0)
                    {
                        command.Parameters.AddWithValue("@users_id", entity.User.UserId);
                        command.Parameters.AddWithValue("@food_id", null);
                        entriesNo--;
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