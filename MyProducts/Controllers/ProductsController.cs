using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProducts.Models;

namespace MyProducts.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataBaseContext _cc;

        public ProductsController(DataBaseContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            return View(_cc.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products p)
        {
            if (p.AddDate == null)
            {
                p.AddDate = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                ViewBag.name = "Товар " + p.Name + " добавлен в список";

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
                Products product = _cc.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                _cc.Products.Update(product);
                _cc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Products product =  _cc.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Products product = _cc.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    _cc.Products.Remove(product);
                    _cc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}