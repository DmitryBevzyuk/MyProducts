using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProducts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProducts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly DataBaseContext _cc;

        public PriceListController(DataBaseContext cc)
        {
            _cc = cc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceList>>> Get()
        {
            return await _cc.PriceList.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceList>> Get(int id)
        {
            PriceList priceList = await _cc.PriceList.FirstOrDefaultAsync(x => x.Id == id);
            if (priceList == null)
                return null;
            return new ObjectResult(priceList);
        }
    }
}
