using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class InvGood
    {
        public InvGood()
        {
            BasSupcustGoods = new HashSet<BasSupcustGood>();
        }
        [Key]
        public int Srl { get; set; }
        public string UDateTime { get; set; }
        public string CodeIgd { get; set; }
        public string TitleIgd { get; set; }
        public int? HplSrl { get; set; }
        public int? IbtSrl { get; set; }
        public int? SrlCountry { get; set; }
        public byte? UseType { get; set; }
        public byte? GoodsType { get; set; }
        public virtual InvBrand IbtSrlNavigation { get; set; }
        public virtual BasCountry SrlCountryNavigation { get; set; }
        public virtual ICollection<BasSupcustGood> BasSupcustGoods { get; set; }
    }
}
