using WebApplication5.DTO.WebApplication5.DTO;
using WebApplication5.Model;

namespace WebApplication5.DTO
{
    public class TaskDTO
    {
        public string TaskName { get; set; }
        public DateTime TaskDate { get; set; }
        public List<SubjectDTO> Subject { get; set; }
        public ClassRoomDTO ClassRoom { get; set; }
    }
}
