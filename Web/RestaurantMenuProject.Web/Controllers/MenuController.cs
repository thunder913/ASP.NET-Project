﻿namespace RestaurantMenuProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantMenuProject.Services.Data.Contracts;

    public class MenuController : Controller
    {
        private readonly IDrinkTypeService drinkTypeService;
        private readonly IDishTypeService dishTypeService;

        public MenuController(IDrinkTypeService drinkTypeService, IDishTypeService dishTypeService)
        {
            this.drinkTypeService = drinkTypeService;
            this.dishTypeService = dishTypeService;
        }

        public IActionResult DisplayFood(string type, string id)
        {
            var dishes = this.dishTypeService.GetAllDisheshWithDishType(type);
            return this.View(dishes);
        }

        public IActionResult Index()
        {
            return this.View(this.dishTypeService.GetAllDishTypes());
        }

        public IActionResult Drinks()
        {
            return this.View(this.drinkTypeService.GetAllDrinkTypes());
        }

        public IActionResult Drink(int id)
        {
            // GET THE DRINK AND DISPLAY IT, PASS IT TO THE VIEW
            return this.View();
        }
    }
}
