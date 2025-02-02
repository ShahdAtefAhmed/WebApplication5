using Microsoft.EntityFrameworkCore;
using WebApplication5.DTO;
using WebApplication5.Model;

namespace WebApplication5.Repo
{
    public class CourcesRepo : ICources
    {
        private readonly AppDbContext _context;

        public CourcesRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<CoursesDTO> GetCources()
        {
            return _context.Courses.Select(x => new CoursesDTO
            {
                CoursesImageUrl = x.CoursesImageUrl,
                CoursesTitle = x.CoursesTitle,
                CoursesDescription = x.CoursesDescription,
                CoursesUrl = x.CoursesUrl
            }).ToList();
        }

        public void PostCources(CoursesDTO dTO)
        {
            Courses courses = new Courses
            {
                CoursesUrl = dTO.CoursesUrl,
                CoursesTitle = dTO.CoursesTitle,
                CoursesDescription = dTO.CoursesDescription,
                CoursesImageUrl = dTO.CoursesImageUrl,
            };
            _context.Courses.Add(courses);
            _context.SaveChanges();
        }

        public void UpdateById(int id, CoursesDTO dTO)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CoursesId == id);
            if (course != null)
            {
                course.CoursesTitle = dTO.CoursesTitle;
                course.CoursesDescription = dTO.CoursesDescription;
                course.CoursesUrl = dTO.CoursesUrl;
                course.CoursesImageUrl = dTO.CoursesImageUrl;

                _context.Courses.Update(course);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Course not found");
            }
        }

        // حذف البيانات بناءً على Id
        public void DeleteById(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CoursesId == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Course not found");
            }
        }
    }
}

