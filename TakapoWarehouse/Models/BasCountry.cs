using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class BasCountry
    {
        public BasCountry()
        {
            BasSupcusts = new HashSet<BasSupcust>();
            InvGoods = new HashSet<InvGood>();
        }
        [Key]
        public int Srl { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<BasSupcust> BasSupcusts { get; set; }
        public virtual ICollection<InvGood> InvGoods { get; set; }
    }
}
