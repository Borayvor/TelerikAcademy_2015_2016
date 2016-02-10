namespace MyApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Models;
    using MyApp.Models;
    using MyApp.Services.Contracts;

    using Ninject;

    public class HomeController : Controller
    {
        [Inject]
        public IMoviesService Movies { get; set; }

        [Inject]
        public IActorsService Actors { get; set; }

        [Inject]
        public IStudiosService Studios { get; set; }

        [Inject]
        public IDirectorsService Directors { get; set; }

        public ActionResult Index()
        {
            this.PopulateDropDowns();

            return View();
        }


        public ActionResult MoviesRead( [DataSourceRequest] DataSourceRequest request )
        {

            return this.Json( this.Movies.GetAll().Select(
                    x =>
                    new MovieViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Year = x.Year,
                        Studio = new StudioViewModel
                        {
                            Name = x.Studio.Name,
                            Id = x.StudioId
                        },
                        MaleActor = new MaleActorViewModel
                        {
                            Name = x.LeadingMaleRole.FirstName + " " + x.LeadingMaleRole.LastName,
                            Id = x.LeadingMaleRoleId
                        },
                        FemaleActor = new FemaleActorViewModel
                        {
                            Name = x.LeadingFemaleRole.FirstName + " " + x.LeadingFemaleRole.LastName,
                            Id = x.LeadingFemaleRoleId
                        },
                        Director = new DirectorViewModel
                        {
                            Name = x.Director.FirstName + " " + x.Director.LastName,
                            Id = x.DirectorId
                        }
                    } ).ToDataSourceResult( request ) );
        }

        [HttpPost]
        public ActionResult MoviesCreate( [DataSourceRequest] DataSourceRequest request,
            [Bind( Prefix = "models" )]IEnumerable<MovieViewModel> movies )
        {
            var results = new List<MovieViewModel>();

            if ( movies != null && this.ModelState.IsValid )
            {
                foreach ( var movie in movies )
                {
                    var newMovie = new Movie
                    {
                        Title = movie.Title,
                        DirectorId = movie.Director.Id,
                        LeadingFemaleRoleId = movie.FemaleActor.Id,
                        LeadingMaleRoleId = movie.MaleActor.Id,
                        Year = movie.Year,
                        StudioId = movie.Studio.Id
                    };
                    this.Movies.CreateMovie( newMovie );

                    results.Add( movie );
                }

                this.Movies.SaveChanges();
            }

            return this.Json( results.ToDataSourceResult( request, this.ModelState ) );
        }

        [HttpPost]
        public ActionResult MoviesUpdate( [DataSourceRequest] DataSourceRequest request,
            [Bind( Prefix = "models" )]IEnumerable<MovieViewModel> movies )
        {
            var movieViewModels = movies as IList<MovieViewModel> ?? movies.ToList();
            if ( movies != null && this.ModelState.IsValid )
            {
                foreach ( var movie in movieViewModels )
                {
                    var updatedMovie = new Movie
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        DirectorId = movie.Director.Id,
                        LeadingFemaleRoleId = movie.FemaleActor.Id,
                        LeadingMaleRoleId = movie.MaleActor.Id,
                        Year = movie.Year,
                        StudioId = movie.Studio.Id
                    };

                    this.Movies.UpdateMovie( updatedMovie );
                }

                this.Movies.SaveChanges();
            }

            return this.Json( movieViewModels.ToDataSourceResult( request, this.ModelState ) );
        }

        [HttpPost]
        public ActionResult MoviesDestroy( [DataSourceRequest] DataSourceRequest request,
            [Bind( Prefix = "models" )]IEnumerable<MovieViewModel> movies )
        {
            var movieViewModels = movies as MovieViewModel[] ?? movies.ToArray();
            foreach ( var movie in movieViewModels )
            {
                this.Movies.DeleteMovie( movie.Id );
            }

            this.Movies.SaveChanges();

            return this.Json( movieViewModels.ToDataSourceResult( request, this.ModelState ) );
        }

        private void PopulateDropDowns()
        {

            var maleActors =
               this.Actors.GetAll()
                   .Select( a => new MaleActorViewModel { Name = a.FirstName + " " + a.LastName, Id = a.Id } ).OrderBy( x => x.Name );

            var femaleActors =
               this.Actors.GetAll()
                   .Select( a => new FemaleActorViewModel { Name = a.FirstName + " " + a.LastName, Id = a.Id } ).OrderBy( x => x.Name );

            var studios =
                this.Studios.GetAll()
                    .Select( s => new StudioViewModel { Name = s.Name, Id = s.Id } ).OrderBy( x => x.Name );

            var directors =
                this.Directors.GetAll()
                    .Select( d => new DirectorViewModel { Name = d.FirstName + " " + d.LastName, Id = d.Id } ).OrderBy( x => x.Name );

            this.ViewData["maleActors"] = maleActors;
            this.ViewData["defaultMaleActor"] = maleActors.First();
            this.ViewData["femaleActors"] = femaleActors;
            this.ViewData["defaultFemaleActor"] = femaleActors.First();
            this.ViewData["studios"] = studios;
            this.ViewData["defaultStudio"] = studios.First();
            this.ViewData["directors"] = directors;
            this.ViewData["defaultDirector"] = directors.First();
        }
    }
}