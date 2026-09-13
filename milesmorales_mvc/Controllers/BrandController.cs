using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using milesmorales_mvc.Models;

namespace milesmorales_mvc.Controllers
{
    public class BrandController : Controller
    {
        private readonly MilesmoralesDBContextcs milescontext;

        public BrandController(MilesmoralesDBContextcs milescontext)
        {
            this.milescontext = milescontext;
        }

        // GET: BrandController
        public async Task<ActionResult> Index()
        {
            var brands = await milescontext.Brands.ToListAsync();
            return View(brands);
        }

        // GET: BrandController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var brand = await milescontext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            milescontext.Brands.Add(brand);
            await milescontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: BrandController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var brand = await milescontext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Brand brandToUpdate)
        {
            if (id != brandToUpdate.BrandId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(brandToUpdate);
            }

            var existingBrand = await milescontext.Brands.FindAsync(id);
            if (existingBrand == null)
            {
                return NotFound();
            }

            existingBrand.BrandName = brandToUpdate.BrandName;
            await milescontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: BrandController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await milescontext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Brand brandToDelete)
        {
            var brand = await milescontext.Brands.FindAsync(brandToDelete.BrandId);
            if (brand == null)
            {
                return RedirectToAction(nameof(Index));
            }

            milescontext.Brands.Remove(brand);
            await milescontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
