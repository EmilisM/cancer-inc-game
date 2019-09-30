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
    public class TowerController : ControllerBase
    {
        private readonly CancerIncGameBaseContext _dbContext;

        public TowerController()
        {
            _dbContext = CancerIncGameBaseContext.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tower>>> Get()
        {
            return await _dbContext.Tower.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tower>> Get(int id)
        {
            var tower = await _dbContext.Tower.FindAsync(id);

            if (tower == null)
            {
                return NotFound();
            }

            return Ok(tower);
        }

        [HttpGet("{id}/type")]
        public async Task<ActionResult<Tower>> GetType(int id)
        {
            var attackTypes = await _dbContext.TowerAttackType
                .Include(attackType => attackType.AttackType)
                .Where(type => type.TowerId == id)
                .ToListAsync();

            if (attackTypes.Count == 0)
            {
                return NotFound();
            }

            return Ok(attackTypes);
        }
    }
}