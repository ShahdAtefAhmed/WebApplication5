using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTO;
using WebApplication5.Repo;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _repo;

        public TaskController(ITask repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult PostTask(TaskDTO dto)
        {
            _repo.PostTask(dto);
            return Created();
        }
        [HttpGet]
        public IActionResult GetTask()
        {
            var s = _repo.GetTask();
            return Ok(s);
        }
     

    }
}
