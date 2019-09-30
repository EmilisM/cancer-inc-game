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
    public class EnemyController : ControllerBase
    {
        private readonly CancerIncGameBaseContext _dbContext;

        public EnemyController()
        {
            _dbContext = CancerIncGameBaseContext.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enemy>>> Get()
        {
            return await _dbContext.Enemy.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enemy>> Get(int id)
        {
            var enemy = await _dbContext.Enemy.FindAsync(id);

            if (enemy == null)
            {
                return NotFound();
            }

            return Ok(enemy);
        }

        [HttpGet("{id}/type")]
        public async Task<ActionResult<Enemy>> GetType(int id)
        {
            var types = await _dbContext.EnemyType
                .Include(enemyType => enemyType.Type)
                .Where(type => type.EnemyId == id)
                .ToListAsync();

            if (types.Count == 0)
            {
                return NotFound();
            }

            return Ok(types);
        }
    }
}