using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProducts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyProducts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostsController : ControllerBase
    {
        private readonly DataBaseContext _cc;

        public CostsController(DataBaseContext cc)
        {
            _cc = cc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costs>>> Get()
        {
            return await _cc.Costs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Costs>> Get(int id)
        {
            Costs costs = await _cc.Costs.FirstOrDefaultAsync(x => x.Id == id);
            if (costs == null)
                return null;
            return new ObjectResult(costs);
        }
    }
}
