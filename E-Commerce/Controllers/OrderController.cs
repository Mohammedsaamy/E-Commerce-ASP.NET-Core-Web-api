using DTOs.Create;
using DTOs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Order;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {


        IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var orders = orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetOne(int id)
        {
            var orders = orderService.GetOne(id);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Create(CreateOrderDTO order)
        {
            var orderS = orderService.Create(order);
            return Ok(orderS);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(UpdateOrderDTO order, int id)
        {
            var pro = orderService.GetOne(id);
            if (pro == null)
            {
                return NotFound();
            }
            var orders = orderService.Update(order, id);
            return Ok(orders);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var deletedorder = orderService.Delete(id);
            if (deletedorder == null)
            {
                return NotFound();
            }
            return Ok(deletedorder);
        }



    }
}
