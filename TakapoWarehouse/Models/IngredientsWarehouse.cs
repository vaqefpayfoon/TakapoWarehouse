using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class IngredientsWarehouse
    {
        public IngredientsWarehouse()
        {
            IngredientDocs = new HashSet<IngredientDoc>();
        }
        [Key]
        public int Srl { get; set; }
        [Display(Name = "نام قطعه")]
        public string IngredientsName { get; set; }
        [Display(Name = "مدل")]
        public string GoodsModel { get; set; }
        public string PartNo { get; set; }
        [Display(Name = "تعداد")]
        public int Qty { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "آدرس")]
        public string StockIngredients { get; set; }
        [Display(Name = "بارکد")]
        public string Barcode { get; set; }
        [Display(Name = "سریال قطعه")]
        public string SerialNo { get; set; }
        public virtual ICollection<IngredientDoc> IngredientDocs { get; set; }
    }
    public class IngredientDoc
    {
        [Key]
        public int Srl { get; set; }
        public int HplSrl { get; set; }
        public int IngredientSrl { get; set; }
        public DateTime DocDate { get; set; }
        public string Description { get; set; }
        public int DocType { get; set; }
        public virtual HplPersonal SrlPersonalNavigation { get; set; }
        public virtual IngredientsWarehouse SrlIngredientsWarehouseNavigation { get; set; }
    }
}
