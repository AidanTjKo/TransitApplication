using Microsoft.AspNetCore.Mvc;
using TransitApplication.Models;


namespace TransitApplication.Controllers
{
    public class TransitRoutesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<TransitRoute> routes = new List<TransitRoute>
            {
                new TransitRoute{
                    Id = 1,
                    RouteNumber = 10,
                    Name = "Downtown Express",
                    IsActive = true
                },
                new TransitRoute{
                    Id = 2,
                    RouteNumber = 25,
                    Name = "University Line",
                    IsActive = false
                }
            };
            
            return Json(routes);
        }
    }
}