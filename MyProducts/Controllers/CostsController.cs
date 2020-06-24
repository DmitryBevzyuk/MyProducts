using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyProducts.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Controllers
{
    public class CostsController : Controller
    {
        private readonly DataBaseContext _cc;

        public CostsController(DataBaseContext cc)
        {
            _cc = cc;
        }

        public IActionResult Index()
        {
            return View(_cc.Costs.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Costs c)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = "Товар с кодом " + c.ProductId + " добавлен в таблицу реализации";
                _cc.Add(c);
                _cc.SaveChanges();
                return View();
            }
            else
                return View();
        }

        public IActionResult Revenue()
        {
            var a = _cc.PriceList.Join(_cc.Costs,
            p => p.Id,
            c => c.ProductId,
            (p, c) => new
               {
                p.StartPrice,
                c.Volume,
                p.EndPrice,
                c.Cost,
                c.Id
                });

            ViewModelRevenueList vm = new ViewModelRevenueList();
            var myList = a.ToList();

            foreach (var item in myList)
            {
                vm.Add(item.StartPrice, item.EndPrice, item.Cost, item.Volume, item.Id);
            }
            ViewBag.Revenue = vm.getAllRevenue();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Costs cost = _cc.Costs.FirstOrDefault(p => p.Id == id);
                if (cost != null)
                    return View(cost);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Edit(Costs costs)
        {
            if (ModelState.IsValid)
            {
                _cc.Costs.Update(costs);
                _cc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(costs);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Costs cost = _cc.Costs.FirstOrDefault(p => p.Id == id);
                if (cost != null)
                    return View(cost);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Costs cost = _cc.Costs.FirstOrDefault(p => p.Id == id);
                if (cost != null)
                {
                    _cc.Costs.Remove(cost);
                    _cc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
