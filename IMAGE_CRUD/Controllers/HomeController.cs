using IMAGE_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IMAGE_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Adrein2Context context;
        private readonly IHttpContextAccessor accessor;

        public HomeController(ILogger<HomeController> logger,Adrein2Context context,IHttpContextAccessor accessor)
        {
            _logger = logger;
            this.context = context;
            this.accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult signup()
        {
            CustomUser user = new CustomUser()
            {
                CUser = new UserReg(),
                CRoles = context.UserRoles.ToList()
            };
            return View(user);
        }
        [HttpPost]
        public IActionResult signup(CustomUser custom)
        {
            UserReg user = new UserReg()
            {
                Username = custom.CUser.Username,
                Useremail = custom.CUser.Useremail,
                Userpass = custom.CUser.Userpass,
                Userrole = custom.CUser.Userrole,              
            };
            context.UserRegs.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}