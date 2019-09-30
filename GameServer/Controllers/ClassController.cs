using System.Collections.Generic;
using System.Linq;
using GameServer.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_dbContext.Class.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _dbContext.Class.FirstOrDefault(c => c.Id == id);

            return result != null ? (ActionResult<string>)Ok(result) : NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return StatusCode(405);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return StatusCode(405);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return StatusCode(405);
        }
    }
}