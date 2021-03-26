﻿namespace RestaurantMenuProject.Web.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantMenuProject.Data.Models.Dtos;
    using RestaurantMenuProject.Data.Models.Enums;
    using RestaurantMenuProject.Services.Data.Contracts;
    using System;
    using System.Linq;
    using System.Security.Claims;

    [Route("api/[Controller]")]
    [ApiController]
    [IgnoreAntiforgeryToken]
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(
            IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("Delete")]
        public ActionResult<bool> Delete(OrderIdDto orderDto)
        {
            return this.orderService.CancelOrder(orderDto.OrderId).Result;
        }

        [HttpPost("All")]
        public ActionResult GetAllOrders()
        {
            var draw = this.Request.Form["draw"].FirstOrDefault();
            var start = this.Request.Form["start"].FirstOrDefault();
            var length = this.Request.Form["length"].FirstOrDefault();
            var sortColumn = this.Request.Form["columns[" + this.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = this.Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = this.Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var orders = this.orderService.GetAllOrders(sortColumn, sortColumnDirection, searchValue);

            var recordsTotal = orders.Count();
            var data = orders.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };

            return this.Ok(jsonData);
        }

        [HttpPost("EditStatus")]
        public ActionResult<bool> EditStatus(EditStatusDto editStatus)
        {
            var oldProcessingTypeId = (ProcessType)Enum.Parse(typeof(ProcessType), editStatus.OldProcessingType);
            this.orderService.ChangeOrderStatus(oldProcessingTypeId, (ProcessType) editStatus.NewProcessingTypeId, editStatus.OrderId);
            return true;
        }

        [HttpPost("AcceptOrder")]
        public ActionResult<bool> AcceptOrder(EditStatusDto editStatus)
        {
            var statusEditted = this.EditStatus(editStatus).Value;
            if (!statusEditted)
            {
                throw new InvalidOperationException("There was an error changing the status of the order!");
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.orderService.AddWaiterToOrder(editStatus.OrderId, userId);

            return true;
        }
    }
}
