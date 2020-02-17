using SharedTrip.Services;
using SharedTrip.ViewModels;

namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new IndexViewModel();
                viewModel.Username = this.usersService.GetUsername(this.User);
                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpGet("/Home")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}