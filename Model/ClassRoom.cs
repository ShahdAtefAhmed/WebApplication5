namespace WebApplication5.Model
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public string ClassRoomSubject { get; set; }
        public string ClassRoomChapter { get; set; }
        public DateTime ClassRoomClassDate { get; set; }
        public TimeSpan ClassRoomClassTime { get; set; }
        public string ClassRoomDescription { get; set; }
        public string ClassRoomVideoUrl { get; set; }
        public List<Task> Tasks { get; set; }
 
    }
}
