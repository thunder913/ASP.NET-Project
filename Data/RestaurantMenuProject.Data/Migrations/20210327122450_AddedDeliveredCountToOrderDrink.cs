﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantMenuProject.Data.Migrations
{
    public partial class AddedDeliveredCountToOrderDrink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveredCount",
                table: "OrderDrinks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredCount",
                table: "OrderDrinks");
        }
    }
}
