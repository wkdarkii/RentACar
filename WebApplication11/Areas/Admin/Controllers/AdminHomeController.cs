using Microsoft.AspNetCore.Mvc;
using WebApplication11.Entitys.Context;
using WebApplication11.Session;

namespace WebApplication11.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        private OtelContext _otelContext { get; set; }

        [ServiceFilter(typeof(SessionAuthorizationFilter))]
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
