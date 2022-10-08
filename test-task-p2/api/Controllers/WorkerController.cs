using api.Models.DatabaseObjects;
using api.Repositories.ValidatorsRepository.SnilsValidator;
using api.Repositories.WorkerRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class WorkerController : Controller
    {
        private readonly SnilsValidator snilsValidator;
        private readonly IWorker workerRepo;
        public WorkerController(IWorker workerRepo, SnilsValidator snilsValidator)
        {
            this.workerRepo = workerRepo;
            this.snilsValidator = snilsValidator;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var workers = await workerRepo.Get();

            return Ok(workers);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var workers = await workerRepo.Get(id);

            if (workers != null)
            {
                return Ok(workers);
            }

            return NotFound();
        }
        [HttpGet("GetBySnils/{snils}")]
        public async Task<IActionResult> GetBySnils(string snils)
        {
            var workers = await workerRepo.GetBySnils(snils);

            if (workers != null)
            {
                return Ok(workers);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Worker worker)
        {
            Worker workerSameSnils = await workerRepo.GetBySnils(worker.Snils);
            if (workerSameSnils != null)
            {
                return BadRequest("User with this snils is already registered");
            }

            bool isValidSnils = snilsValidator.Validate(worker.Snils);
            if (!isValidSnils)
            {
                return BadRequest("Invalid snils");
            }

            await workerRepo.Create(worker);
            return Ok(worker);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Worker worker)
        {
            await workerRepo.Update(worker);

            return Ok(worker);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await workerRepo.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
