using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMs.Application.Models
{
    public class ReportsViewModel
    {
        public string ReportLink { get; set; }
        public string ReportName { get; set; }

    }


    public class SearchReportModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
    }

    public class ReportCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReportLink { get; set; }
        public long UserId { get; set; }
    }
    public class ReportEditModel:ReportCreateModel
    {
        public long ReportId { get; set; }
    }

}
