using Microsoft.EntityFrameworkCore;
using WebApplication5.DTO;
using WebApplication5.Model;

namespace WebApplication5.Repo
{
    public class TaskRepo : ITask
    {
        private readonly AppDbContext _context;

        public TaskRepo(AppDbContext context)
        {
            _context = context;
        }



        public List<TaskDTO> GetTask()
        {
            var s = _context.Tasks.Include(x => x.Subject).Select(x => new TaskDTO
            {
                TaskName = x.TaskName,
                TaskDate = x.TaskDate,
                Subject = x.Subject.Select(x => new SubjectDTO
                {
                    SubjectName = x.SubjectName,
                }).ToList(),
                ClassRoom = new DTO.WebApplication5.DTO.ClassRoomDTO
                {
                    ClassRoomSubject = x.ClassRoom.ClassRoomSubject,
                    ClassRoomChapter = x.ClassRoom.ClassRoomChapter,
                    ClassRoomClassDate = x.ClassRoom.ClassRoomClassDate,
                    // تحويل ClassRoomClassTime من TimeSpan إلى صيغة النص أو تنسيق مناسب
                    ClassRoomClassTime = x.ClassRoom.ClassRoomClassTime.ToString(@"hh\:mm\:ss"),
                    ClassRoomDescription = x.ClassRoom.ClassRoomDescription,
                    ClassRoomVideoUrl = x.ClassRoom.ClassRoomVideoUrl
                }
            }).ToList();
            return s;
        }


        public void PostTask(TaskDTO dto)
        {
            // التأكد من أن ClassRoom في DTO ليس فارغًا لتجنب حدوث NullReferenceException
            if (dto.ClassRoom == null)
            {
                throw new ArgumentException("ClassRoom data is required.");
            }

            // التأكد من أن Subject موجود وبه بيانات
            if (dto.Subject == null || !dto.Subject.Any())
            {
                throw new ArgumentException("At least one subject is required.");
            }

            // تحويل البيانات وتخزينها في قاعدة البيانات
            Model.Task task = new Model.Task
            {
                TaskName = dto.TaskName,
                TaskDate = dto.TaskDate,
                Subject = dto.Subject.Select(x => new Subject
                {
                    SubjectName = x.SubjectName
                }).ToList(),
                ClassRoom = new ClassRoom
                {
                    ClassRoomSubject = dto.ClassRoom.ClassRoomSubject,
                    ClassRoomChapter = dto.ClassRoom.ClassRoomChapter,
                    ClassRoomClassDate = dto.ClassRoom.ClassRoomClassDate,
                    // تحويل ClassRoomClassTime من string إلى TimeSpan
                    ClassRoomClassTime = TimeSpan.Parse(dto.ClassRoom.ClassRoomClassTime),
                    ClassRoomDescription = dto.ClassRoom.ClassRoomDescription,
                    ClassRoomVideoUrl = dto.ClassRoom.ClassRoomVideoUrl
                }
            };

            // إضافة المهمة إلى السياق وحفظ التغييرات
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }




    }
}
