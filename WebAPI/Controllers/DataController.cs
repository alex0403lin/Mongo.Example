using Data.Models;
using Data.Mongo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;

    private readonly IMongoRepository<Product> _productMongoRepository;

    public DataController(
        ILogger<DataController> logger,
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
}
