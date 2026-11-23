// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Product_Api.Data;
// using Product_Api.Models;

// namespace Product_Api.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class ProductsController : ControllerBase
// {
//     private readonly AppDbContext _db;

//     public ProductsController(AppDbContext db)
//     {
//         _db = db;
//     }

//     [HttpGet]
//     public async Task<ActionResult<List<Product>>> GetAll()
//     {
//         return Ok(await _db.Products.ToListAsync());
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<Product>> GetById(int id)
//     {
//         var product = await _db.Products.FindAsync(id);

//         if (product is null)
//             return NotFound();

//         return Ok(product);
//     }

//     [HttpPost]
//     public async Task<ActionResult<Product>> Create(Product newProduct)
//     {
//         _db.Products.Add(newProduct);
//         await _db.SaveChangesAsync();

//         return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
//     }
// }
  

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Api.Data;
using Product_Api.Models;

namespace Product_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        return Ok(await _db.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product newProduct)
    {
        _db.Products.Add(newProduct);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product updated)
    {
        var product = await _db.Products.FindAsync(id);

        if (product is null)
            return NotFound();

        product.Name = updated.Name;
        product.Price = updated.Price;

        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product is null)
            return NotFound();

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
