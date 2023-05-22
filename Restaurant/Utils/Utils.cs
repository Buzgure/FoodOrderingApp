using System.Collections.Generic;

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
    }
}