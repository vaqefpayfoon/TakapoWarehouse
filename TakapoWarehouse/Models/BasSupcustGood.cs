using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TakapoWarehouse.Models
{
    public partial class BasSupcustGood
    {
        [Key]
        public int Srl { get; set; }
        public int BasscSrl { get; set; }
        public int IgdSrl { get; set; }
        public string Serial { get; set; }
        public string Model { get; set; }
        public string FileNo { get; set; }
        public string DeviceLocate { get; set; }
        public string InstallDate { get; set; }
        public string RelatedPerson { get; set; }
        public string Occupation { get; set; }
        public string CellPhone { get; set; }
        public string Tel { get; set; }
        public string Describe { get; set; }
        public string MoveDeviceDate { get; set; }

        public virtual BasSupcust BasscSrlNavigation { get; set; }
        public virtual InvGood IgdSrlNavigation { get; set; }
    }
}
