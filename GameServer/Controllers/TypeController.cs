using System.Collections.Generic;
using System.Threading.Tasks;
using GameServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly CancerIncGameBaseContext _dbContext;

        public TypeController()
        {
            _dbContext = CancerIncGameBaseContext.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> Get()
        {
            return await _dbContext.Type.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Type>> Get(int id)
        {
            var type = await _dbContext.Type.FindAsync(id);

            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }
    }
}