using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly CancerIncGameBaseContext _dbContext;

        public ClassController()
        {
            _dbContext = CancerIncGameBaseContext.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> Get([FromQuery] string name)
        {
            if (name != null)
            {
                return await _dbContext.Class.Where(c => c.Name.Contains(name)).ToListAsync();
            }

            return await _dbContext.Class.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> Get(int id)
        {
            var c = await _dbContext.Class.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            return Ok(c);
        }
    }
}