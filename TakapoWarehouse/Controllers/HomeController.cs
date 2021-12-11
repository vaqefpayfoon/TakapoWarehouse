using Spire.Xls;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakapoWarehouse.Data;
using TakapoWarehouse.Models;
using TakapoWarehouse.ViewModel;
using System;

namespace TakapoWarehouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Takapo_CRMContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger,
            Takapo_CRMContext db,
            IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _db = db;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Excel()
        {
            return View();
        }
        [HttpPost, ActionName("Excel")]
        public IActionResult ExcelFileImport(SearchViewModel model)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var uploads = Path.Combine(webRootPath, "files");
                var extension = Path.GetExtension(HttpContext.Request.Form.Files[0].FileName);
                using (var filesStream = new System.IO.FileStream(Path.Combine(uploads, "excelFile" + extension), FileMode.Create))
                {
                    Workbook workbook = new Workbook();
                    workbook.LoadFromFile(Path.Combine(uploads, "newFile" + extension));
                    Worksheet sheet = workbook.Worksheets[0];
                    int rowCount = sheet.Rows.Length;
                    int cellCount = sheet.Cells.Length;

                    for(int row = 1; row < rowCount; row++)
                    {
                        IngredientsWarehouse ingredient = new IngredientsWarehouse();
                        ingredient.Srl = Convert.ToInt32(sheet[row, 1].Text);
                        ingredient.IngredientsName = sheet[row, 2].Text;
                        ingredient.PartNo = sheet[row, 3].Text;
                        ingredient.Barcode = sheet[row, 4].Text;
                        ingredient.GoodsModel = sheet[row, 5].Text;
                        ingredient.StockIngredients = sheet[row, 6].Text;
                        ingredient.Description = sheet[row, 8].Text;
                        _db.IngredientsWarehouses.Add(ingredient);
                        _db.SaveChanges();
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
