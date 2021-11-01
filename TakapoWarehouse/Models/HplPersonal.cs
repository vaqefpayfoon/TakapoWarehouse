using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class HplPersonal
    {
        public HplPersonal()
        {
            IngredientDocs = new HashSet<IngredientDoc>();
        }
        [Key]
        public int Srl { get; set; }
        public string UDateTime { get; set; }
        public string NameHpl { get; set; }
        public string NoHpl { get; set; }
        public string MobileNo { get; set; }
        public string TelNo { get; set; }
        public string AddressHpl { get; set; }
        public string FatherName { get; set; }
        public string UserName { get; set; }
        public string PassCode { get; set; }
        public string MeliCode { get; set; }
        public string IdNo { get; set; }
        public string MailAddress { get; set; }
        public bool? Active { get; set; }
        public string BusinessKind { get; set; }
        public byte? UserPermission { get; set; }
        public byte? Section { get; set; }
        public virtual ICollection<IngredientDoc> IngredientDocs { get; set; }
    }
}
