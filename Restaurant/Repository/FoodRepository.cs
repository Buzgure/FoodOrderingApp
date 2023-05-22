using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Restaurant.Repository;
namespace Restaurant.Repository
{
    public class FoodRepository : Repository<Food>
    {
        private string connString = "Data Source=DESKTOP-08FV6VI\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;";

        public Food save(Food entity)
        {
            try
            {   
                using (SqlConnection connection = new SqlConnection(connString))
                    connection.Open();
                SqlCommand command =
                    new SqlCommand(
                        "INSERT INTO Food(food_id, food_name, food_description, food_price, restaurant_id) VALUES (@id, @name, @description, @price, @restaurant_id)");
                command.Parameters.AddWithValue("@id", entity.FoodId);
                command.Parameters.AddWithValue("@name", entity.FoodName);
                command.Parameters.AddWithValue("@description", entity.FoodDescription);
                command.Parameters.AddWithValue("@price", entity.Price);
                command.Parameters.AddWithValue("@restaurant_id", entity.Restaurant.RestaurantId);
                command.ExecuteNonQuery();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public Food delete(Food entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                    connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Food WHERE food_id = @id");
                command.Parameters.AddWithValue("@id", entity.FoodId);
                command.ExecuteNonQuery();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public Food update(Food entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString)) connection.Open();
                SqlCommand command =
                    new SqlCommand(
                        "UPDATE Food SET food_name = @name, description = @description, price = @price, restaurant_id = @restaurant_id WHERE food_id = @id ");
                command.Parameters.AddWithValue("@name", entity.FoodName);
                command.Parameters.AddWithValue("@description", entity.FoodDescription);
                command.Parameters.AddWithValue("@price", entity.Price);
                command.Parameters.AddWithValue("@restaurant_id", entity.Restaurant.RestaurantId);
                command.Parameters.AddWithValue("@id", entity.FoodId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public ICollection<Food> findAll()
        {
            List<Food> foods = new List<Food>();
            RestaurantRepository restaurantRepository = new RestaurantRepository();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    string query = "Select * FROM Food";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Food food = new Food();
                        food.FoodId = Convert.ToInt32(reader["food_id"]);
                        food.FoodName = Convert.ToString(reader["food_name"]);
                        food.FoodDescription = Convert.ToString(reader["food_description"]);
                        food.Price = Convert.ToSingle(reader["food_price"]);
                        int restaurant_id = Convert.ToInt32(reader["restaurant_id"]);
                        Restaurant restaurant = restaurantRepository.findOne(restaurant_id);
                        food.Restaurant = restaurant;
                        foods.Add(food);



                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return foods;

        }

        public Food findOne(int ID)
        {
            throw new NotImplementedException();
        }

        List<Food> getMenuFromRestaurant(Restaurant restaurant)
        {
            List<Food> desiredList = new List<Food>();
            List<Food> allFood = findAll().ToList();
            Repository<Restaurant> restaurantRepo = new RestaurantRepository();
            List<Restaurant> restaurantsList = restaurantRepo.findAll().ToList();
            foreach (Food f in allFood)
            {
                if (f.Restaurant.RestaurantId == restaurant.RestaurantId)
                {
                    desiredList.Add(f);
                }
            }

            return desiredList;

        }
    }
}