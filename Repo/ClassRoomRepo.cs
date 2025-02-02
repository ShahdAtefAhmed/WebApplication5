using WebApplication5.DTO;
using WebApplication5.DTO.WebApplication5.DTO;
using WebApplication5.Model;

namespace WebApplication5.Repo
{
    public class ClassRoomRepo : IClassroom
    {
        private readonly AppDbContext _context;

        public ClassRoomRepo(AppDbContext context)
        {
            _context = context;
        }

        public void PostClassRoom(ClassRoomDTO dto)
        {
            var classRoom = new ClassRoom
            {
                ClassRoomSubject = dto.ClassRoomSubject,
                ClassRoomChapter = dto.ClassRoomChapter,
                ClassRoomClassDate = dto.ClassRoomClassDate,
                ClassRoomClassTime = TimeSpan.Parse(dto.ClassRoomClassTime),  // تحويل الوقت من string إلى TimeSpan
                ClassRoomDescription = dto.ClassRoomDescription,
                ClassRoomVideoUrl = dto.ClassRoomVideoUrl
            };

            _context.Classrooms.Add(classRoom);
            _context.SaveChanges();
        }

        public List<ClassRoomDTO> GetClassRooms()
        {
            return _context.Classrooms.Select(c => new ClassRoomDTO
            {
                ClassRoomSubject = c.ClassRoomSubject,
                ClassRoomChapter = c.ClassRoomChapter,
                ClassRoomClassDate = c.ClassRoomClassDate,
                ClassRoomClassTime = c.ClassRoomClassTime.ToString(@"hh\:mm"),  // تحويل TimeSpan إلى string
                ClassRoomDescription = c.ClassRoomDescription,
                ClassRoomVideoUrl = c.ClassRoomVideoUrl
            }).ToList();
        }


        public void UpdateClassRoom(int id, ClassRoomDTO dto)
        {
            var classRoom = _context.Classrooms.FirstOrDefault(c => c.ClassRoomId == id);
            if (classRoom != null)
            {
                classRoom.ClassRoomSubject = dto.ClassRoomSubject;
                classRoom.ClassRoomChapter = dto.ClassRoomChapter;
                classRoom.ClassRoomClassDate = dto.ClassRoomClassDate;

                // محاولة تحويل ClassRoomClassTime
                if (TimeSpan.TryParse(dto.ClassRoomClassTime, out TimeSpan classTime))
                {
                    classRoom.ClassRoomClassTime = classTime;
                }
                else
                {
                    // في حالة فشل التحويل، يمكن أن تقرر إما تعيين قيمة افتراضية أو التعامل مع الخطأ
                    // على سبيل المثال: إعطاء قيمة افتراضية 00:00 أو إرجاع رسالة خطأ
                    classRoom.ClassRoomClassTime = TimeSpan.Zero; // تعيين قيمة افتراضية
                                                                  // أو يمكنك استخدام كود آخر لإرجاع رسالة خطأ.
                }

                classRoom.ClassRoomDescription = dto.ClassRoomDescription;
                classRoom.ClassRoomVideoUrl = dto.ClassRoomVideoUrl;

                _context.Classrooms.Update(classRoom);
                _context.SaveChanges();
            }
        }



    }
}
