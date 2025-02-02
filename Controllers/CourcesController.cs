using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTO;
using WebApplication5.Repo;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourcesController : ControllerBase
    {
        private readonly ICources _repo;

        public CourcesController(ICources repo)
        {
            _repo = repo;
        }

        // إضافة دورة جديدة
        [HttpPost]
        public IActionResult PostCources(CoursesDTO dto)
        {
            _repo.PostCources(dto);
            return Ok();
        }

        // الحصول على جميع الدورات
        [HttpGet]
        public IActionResult GetCources()
        {
            var courses = _repo.GetCources();
            return Ok(courses);
        }

        // تحديث دورة باستخدام الـ Id
        [HttpPut("{id}")]
        public IActionResult UpdateCource(int id, CoursesDTO dto)
        {
            try
            {
                _repo.UpdateById(id, dto);
                return Ok("Course updated successfully");
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }

        // حذف دورة باستخدام الـ Id
        [HttpDelete("{id}")]
        public IActionResult DeleteCource(int id)
        {
            try
            {
                _repo.DeleteById(id);
                return Ok("Course deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }
    }
}
