namespace UserVoiceSystem.Services.Data.Common
{
    using System.Linq;
    using UserVoiceSystem.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        Comment GetById(string id);

        void Create(Comment comment);

        void Update(Comment comment);

        void Delete(Comment comment);
    }
}
