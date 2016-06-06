namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using Common;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web.Common;

    public class AuthorsService : IAuthorsService
    {
        private readonly IDbRepository<Author> authors;
        private readonly IIdentifierProvider identifierProvider;

        public AuthorsService(IDbRepository<Author> authors, IIdentifierProvider identifierProvider)
        {
            this.authors = authors;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Author> GetAll()
        {
            return this.authors.All();
        }

        public Author GetById(string id)
        {
            var author = this.authors.GetById(id);

            return author;
        }

        public void Create(Author author)
        {
            this.authors.Add(author);
            this.authors.Save();
        }

        public void Update(Author author)
        {
            this.authors.Update(author);
            this.authors.Save();
        }

        public void Delete(Author author)
        {
            this.authors.Delete(author);
            this.authors.Save();
        }
    }
}
