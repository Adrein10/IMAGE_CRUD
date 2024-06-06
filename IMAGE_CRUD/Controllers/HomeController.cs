using IMAGE_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

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
        public IActionResult productlist()
        {
            var show = context.Products.Include(options => options.ProductCategoryNavigation).ToList();
            return View(show);
        }
        public IActionResult addproduct()
        {
            CustomProduct product = new CustomProduct()
            {
                CProduct = new Product(),
                CPCategory = context.PCategories.ToList()
            };
            return View(product);
        }
        [HttpPost]
        public IActionResult addproduct(CustomProduct customProduct,IFormFile img)
        { 
            if(img != null && img.Length > 1)
            {
                var type = System.IO.Path.GetExtension(img.FileName).Substring(1);
                if(type == "png" || type == "jfif" || type == "jpeg" || type == "jpg")
                {
                    var imgname = Path.GetFileName(img.FileName);
                    var name = Guid.NewGuid() +imgname;
                    var folder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/productimg");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    var path = Path.Combine(folder, name);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        img.CopyTo(stream);
                    }
                    var dbPath = Path.Combine("images", name);
                    Product product = new Product()
                    {
                        ProductName = customProduct.CProduct.ProductName,
                        ProductCategory = customProduct.CProduct.ProductCategory,
                        ProductImage = dbPath,
                        ProductPrice = customProduct.CProduct.ProductPrice
                    };
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("productlist");

                }else
                {
                    ViewBag.imgfailed = "file type note supported";
                }
            }
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
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(UserReg user)
        {
            var show = context.UserRegs.Where(option => option.Useremail == user.Useremail && option.Userpass == user.Userpass).FirstOrDefault();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}