using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using wmdsoftware.Models;

namespace wmdsoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WmdsoftwareContext wmdsoftwareContext;

        public HomeController(ILogger<HomeController> logger, WmdsoftwareContext wmdsoftwareContext)
        {
            _logger = logger;
            this.wmdsoftwareContext = wmdsoftwareContext;           
        }

        public async Task< IActionResult> Index()
        {
            var vst = await wmdsoftwareContext.Visitorregistrations.ToListAsync();
            return View(vst);
           
           
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Visitorregistration visitor)
        {
            if (ModelState.IsValid)
            {
                await wmdsoftwareContext.Visitorregistrations.AddAsync(visitor);
                await wmdsoftwareContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Visitorregistration vst)
        {
            if (id != vst.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                wmdsoftwareContext.Update(vst);
                await wmdsoftwareContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(vst);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || wmdsoftwareContext.Visitorregistrations == null)
            {
                return NotFound();
            }
            var vrsdata = await wmdsoftwareContext.Visitorregistrations.FindAsync(id);
            if (vrsdata == null)
            {
                return NotFound();
            }
            return View(vrsdata);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || wmdsoftwareContext.Visitorregistrations == null)
            {
                return NotFound();
            }
            var stddata = await wmdsoftwareContext.Visitorregistrations.FirstOrDefaultAsync(x => x.Id == id);
            if (stddata == null)
            {
                return NotFound();
            }
            return View(stddata);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, Visitorregistration std)
        {
            var stdData = await wmdsoftwareContext.Visitorregistrations.FindAsync(id);
            if (stdData != null)
            {
                wmdsoftwareContext.Remove(stdData);

            }
            await wmdsoftwareContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null ||wmdsoftwareContext.Visitorregistrations == null)
            {
                return NotFound();
            }
            var empdata = await wmdsoftwareContext.Visitorregistrations.FirstOrDefaultAsync(x => x.Id == id);
            //is mai jo humStudents ko call kr rahe han wo DBset mai se utha rahe h
            if (empdata == null)
            {
                return NotFound();
            }
            return View(empdata);
        }
        public IActionResult Privacy()
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
