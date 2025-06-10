using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcChair.Models;
using MvcChair.Data;

namespace MvcChair.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcChairContext _context; // ✅ Add this line

        public HomeController(ILogger<HomeController> logger, MvcChairContext context) // ✅ Inject context
        {
            _logger = logger;
            _context = context; // ✅ Assign context
        }

        // GET: Chairs
        public async Task<IActionResult> Index(string chairType, string searchString)
        {
            if (_context.Chair == null)
            {
                return Problem("Entity set 'MvcChairContext.Chair' is null.");
            }

            // LINQ to get list of distinct chair types
            IQueryable<string> typeQuery = from c in _context.Chair
                                           orderby c.Type
                                           select c.Type;

            var chairs = from c in _context.Chair
                         select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                chairs = chairs.Where(s => s.Brand!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(chairType))
            {
                chairs = chairs.Where(x => x.Type == chairType);
            }

            var chairTypeVM = new ChairTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Chairs = await chairs.ToListAsync()
            };

            return View(chairTypeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
