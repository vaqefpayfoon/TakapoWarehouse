using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakapoWarehouse.Data;
using TakapoWarehouse.Models;
using TakapoWarehouse.ViewModel;

namespace TakapoWarehouse.Controllers
{
    public class DraftController : Controller
    {
        private readonly Takapo_CRMContext _db;
        public DraftController(Takapo_CRMContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            IngredientsWarehouse find = null;
            if(model.Barcode != null)
            {
                find = _db.IngredientsWarehouses.FirstOrDefault(x => x.Barcode == model.Barcode.Trim());
            }
            if(model.PartNo != null)
            {
                find = _db.IngredientsWarehouses.FirstOrDefault(x => x.PartNo.Contains(model.PartNo.Trim()));
            }
            
            if(find == null)
            {
                return NotFound();
            }

            return RedirectToAction("Docs", new { srl = find.Srl });
        }
        public IActionResult Docs(int srl)
        {
            var find = _db.IngredientsWarehouses.FirstOrDefault(x => x.Srl == srl);
            if (find == null)
                return NotFound();
            if(HttpContext.Session != null)
            {
                ViewBag.Message = HttpContext.Session.GetString("Message");
            }
            else
            {
                ViewBag.Message = "null";
            }
            var detail = _db.IngredientDocs.Where(x => x.IngredientSrl == srl);
            find.IngredientDocs = detail.ToList();
            TempData["IngredientSrl"] = find.Srl;
            //HttpContext.Session.SetInt32("IngredientSrl", find.Srl);
            return View(find.IngredientDocs);
        }
        public IActionResult Enter(int srl)
        {
            IngredientDoc model = _db.IngredientDocs.Where(x => x.IngredientSrl == srl).OrderByDescending(x => x.Srl).FirstOrDefault();
            if (model == null)
            {
                model = new IngredientDoc();
                int maxsrl = _db.IngredientDocs.Max(x => x.Srl) + 1;
                model.Srl = maxsrl;
                model.DocType = 1;
                model.DocDate = DateTime.Now;
                model.IngredientSrl = srl;
                model.HplSrl = 9;
                _db.IngredientDocs.Add(model);
                _db.SaveChanges();
            }
            else
            {
                int maxsrl = _db.IngredientDocs.Max(x => x.Srl) + 1;
                model.Srl = maxsrl;
                if (model.DocType == 1)
                {
                    HttpContext.Session.SetString("Message", "این قطعه حواله خورده است");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "null");
                    model.DocType = 1;
                    model.DocDate = DateTime.Now;
                    model.IngredientSrl = srl;
                    model.HplSrl = 9;
                    _db.IngredientDocs.Add(model);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Docs", new { srl = srl });
        }
        public IActionResult Export(int srl)
        {
            IngredientDoc model = _db.IngredientDocs.Where(x => x.IngredientSrl == srl).OrderByDescending(x => x.Srl).FirstOrDefault();
            if (model == null)
            {
                model = new IngredientDoc();
                int maxsrl = _db.IngredientDocs.Max(x => x.Srl) + 1;
                model.Srl = maxsrl;
                model.DocType = 2;
                model.DocDate = DateTime.Now;
                model.IngredientSrl = srl;
                _db.IngredientDocs.Add(model);
                _db.SaveChanges();
            }
            else
            {
                int maxsrl = _db.IngredientDocs.Max(x => x.Srl) + 1;
                model.Srl = maxsrl;
                if (model.DocType == 2)
                {
                    HttpContext.Session.SetString("Message", "این قطعه حواله خورده است");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "null");
                    model.DocType = 2;
                    model.DocDate = DateTime.Now;
                    model.IngredientSrl = srl;
                    model.HplSrl = 9;
                    _db.IngredientDocs.Add(model);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Docs", new { srl = srl });
        }
        public IActionResult Delete(int id, int srl)
        {
            //var srl = HttpContext.Session.GetInt32("IngredientSrl");
            var item = _db.IngredientDocs.Find(id);
            _db.IngredientDocs.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Docs", new { srl = srl });
        }
    }
}
