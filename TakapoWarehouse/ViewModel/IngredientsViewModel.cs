using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakapoWarehouse.ViewModel
{
    public class IngredientsViewModel
    {
        public int Srl { get; set; }
        public string IngredientsName { get; set; }
        public string Model { get; set; }
        public string PartNo { get; set; }
        public int Qty { get; set; }
        public string StockIngredients { get; set; }
        public string barcode { get; set; }
    }
}
