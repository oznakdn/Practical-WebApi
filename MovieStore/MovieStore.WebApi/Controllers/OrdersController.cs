using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.ViewModels.OrderViewModels;

namespace MovieStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderModel model)
        {
            try
            {
                _orderService.AddOrder(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var result = _orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpGet("Name Surname")]
        public IActionResult AllOrdersByCustomerName(string firtname,string lastname)
        {
                var result = _orderService.GetOrderByCutomerName(firtname, lastname);
                return Ok(result);
        }
    }
}
