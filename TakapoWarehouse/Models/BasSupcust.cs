using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class BasSupcust
    {
        public BasSupcust()
        {
            BasSupcustGoods = new HashSet<BasSupcustGood>();
        }
        [Key]
        public int Srl { get; set; }
        public string UDateTime { get; set; }
        public string SupcustCode { get; set; }
        public string SupcustName { get; set; }
        public string RelatedPerson { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax1 { get; set; }
        public string EconomicNo { get; set; }
        public string IdNo { get; set; }
        public string RegisterNo { get; set; }
        public string PostCode { get; set; }
        public int? TypeSrl { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Address1 { get; set; }
        public string EMail { get; set; }
        public string WebAdr { get; set; }
        public string Describe { get; set; }
        public string MobileNo { get; set; }
        public int? SrlCountry { get; set; }
        public int? SrlCity { get; set; }

        public virtual BasCity SrlCityNavigation { get; set; }
        public virtual BasCountry SrlCountryNavigation { get; set; }
        public virtual BasSupcustType TypeSrlNavigation { get; set; }
        public virtual ICollection<BasSupcustGood> BasSupcustGoods { get; set; }
    }
}
