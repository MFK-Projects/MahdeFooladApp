using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSideQueries.Reports.GozareshSori
{
    public class GozaresSoriReportModel
    {
        public string LastUpdaet { get; set; }
        public decimal Values { get; set; }
        public string PersianMonthName { get; set; }
        public List<GozareshSoriDataModel> Details { get; set; }
    }
}
