using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Restaurant.Repository
{
    public class RestaurantRepository : Repository<Restaurant>
    {
        private string connString = "Data Source=DESKTOP-08FV6VI\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;";
        public Restaurant save(Restaurant entity)
        {
            try
            {   
                using (SqlConnection connection = new SqlConnection(connString))
                    connection.Open();
                SqlCommand command =
                    new SqlCommand(
                        "INSERT INTO Restaurant(restaurant_id, restaurant_name, schedule, minimum_order, maximum_distance, delivery_price, extra_delivery_fee) VALUES (@id, @name, @schedule, @minOrder, @maxDist, @delPrice, @delFee)");
                command.Parameters.AddWithValue("@id", entity.RestaurantId);
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@schedule", entity.Schedule);
                command.Parameters.AddWithValue("@minOrder", entity.MinimumOrder);
                command.Parameters.AddWithValue("@maxDist", entity.DeliveryMaxDistance);
                command.Parameters.AddWithValue("@delPrice", entity.DeliveryPrice);
                command.Parameters.AddWithValue("@delFee", entity.ExtraDeliveryFee);
                command.ExecuteNonQuery();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public Restaurant delete(Restaurant entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                    connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Restaurant WHERE restaurant_id = @id");
                command.Parameters.AddWithValue("@id", entity.RestaurantId);
                command.ExecuteNonQuery();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public Restaurant update(Restaurant entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString)) connection.Open();
                SqlCommand command =
                    new SqlCommand(
                        "UPDATE Restaurant SET restaurant_name = @name, schedule = @schedule, minimum_order = @minOrder, maximum_distance = @maxDist, delivery_price = @delPrice, extra_delivery_fee = @delFee WHERE restaurant_id = @id ");
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@schedule", entity.Schedule);
                command.Parameters.AddWithValue("@minOrder", entity.MinimumOrder);
                command.Parameters.AddWithValue("@maxDist", entity.DeliveryMaxDistance);
                command.Parameters.AddWithValue("@delPrice", entity.DeliveryPrice);
                command.Parameters.AddWithValue("@delFee", entity.ExtraDeliveryFee);
                command.Parameters.AddWithValue("@id", entity.RestaurantId);
                command.ExecuteNonQuery();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public ICollection<Restaurant> findAll()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    
                    connection.Open();
                    string query = "SELECT * FROM Restaurant";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.RestaurantId = Convert.ToInt32(reader["restaurant_id"]);
                        restaurant.Name = Convert.ToString(reader["restaurant_name"]);
                        restaurant.Schedule = Convert.ToString(reader["schedule"]);
                        restaurant.MinimumOrder = Convert.ToSingle(reader["minimum_order"]);
                        restaurant.DeliveryMaxDistance = Convert.ToSingle(reader["maximum_distance"]);
                        restaurant.DeliveryPrice = Convert.ToSingle(reader["delivery_price"]);
                        restaurant.ExtraDeliveryFee = Convert.ToSingle(reader["extra_delivery_fee"]);
                        restaurants.Add(restaurant);

                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return restaurants;
        }

        public Restaurant findOne(int ID)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants = findAll().ToList();
            foreach (Restaurant restaurant in restaurants)
            {
                if (restaurant.RestaurantId == ID)
                    return restaurant;

            }

            return null;

        }
    }
}