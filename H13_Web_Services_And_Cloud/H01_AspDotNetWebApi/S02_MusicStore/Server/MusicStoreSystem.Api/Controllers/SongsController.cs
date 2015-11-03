namespace MusicStoreSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Models.Songs;
    using MusicStore.Common.Constants;
    using Services.Data.Songs;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SongsController : ApiController
    {
        private readonly ISongsServices songs;

        public SongsController(ISongsServices songsService)
        {
            this.songs = songsService;
        }

        // GET: api/Songs
        public IHttpActionResult GetSongs()
        {
            var result = this.songs
                .All()
                .Select(SongDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        [Route("api/songs/all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.songs
                .All(page, pageSize)
                .Select(SongDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Songs/5
        public IHttpActionResult GetSong(int id)
        {
            var song = this.songs.GetById(id);

            if (song == null)
            {
                return this.NotFound();
            }

            return this.Ok(song);
        }

        // PUT: api/Songs/5
        public IHttpActionResult PutSong(int id, [FromBody] SongSaveRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var song = this.songs.GetById(id);

            if (song == null)
            {
                return this.BadRequest("No such song !");
            }

            var updatedSongId = this.songs.Update(song, model.Title, model.Year, model.Genre, model.AlbumId);

            return this.Ok(updatedSongId);
        }

        // POST: api/Songs
        public IHttpActionResult PostSong([FromBody] SongSaveRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdSongId = this.songs.Add(model.Title, model.Year, model.Genre, model.AlbumId);

            return this.Ok(createdSongId);
        }

        // DELETE: api/Songs/5
        public IHttpActionResult DeleteSong(int id)
        {
            var song = this.songs.GetById(id);

            if (song == null)
            {
                return this.NotFound();
            }

            this.songs.Delete(song);

            return this.Ok(song);
        }
    }
}