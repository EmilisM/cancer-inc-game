using System.Collections.Generic;
using System.Threading.Tasks;
using GameServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttackTypeController : ControllerBase
    {
        private readonly CancerIncGameBaseContext _dbContext;

        public AttackTypeController()
        {
            _dbContext = CancerIncGameBaseContext.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<List<TowerAttackType>>> GetTypes()
        {
            return await _dbContext.TowerAttackType
                .Include(type => type.AttackType)
                .Include(type => type.Tower)
                .ToListAsync();
        }
    }
}