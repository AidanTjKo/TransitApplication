using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SQLitePCL;
using TransitApplication.Models;
using TransitApplication.Data;


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


    }
}