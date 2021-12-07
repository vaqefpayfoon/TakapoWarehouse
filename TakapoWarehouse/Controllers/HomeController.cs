﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TakapoWarehouse.Data;
using TakapoWarehouse.Models;

namespace TakapoWarehouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Takapo_CRMContext _db;
        public HomeController(ILogger<HomeController> logger,
            Takapo_CRMContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IngredientsWarehouse model)
        {
            int max = _db.IngredientsWarehouses.Max(field => field.Srl);
            model.Srl = max + 1;
            model.Barcode = model.Barcode.Trim();
            _db.IngredientsWarehouses.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int srl)
        {
            var item = _db.IngredientsWarehouses.FirstOrDefault(x => x.Srl == srl);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(IngredientsWarehouse model)
        {
            model.Barcode = model.Barcode.Trim();
            _db.IngredientsWarehouses.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
