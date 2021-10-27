using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class BasSupcustType
    {
        public BasSupcustType()
        {
            BasSupcusts = new HashSet<BasSupcust>();
        }
        [Key]
        public int Srl { get; set; }
        public string SupcustType { get; set; }

        public virtual ICollection<BasSupcust> BasSupcusts { get; set; }
    }
}
