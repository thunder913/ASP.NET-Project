﻿namespace RestaurantMenuProject.Data.Models
{
    using RestaurantMenuProject.Data.Common.Models;

    public class BasketDish : BaseModel<int>
    {
        public string BasketId { get; set; }

        public int DishId { get; set; }

        public virtual Basket Basket { get; set; }

        public virtual Dish Dish { get; set; }

        public int Quantity { get; set; }
    }
}
