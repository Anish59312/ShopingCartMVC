using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer.Models;
using QuickKartDataAccessLayer;
using ShopingCartMVC.Models;
using System.Diagnostics;

namespace ShopingCartMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuickKartContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        QuickKartRepository repObj;

        public HomeController(QuickKartContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            repObj = new QuickKartRepository(_context);
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public JsonResult GetCoupons()
        {
            Random random = new Random();
            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] value = new String[5];
            string[] key = { "Arts", "Electronics", "Fashion", "Home", "Toys" };
            for (int i = 0; i < 5; i++)
            {
                string number = "RUSH" + random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + random.Next(1, 10).ToString();
                value[i] = number;
            }
            for (int i = 0; i < 5; i++)
            {
                data.Add(key[i], value[i]);
            }
            return Json(data);
        }
        public IActionResult CheckRole(IFormCollection frm)
        {
            string userId = frm["name"];
            string password = frm["pwd"];
            string checkbox = frm["RememberMe"];
            if (checkbox == "on")
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("UserId", userId, option);
                Response.Cookies.Append("Password", password, option);
            }
            string username = userId.Split('@')[0];
            byte? roleId = repObj.ValidateCredentials(userId, password);
            if (roleId == 1)
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else if (roleId == 2)
            {
                return Redirect("/Customer/CustomerHome?username=" + username);
            }
            return View("Login");
        }

        public ViewResult Contact()
        {
            ViewBag.email = "ansh@gmail.com";
            ViewData["contact"] = "9879143722";
            return View();
        }
        public RedirectResult FAQ()
        {
            return Redirect("/Home/Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
