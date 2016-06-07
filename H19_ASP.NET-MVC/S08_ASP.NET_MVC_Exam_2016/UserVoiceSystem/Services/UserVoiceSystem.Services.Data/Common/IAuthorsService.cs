namespace UserVoiceSystem.Services.Data.Common
{
    using System.Linq;
    using UserVoiceSystem.Data.Models;

    public interface IAuthorsService
    {
        IQueryable<Author> GetAll();

        Author GetById(int id);

        void Create(Author author);

        void Update(Author author);

        void Delete(Author author);
    }
}
