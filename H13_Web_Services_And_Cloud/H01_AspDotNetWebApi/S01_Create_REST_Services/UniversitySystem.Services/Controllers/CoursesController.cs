namespace UniversitySystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Repositories;
    using Models.Courses;
    using UniversitySystem.Models;

    public class CoursesController : ApiController
    {
        private readonly IRepository<Course> data;

        public CoursesController()
        {
            this.data = new EfGenericRepository<Course>(new UniversityDbContext());
        }

        public IHttpActionResult Get()
        {
            var result = this.data
                .All()
                .OrderBy(x => x.Name)
                .Skip(0)
                .Take(10)
                .Select(CourseDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var course = data.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        public IHttpActionResult Post(SaveCourseRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newCourse = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            this.data.Add(newCourse);
            this.data.SaveChanges();

            return this.Ok(newCourse.Id);
        }
    }
}
