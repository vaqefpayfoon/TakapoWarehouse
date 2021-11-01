using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakapoWarehouse.Data;
using TakapoWarehouse.Models;
using TakapoWarehouse.ViewModel;

namespace TakapoWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Takapo_CRMContext _db;
        public WarehouseController(ILogger<HomeController> logger,
                              Takapo_CRMContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult GetAll()
        {
            var result =  _db.IngredientsWarehouses.ToList().OrderByDescending(Srl => Srl.Srl);
            var next = result.Select(a => new IngredientsViewModel { Srl = a.Srl, IngredientsName =  a.IngredientsName, GoodsModel = a.GoodsModel, PartNo = a.PartNo, StockIngredients = a.StockIngredients, Barcode = a.Barcode });
            return Json(new { data = next});
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int srl)
        {
            var ingredient = await _db.IngredientsWarehouses.FirstOrDefaultAsync(u => u.Srl == srl);
            if (ingredient == null)
            {
                return Json(new { success = false, message = "نشد پاک کنم" });
            }
            _db.IngredientsWarehouses.Remove(ingredient);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "خیالت راحت پاک شد" });
        }
    }
}
