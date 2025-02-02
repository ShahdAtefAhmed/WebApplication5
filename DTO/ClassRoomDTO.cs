namespace WebApplication5.DTO
{
    namespace WebApplication5.DTO
    {
        public class ClassRoomDTO
        {
            public string ClassRoomSubject { get; set; }
            public string ClassRoomChapter { get; set; }
            public DateTime ClassRoomClassDate { get; set; }
            public string ClassRoomClassTime { get; set; }  // استخدم string بدلاً من TimeSpan
            public string ClassRoomDescription { get; set; }
            public string ClassRoomVideoUrl { get; set; }
        }
    }

}
