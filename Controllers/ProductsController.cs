using System;
using MongoExample.Services;
using MongoExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace MongoExample.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProductsController: Controller {

    private readonly MongoDbService _mongoDbService;
    public ProductsController(MongoDbService mongoDbService) {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<List<Product>> Get() {
        return await _mongoDbService.GetProducts();
        
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product) {
        await _mongoDbService.CreateProduct(product);
        return CreatedAtAction(nameof(Get), new {id = product.Id}, product);
    }



}