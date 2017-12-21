using CustomerCore.Models;
using CustomerCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerDemo.Controllers
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class SaveOrderResponse : Response
    {
        public Order Order { get; set; }
    }

    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IEnumerable<Order> Orders()
        {
            var orders =  _repository.Orders;            
            return orders;            
        }

        [HttpGet("{id}")]
        public Order GetOrder(int id)
        {
            var order = _repository.GetOrderById(id);
            return order;
        }

        [HttpPost("")]
        public IActionResult AddOrder(Order order)
        {
            var result = _repository.AddOrder(order);

            return Ok(new SaveOrderResponse()
            {
                Succeeded = result.Succeeded,
                ErrorMessage = result.ErrorMessage,
                Order = order
            });
        }

        [HttpPut("")]
        public IActionResult UpdateOrder(Order order)
        {
            var result = _repository.UpdateOrder(order);

            return Ok(new SaveOrderResponse()
            {
                Succeeded = result.Succeeded,
                ErrorMessage = result.ErrorMessage,
                Order = order
            });
        }

        [HttpDelete("")]
        public IActionResult DeleteOrder(Order order)
        {
            var result = _repository.DeleteOrder(order);

            return Ok(new Response() { Succeeded = result.Succeeded });
        }

    }
}
