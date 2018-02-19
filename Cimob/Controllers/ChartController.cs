using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using asp_net_core_mvc_mysql_template.Models;
using Newtonsoft.Json;

namespace asp_net_core_mvc_mysql_template.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            FruitDBContext context = HttpContext.RequestServices.GetService(typeof(FruitDBContext)) as FruitDBContext;
            ViewData["Title"] = "Anychart ASP.NET Core C# template";
            ViewData["ChartTitle"] = "Top 5 fruits";
            ViewData["ChartData"] = JsonConvert.SerializeObject(context.GetTopFruits());
            return View(context.GetTopFruits());
        }
    }
}
