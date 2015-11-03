namespace UniversitySystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Repositories;
    using Models.Homeworks;
    using UniversitySystem.Models;

    public class HomeworksController : ApiController
    {
        private readonly IRepository<Homework> data;

        public HomeworksController()
        {
            this.data = new EfGenericRepository<Homework>(new UniversityDbContext());
        }

        public IHttpActionResult Get()
        {
            var result = this.data
                .All()
                .OrderBy(x => x.TimeSent)
                .Skip(0)
                .Take(10)
                .Select(HomeworkDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var homework = data.GetById(id);

            if (homework == null)
            {
                return NotFound();
            }

            return Ok(homework);
        }

        public IHttpActionResult Post(SaveHomeworkRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newHomework = new Homework
            {
                Content = model.Content,
                TimeSent = model.TimeSent
            };

            this.data.Add(newHomework);
            this.data.SaveChanges();

            return this.Ok(newHomework.Id);
        }
    }
}
