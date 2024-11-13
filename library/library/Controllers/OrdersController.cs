using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly OrderService _orderService = new OrderService(new DataContext());
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            List<Order> result=_orderService.GetOrders();
            if (result == null) { return NotFound(); } 
            return result;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetByID(int code)
        {
            Order result=_orderService.GetOrder(code);
            if (result == null) { return NotFound(); }
            return result;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Order order)
        {
            return _orderService.AddOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int code, [FromBody] Order order)
        {
            return _orderService.UpdateOrder(code, order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int code)
        {
            return _orderService.DeleteOrder(code);
        }
    }
}
