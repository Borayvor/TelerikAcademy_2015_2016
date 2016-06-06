namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using Common;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web.Common;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;
        private readonly IIdentifierProvider identifierProvider;

        public CommentsService(IDbRepository<Comment> comments, IIdentifierProvider identifierProvider)
        {
            this.comments = comments;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Comment> GetAll()
        {
            var allComments = this.comments.All()
                .OrderByDescending(x => x.CreatedOn);

            return allComments;
        }

        public Comment GetById(string idTitle)
        {
            var intId = this.identifierProvider.DecodeIdTitle(idTitle);
            var comment = this.comments.GetById(intId);

            return comment;
        }

        public void Create(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.Save();
        }

        public void Update(Comment comment)
        {
            this.comments.Update(comment);
            this.comments.Save();
        }

        public void Delete(Comment comment)
        {
            this.comments.Delete(comment);
            this.comments.Save();
        }
    }
}
