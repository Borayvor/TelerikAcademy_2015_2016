namespace UniversitySystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Repositories;
    using Models.Students;
    using UniversitySystem.Models;

    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> data;

        public StudentsController()
        {
            this.data = new EfGenericRepository<Student>(new UniversityDbContext());
        }

        public IHttpActionResult Get()
        {
            var result = this.data
                .All()
                .OrderBy(x => x.Name)
                .Skip(0)
                .Take(10)
                .Select(StudentDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var student = data.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public IHttpActionResult Post(SaveStudentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newStudent = new Student
            {
                Name = model.Name,
                Number = model.Number
            };

            this.data.Add(newStudent);
            this.data.SaveChanges();

            return this.Ok(newStudent.Id);
        }
    }
}
