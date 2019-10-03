using System.Collections.Generic;
using System.Threading.Tasks;
using GameServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyTypeController : ControllerBase
    {
        private readonly CancerIncGameBaseContext _dbContext;

        public EnemyTypeController()
        {
            _dbContext = CancerIncGameBaseContext.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<List<EnemyType>>> GetTypes()
        {
            return await _dbContext.EnemyType
                .Include(type => type.Enemy)
                .Include(type => type.Type)
                .ToListAsync();
        }
    }
}