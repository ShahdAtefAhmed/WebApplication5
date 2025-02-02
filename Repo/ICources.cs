using WebApplication5.DTO;

namespace WebApplication5.Repo
{
    public interface ICources
    {
       public void PostCources (CoursesDTO dTO);
        public List<CoursesDTO> GetCources ();
        public void UpdateById(int id, CoursesDTO dTO);
        public void DeleteById(int id);
    }
}
