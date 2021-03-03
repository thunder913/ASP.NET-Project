﻿namespace RestaurantMenuProject.Data.Models
{
    using System;
    using System.Collections.Generic;

    using RestaurantMenuProject.Data.Common.Models;
    using RestaurantMenuProject.Data.Models.Enums;

    public class PromoCode : BaseDeletableModel<int>
    {
        public string Code { get; set; }

        public int MaxUsageTimes { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int UsedTimes { get; set; }

        public PromoCodeType PromoCodeType { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
