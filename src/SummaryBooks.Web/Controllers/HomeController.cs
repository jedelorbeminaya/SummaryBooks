using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummaryBooks.Domain;
using SummaryBooks.Persistence;
using SummaryBooks.Web.Models;
using System.Diagnostics;

namespace SummaryBooks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Summary model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Summaries.Add(model);
            _context.SaveChanges();
            //return View();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
