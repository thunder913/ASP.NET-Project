﻿namespace RestaurantMenuProject.Data.Models
{
    using System.Collections.Generic;

    using RestaurantMenuProject.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string CommentText { get; set; }

        public decimal Rating { get; set; }

        public virtual ApplicationUser CommentedBy { get; set; }

        public virtual ICollection<UserLike> Likes { get; set; } = new HashSet<UserLike>();

        public virtual ICollection<UserDislike> Dislikes { get; set; } = new HashSet<UserDislike>();

        public string DishId { get; set; }

        public virtual Dish Dish { get; set; }

        public string DrinkId { get; set; }

        public virtual Drink Drink { get; set; }
    }
}
