using System.Collections.Generic;
using System.Linq;
using Restaurant.Repository;

namespace Restaurant.Utils
{
    public class Utils
    {
        public int computeQuantity(List<Food> foodList, Food food)
        {
            int count = 0;
            foreach (var f in foodList)
            {
                if (f.FoodId == food.FoodId)
                    count++;
            }

            return count;
        }
        
        public int getMaxIDOrder()
        {
            Repository<Orders> ordersRepo = new OrdersRepository();
            List<Orders> orders = ordersRepo.findAll().ToList();
            int maxID = 0;
            foreach (Orders o in orders)
            {
                if (o.OrderId > maxID)
                    maxID = o.OrderId;
            }

            return maxID;

        }
        /*
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
                            foodQuantity[food.FoodId] = 1;
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
        */
    }
}