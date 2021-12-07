using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakapoWarehouse.ViewModel
{
    public class IngredientsViewModel
    {
        public int Srl { get; set; }
        public string IngredientsName { get; set; }
        public string GoodsModel { get; set; }
        public string PartNo { get; set; }
        public string StockIngredients { get; set; }
        public string Barcode { get; set; }
    }
    public class SearchViewModel
    {
        [Display(Name = "سریال قطعه")]
        public string PartNo { get; set; }
        [Display(Name = "بارکد")]
        public string Barcode { get; set; }
    }
}
