namespace UserVoiceSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common;
    using ViewModels.Votes;

    [Authorize]
    public class VotesController : BaseController
    {
        private readonly IVotesService votes;

        public VotesController(IVotesService votes)
        {
            this.votes = votes;
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(VotePostViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();



                return this.Json(new { Count = 5 });
            }

            throw new HttpException(404, "not found !");
        }
    }
}
