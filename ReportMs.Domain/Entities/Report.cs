using SharedFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMs.Domain.Entities
{
    public class Report: BaseEntity<long>
    {
        public string Name { get; set; }
        public string ReportLink { get; set; }
        public string Description { get; set; }
    }
}
