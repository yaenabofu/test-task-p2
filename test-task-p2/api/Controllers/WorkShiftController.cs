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
    public class WorkShiftController : Controller
    {
        private readonly IRepository<WorkShift> workShiftRepo;
        public WorkShiftController(IRepository<WorkShift> workShiftRepo)
        {
            this.workShiftRepo = workShiftRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var workShifts = await workShiftRepo.GetAll();

            return Ok(workShifts);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var workShift = await workShiftRepo.Get(id);

            if (workShift != null)
            {
                return Ok(workShift);
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

            var workShifts = await workShiftRepo.Get(paginationParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(
                new
                {
                    workShifts.TotalCount,
                    workShifts.PageSize,
                    workShifts.CurrentPage,
                    workShifts.HasNext,
                    workShifts.HasPrevious
                }));

            return Ok(workShifts);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] WorkShift workShift)
        {
            await workShiftRepo.Create(workShift);
            return Ok(workShift);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] WorkShift workShift)
        {
            await workShiftRepo.Update(workShift);

            return Ok(workShift);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await workShiftRepo.Delete(id))
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
