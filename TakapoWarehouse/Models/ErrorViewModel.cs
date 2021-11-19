using System;

namespace TakapoWarehouse.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class KeyValueModel
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
