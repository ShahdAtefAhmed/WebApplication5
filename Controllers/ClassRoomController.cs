using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTO;
using WebApplication5.DTO.WebApplication5.DTO;
using WebApplication5.Repo;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassroom _repo;

        public ClassRoomController(IClassroom repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult PostClassRoom(ClassRoomDTO dto)
        {
            _repo.PostClassRoom(dto);
            return Created();
        }

        [HttpGet]
        public IActionResult GetClassRooms()
        {
            var classRooms = _repo.GetClassRooms();
            return Ok(classRooms);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom(int id, ClassRoomDTO dto)
        {
            _repo.UpdateClassRoom(id, dto);
            return Accepted();
        }


    }
}
