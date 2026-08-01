using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projeto.Data;
using projeto.Models;

namespace projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(InMemoryDatabase.Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = InMemoryDatabase.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound("Produto não encontrado.");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            newProduct.Id = InMemoryDatabase.Products.Max(p => p.Id) + 1;
            InMemoryDatabase.Products.Add(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
    }
}