using api.Models.DatabaseObjects;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialtyController : Controller
    {
        private readonly IRepository<Specialty> specialtyRepo;
        public SpecialtyController(IRepository<Specialty> specialtyRepo)
        {
            this.specialtyRepo = specialtyRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var specialties = await specialtyRepo.Get();

            return Ok(specialties);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var specialty = await specialtyRepo.Get(id);

            if (specialty != null)
            {
                return Ok(specialty);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Specialty specialty)
        {
            await specialtyRepo.Create(specialty);
            return Ok(specialty);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Specialty specialty)
        {
            await specialtyRepo.Update(specialty);

            return Ok(specialty);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await specialtyRepo.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
