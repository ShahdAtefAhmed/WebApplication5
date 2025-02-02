using WebApplication5.DTO;

namespace WebApplication5.Repo
{
    public interface ITask
    {
        public void PostTask(TaskDTO dto);
        public List<TaskDTO> GetTask();
    }
}
