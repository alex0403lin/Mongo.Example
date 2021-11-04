using Data.Models;
using Data.Mongo.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly IMongoRepository<Product> _productMongoRepository;

    public ProductController(
        ILogger<ProductController> logger,
        IMongoRepository<Product> productsMongoRepository)
    {
        _logger = logger;
        _productMongoRepository = productsMongoRepository;
    }

    [HttpGet]
    public async Task<List<Product>> GetAll()
    {
        return await _productMongoRepository.GetAllAsync();
    }

    [HttpGet]
    public async Task<Product> GetById(string id)
    {
        return await _productMongoRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] ProductAddViewModel model)
    {
        var entity = await _productMongoRepository.InsertAsync(new Product()
        {
            Name = model.Name,
            Price = model.Price
        });

        return new JsonResult(new ResponseResult<Product>(entity != null, entity));
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] ProductEditViewModel model)
    {
        var entity = await _productMongoRepository.UpdateAsync(new Product()
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price
        });

        return new JsonResult(new ResponseResult<Product>(entity != null, entity));
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] ProductDeleteViewModel model)
    {
        var entity = await _productMongoRepository.DeleteAsync(new Product()
        {
            Id = model.Id
        });

        return new JsonResult(new ResponseResult<Product>(entity != null, entity));
    }
}
