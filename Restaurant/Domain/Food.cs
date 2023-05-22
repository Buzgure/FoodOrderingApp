using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Food
    {   
        private int foodID;
        private string foodName;
        private string foodDescription;
        private float price;
        private Restaurant restaurant;
        public ICollection<Orders> Orders { get; set; }


        public Food(int foodId, string foodName, string foodDescription, float price, Restaurant restaurant)
        {
            foodID = foodId;
            this.foodName = foodName ?? throw new ArgumentNullException(nameof(foodName));
            this.foodDescription = foodDescription ?? throw new ArgumentNullException(nameof(foodDescription));
            this.price = price;
            this.restaurant = restaurant ?? throw new ArgumentNullException(nameof(restaurant));
        }

        public Food()
        {
        }

        public int FoodId
        {
            get => foodID;
            set => foodID = value;
        }

        public string FoodName
        {
            get => foodName;
            set => foodName = value;
        }

        public string FoodDescription
        {
            get => foodDescription;
            set => foodDescription = value;
        }

        public float Price
        {
            get => price;
            set => price = value;
        }

        public Restaurant Restaurant
        {
            get => restaurant;
            set => restaurant = value;
        }


        public void Deconstruct(out int foodId, out string foodName, out string foodDescription, out float price, out Restaurant restaurant)
        {
            foodId = foodID;
            foodName = this.foodName;
            foodDescription = this.foodDescription;
            price = this.price;
            restaurant = this.restaurant;
        }
    }
}