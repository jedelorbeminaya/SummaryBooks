using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummaryBooks.Domain;
using SummaryBooks.Persistence;

namespace SummaryBooks.Web.Controllers
{
    public class SummariesController : Controller
    {
        private readonly DataContext _context;

        public SummariesController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var summaryDb = await _context.Summaries.ToListAsync();
            return View(summaryDb);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var summaryDb = _context.Summaries.Find(id);
            return View(summaryDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Summary model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Summaries.Update(model);
            _context.SaveChanges();
            //return View();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var summaryDb =  _context.Summaries.Find(id);
            return View(summaryDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Summary model)
        {
            _context.Summaries.Remove(model);
            _context.SaveChanges();
            //return View();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
    }
}
