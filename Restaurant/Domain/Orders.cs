using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Orders
    {
        private static int count = 0;
        private int orderID;
        private int userID;
        private int foodID;
        private string name;
        private string location;
        private float distance;
        private string mentions;
        private string status;
        private int quantity;

        public Orders()
        {
            orderID = count++;
        }

        public Orders(int userId, int foodId, string name, string location, float distance, string mentions, string status, int quantity)
        {
            orderID = count++;
            userID = userId;
            foodID = foodId;
            this.name = name;
            this.location = location;
            this.distance = distance;
            this.mentions = mentions;
            this.status = status;
            this.quantity = quantity;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public int UserId
        {
            get => userID;
            set => userID = value;
        }

        public int FoodId
        {
            get => foodID;
            set => foodID = value;
        }

        public int OrderId
        {
            get => orderID;
            set => orderID = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Location
        {
            get => location;
            set => location = value;
        }

        public float Distance
        {
            get => distance;
            set => distance = value;
        }

        public string Mentions
        {
            get => mentions;
            set => mentions = value;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }
        


        public void Deconstruct(out int orderId, out string name, out string location, out float distance, out string mentions, out string status)
        {
            orderId = orderID;
            name = this.name;
            location = this.location;
            distance = this.distance;
            mentions = this.mentions;
            status = this.status;
            
        }

        private sealed class OrderIdEqualityComparer : IEqualityComparer<Orders>
        {
            public bool Equals(Orders x, Orders y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.orderID == y.orderID;
            }

            public int GetHashCode(Orders obj)
            {
                return obj.orderID;
            }
        }

        public static IEqualityComparer<Orders> OrderIdComparer { get; } = new OrderIdEqualityComparer();
    }
    
    
}