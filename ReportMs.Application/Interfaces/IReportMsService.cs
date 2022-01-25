using ReportMs.Application.Models;
using ReportMs.Domain.Entities;
using SharedFrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMs.Application.Interfaces
{
    public interface IReportMsService:IBaseRepository<Report>
    {
        ListResultDTO<ReportsViewModel> SearchReports(SearchReportModel model);
    }
}
