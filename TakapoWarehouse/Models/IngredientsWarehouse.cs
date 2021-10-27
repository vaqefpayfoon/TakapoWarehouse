using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class IngredientsWarehouse
    {
        [Key]
        public int Srl { get; set; }
        public string IngredientsName { get; set; }
        public string Model { get; set; }
        public string PartNo { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public string StockIngredients { get; set; }
        public string barcode { get; set; }
    }
}
