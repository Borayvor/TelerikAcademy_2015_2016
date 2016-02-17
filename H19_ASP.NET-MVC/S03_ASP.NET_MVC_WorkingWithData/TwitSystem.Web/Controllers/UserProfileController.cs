namespace TwitSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using TwitSystem.Services;

    [Authorize]
    public class UserProfileController : Controller
    {
        public UserProfileController(IUserService users)
        {
            this.Users = users;
        }

        [Inject]
        private IUserService Users { get; set; }

        public ActionResult MyProfile()
        {
            var id = this.User.Identity.GetUserId();

            if (id != null)
            {

                var appUserUserName = this.Users.GetById(id).UserName;

                var tweets = this.Users.GetUserTweets(id).To<TweetsResponseViewModels>().ToList();

                var viewModel = new UsersResponseViewModel
                {
                    UserName = appUserUserName,
                    Tweets = tweets
                };

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }
    }
}
