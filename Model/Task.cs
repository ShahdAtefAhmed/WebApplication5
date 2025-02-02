namespace WebApplication5.Model
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public DateTime TaskDate { get; set; }
        public int SubjectId { get; set; }
        public List<Subject> Subject { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
