using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class InvBrand
    {
        public InvBrand()
        {
            InvGoods = new HashSet<InvGood>();
        }
        [Key]
        public int Srl { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<InvGood> InvGoods { get; set; }
    }
}
