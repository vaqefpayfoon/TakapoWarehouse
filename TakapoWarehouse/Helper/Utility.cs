using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakapoWarehouse.Helper
{
    public static class Utility
    {
        public static string ToPersianDateTime(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);
            return year + "/" + month + "/" + day;
        }
    }
}
