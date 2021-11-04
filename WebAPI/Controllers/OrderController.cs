using Data.Models;
using Data.Mongo.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    private readonly IMongoRepository<Order> _orderMongoRepository;

    public OrderController(
        ILogger<OrderController> logger,
        IMongoRepository<Order> ordersMongoRepository)
    {
        _logger = logger;
        _orderMongoRepository = ordersMongoRepository;
    }

    [HttpGet]
    public async Task<List<Order>> GetAll()
    {
        return await _orderMongoRepository.GetAllAsync();
    }

    [HttpGet]
    public async Task<Order> GetById(string id)
    {
        return await _orderMongoRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] OrderAddViewModel model)
    {
        var entity = await _orderMongoRepository.InsertAsync(new Order()
        {
            OrderNumber = Guid.NewGuid().ToString(),
            Products = model.Products
        });

        return new JsonResult(new ResponseResult<Order>(entity != null, entity));
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] OrderEditViewModel model)
    {
        var entity = await _orderMongoRepository.UpdateAsync(new Order()
        {
            Id = model.Id,
            OrderNumber = model.OrderNumber,
            Products = model.Products
        });

        return new JsonResult(new ResponseResult<Order>(entity != null, entity));
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] OrderDeleteViewModel model)
    {
        var entity = await _orderMongoRepository.DeleteAsync(new Order()
        {
            Id = model.Id
        });

        return new JsonResult(new ResponseResult<Order>(entity != null, entity));
    }
}
