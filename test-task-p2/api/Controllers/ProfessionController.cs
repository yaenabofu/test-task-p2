using api.Models.DatabaseObjects;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessionController : Controller
    {
        private readonly IRepository<Profession> professionRepo;
        public ProfessionController(IRepository<Profession> professionRepo)
        {
            this.professionRepo = professionRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var professions = await professionRepo.Get();

            return Ok(professions);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profession = await professionRepo.Get(id);

            if (profession != null)
            {
                return Ok(profession);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Profession profession)
        {
            await professionRepo.Create(profession);
            return Ok(profession);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Profession profession)
        {
            await professionRepo.Update(profession);

            return Ok(profession);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await professionRepo.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
