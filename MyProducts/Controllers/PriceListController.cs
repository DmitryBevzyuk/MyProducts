using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProducts.Models;

namespace MyProducts.Controllers
{
    public class PriceListController : Controller
    {
        private readonly DataBaseContext _cc;

        public PriceListController(DataBaseContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            return View(_cc.PriceList.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PriceList p)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = "Товар с кодом " + p.ProductId + " добавлен в прайс лист";
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
                PriceList priceList = _cc.PriceList.FirstOrDefault(p => p.Id == id);
                if (priceList != null)
                    return View(priceList);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Edit(PriceList priceList)
        {
            if (ModelState.IsValid)
            {
                _cc.PriceList.Update(priceList);
                _cc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(priceList);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                PriceList priceList = _cc.PriceList.FirstOrDefault(p => p.Id == id);
                if (priceList != null)
                    return View(priceList);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                PriceList priceList = _cc.PriceList.FirstOrDefault(p => p.Id == id);
                if (priceList != null)
                {
                    _cc.PriceList.Remove(priceList);
                    _cc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
