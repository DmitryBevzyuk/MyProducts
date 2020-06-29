using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProducts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProducts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataBaseContext _cc;

        public ProductsController(DataBaseContext cc)
        {
            _cc = cc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            return await _cc.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(int id)
        {
            Products products = await _cc.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (products == null)
                return null;
            return new ObjectResult(products);
        }
    }
}
