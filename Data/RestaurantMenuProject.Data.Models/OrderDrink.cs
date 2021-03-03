﻿namespace RestaurantMenuProject.Data.Models
{
    public class OrderDrink
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }

        public int Count { get; set; }
    }
}
