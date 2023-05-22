using System;
using System.Collections;
using System.Collections.Generic;

namespace Restaurant
{
    public class Restaurant
    {
        private int restaurantID;
        private string name;
        private string schedule;
        private float minimumOrder;
        private float deliveryMaxDistance;
        private float deliveryPrice;
        private float extraDeliveryFee;
        private ICollection<Food> foodMenu; 


        public Restaurant(int restaurantId, string name, string schedule, float minimumOrder, float deliveryMaxDistance,
            float deliveryPrice, float extraDeliveryFee)
        {
            restaurantID = restaurantId;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
            this.minimumOrder = minimumOrder;
            this.deliveryMaxDistance = deliveryMaxDistance;
            this.deliveryPrice = deliveryPrice;
            this.extraDeliveryFee = extraDeliveryFee;
        }

        public void Deconstruct(out int restaurantId, out string name, out string schedule, out float minimumOrder, out float deliveryMaxDistance, out float deliveryPrice, out float extraDeliveryFee)
        {
            restaurantId = restaurantID;
            name = this.name;
            schedule = this.schedule;
            minimumOrder = this.minimumOrder;
            deliveryMaxDistance = this.deliveryMaxDistance;
            deliveryPrice = this.deliveryPrice;
            extraDeliveryFee = this.extraDeliveryFee;
        }

        public Restaurant()
        {
        }

        public int RestaurantId
        {
            get => restaurantID;
            set => restaurantID = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Schedule
        {
            get => schedule;
            set => schedule = value;
        }

        public float MinimumOrder
        {
            get => minimumOrder;
            set => minimumOrder = value;
        }

        public float DeliveryMaxDistance
        {
            get => deliveryMaxDistance;
            set => deliveryMaxDistance = value;
        }

        public float DeliveryPrice
        {
            get => deliveryPrice;
            set => deliveryPrice = value;
        }

        public float ExtraDeliveryFee
        {
            get => extraDeliveryFee;
            set => extraDeliveryFee = value;
        }
    }
}