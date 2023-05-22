using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Orders
    {
        private int orderID;
        private string name;
        private string location;
        private float distance;
        private string mentions;
        private string status;

        private User user;
        private ICollection<Food> Food;


        public Orders(int orderId, string name, string location, float distance, string mentions, string status,
            User user, List<Food> food)
        {
            orderID = orderId;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.location = location ?? throw new ArgumentNullException(nameof(location));
            this.distance = distance;
            this.mentions = mentions ?? throw new ArgumentNullException(nameof(mentions));
            this.status = status ?? throw new ArgumentNullException(nameof(status));
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Food = food ?? throw new ArgumentNullException(nameof(food));
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

        public User User
        {
            get => user;
            set => user = value;
        }

        public ICollection<Food> Food1
        {
            get => Food;
            set => Food = value;
        }


        public void Deconstruct(out int orderId, out string name, out string location, out float distance, out string mentions, out string status, out User user, out ICollection<Food> food)
        {
            orderId = orderID;
            name = this.name;
            location = this.location;
            distance = this.distance;
            mentions = this.mentions;
            status = this.status;
            user = this.user;
            food = Food;
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