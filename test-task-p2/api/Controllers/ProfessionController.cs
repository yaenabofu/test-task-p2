using api.Models.DatabaseObjects;
using api.Models.Responses;
using api.Repositories;
using api.Repositories.PaginationRepository.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var professions = await professionRepo.GetAll();

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

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters paginationParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelState();
            }

            var professions = await professionRepo.Get(paginationParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(
                new
                {
                    professions.TotalCount,
                    professions.PageSize,
                    professions.CurrentPage,
                    professions.HasNext,
                    professions.HasPrevious
                }));

            return Ok(professions);
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

        private IActionResult BadRequestModelState()
        {
            IEnumerable<string> errorMessages = ModelState.Values
                   .SelectMany(value => value.Errors.Select(c => c.ErrorMessage));

            return BadRequest(new ErrorResponse(errorMessages));
        }
    }
}
