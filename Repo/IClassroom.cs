using WebApplication5.DTO;
using WebApplication5.DTO.WebApplication5.DTO;

namespace WebApplication5.Repo
{
    public interface IClassroom
    {
        void PostClassRoom(ClassRoomDTO dto);
        List<ClassRoomDTO> GetClassRooms();
        void UpdateClassRoom(int id, ClassRoomDTO dto);
    }
}
