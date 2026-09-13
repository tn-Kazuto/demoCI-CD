using Microsoft.AspNetCore.Mvc;
using milesmorales_mvc.Models;
using milesmorales_mvc.Services;

namespace milesmorales_mvc.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        // GET: ColorController
        public ActionResult Index()
        {
            return View(colorService.GetColors());
        }

        // GET: ColorController/Details/5
        public ActionResult Details(int id)
        {
            var color = colorService.GetColorById(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // GET: ColorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Color color)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(color);
                }

                colorService.CreateColor(color);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(color);
            }
        }

        // GET: ColorController/Edit/5
        public ActionResult Edit(int id)
        {
            var color = colorService.GetColorById(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: ColorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Color colorToUpdate)
        {
            try
            {
                if (id != colorToUpdate.ColorId)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return View(colorToUpdate);
                }

                if (!colorService.UpdateColor(colorToUpdate))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(colorToUpdate);
            }
        }

        // GET: ColorController/Delete/5
        public ActionResult Delete(int id)
        {
            var color = colorService.GetColorById(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: ColorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Color colorToDelete)
        {
            try
            {
                colorService.DeleteColor(colorToDelete.ColorId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(colorToDelete);
            }
        }
    }
}
