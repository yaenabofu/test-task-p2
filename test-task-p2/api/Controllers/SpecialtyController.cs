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
    public class SpecialtyController : Controller
    {
        private readonly IRepository<Specialty> specialtyRepo;
        public SpecialtyController(IRepository<Specialty> specialtyRepo)
        {
            this.specialtyRepo = specialtyRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var specialties = await specialtyRepo.GetAll();

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

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginationParameters paginationParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelState();
            }

            var specialties = await specialtyRepo.Get(paginationParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(
                new
                {
                    specialties.TotalCount,
                    specialties.PageSize,
                    specialties.CurrentPage,
                    specialties.HasNext,
                    specialties.HasPrevious
                }));

            return Ok(specialties);
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
        private IActionResult BadRequestModelState()
        {
            IEnumerable<string> errorMessages = ModelState.Values
                   .SelectMany(value => value.Errors.Select(c => c.ErrorMessage));

            return BadRequest(new ErrorResponse(errorMessages));
        }
    }
}
