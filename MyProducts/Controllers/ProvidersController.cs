using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyProducts.Models;

namespace MyProducts.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly DataBaseContext _cc;

        public ProvidersController(DataBaseContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            return View(_cc.Providers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Providers p)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = "Поставщик " + p.Name + " добавлен в список";
                _cc.Add(p);
                _cc.SaveChanges();
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Providers provider = _cc.Providers.FirstOrDefault(p => p.Id == id);
                if (provider != null)
                    return View(provider);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Edit(Providers provider)
        {
            if (ModelState.IsValid)
            {
                _cc.Providers.Update(provider);
                _cc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Providers provider = _cc.Providers.FirstOrDefault(p => p.Id == id);
                if (provider != null)
                    return View(provider);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Providers provider = _cc.Providers.FirstOrDefault(p => p.Id == id);
                if (provider != null)
                {
                    _cc.Providers.Remove(provider);
                    _cc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
