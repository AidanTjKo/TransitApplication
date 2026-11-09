using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SQLitePCL;
using TransitApplication.Models;
using TransitApplication.Data;
using TransitApplication.Services;

namespace TransitApplication.Controllers
{
    public class TransitRoutesController : Controller
    {
        private readonly TransitApplicationContext _context;

        public TransitRoutesController(TransitApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add([FromBody] TransitRoute route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TransitRoutes.Add(route);

            _context.SaveChanges();

            return Ok(route);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var route = _context.TransitRoutes.Find(id);

            if(route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody]TransitRoute updatedRoute)
        {
            var route = _context.TransitRoutes.Find(id);

            if(route == null)
            {
                return NotFound();
            }

            route.RouteNumber = updatedRoute.RouteNumber;
            route.Name = updatedRoute.Name;
            route.IsActive = updatedRoute.IsActive;

            _context.SaveChanges();

            return Ok(route);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var route = _context.TransitRoutes.Find(id);

            if(route == null)
            {
                return NotFound();
            }

            _context.TransitRoutes.Remove(route);
            _context.SaveChanges();
            return Ok(route);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var routes = _context.TransitRoutes.ToList();
            
            return Json(routes);
        }

        [HttpGet]
        public IActionResult Browse()
        {
            var routes = _context.TransitRoutes.ToList();

            return View(routes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TransitRoute route)
        {
            if(!ModelState.IsValid)
            {
                return View(route);
            }

            _context.TransitRoutes.Add(route);
            _context.SaveChanges();
            return RedirectToAction("Browse");
        }

        
        [HttpGet]
        public IActionResult Stops(int id)
        {
            var stops = _context.BusStops
                .Where(stop=> stop.TransitRouteId == id)
                .OrderBy(stop => stop.Id)
                .ToList();

            if (stops.Count < 2)
            {
                return BadRequest("At least two stops are required.");
            }

            double distance = GeoCalculator.CalculateDistance(stops[0],stops[1]);

            Console.WriteLine($"Distance between Stop 1 and Stop 2 is {distance:F3} km");
            return Json(stops);
        }


        [HttpGet]
        public IActionResult Distance(int stop1Id, int Stop2Id)
        {
            var stop1 = _context.BusStops.Find(stop1Id);
            var stop2 = _context.BusStops.Find(Stop2Id);

            if (stop1 ==null || stop2 == null)
            {
                return NotFound("One or both bus stops were not found.");
            }


            double distance = GeoCalculator.CalculateDistance(stop1, stop2);
            return Json(new
            {
                stop1Id = stop1.Id,
                stop2Id = stop2.Id,
                distanceKm = distance

            });
        }

    }
}