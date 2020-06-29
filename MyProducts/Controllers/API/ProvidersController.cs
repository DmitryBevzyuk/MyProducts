using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProducts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProducts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly DataBaseContext _cc;

        public ProvidersController(DataBaseContext cc)
        {
            _cc = cc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Providers>>> Get()
        {
            return await _cc.Providers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Providers>> Get(int id)
        {
            Providers providers = await _cc.Providers.FirstOrDefaultAsync(x => x.Id == id);
            if (providers == null)
                return null;
            return new ObjectResult(providers);
        }
    }
}
