using Dapper;
using ReportMs.Application.Common;
using ReportMs.Application.Interfaces;
using ReportMs.Application.Models;
using ReportMs.Domain.Entities;
using SharedFrameWork.Application;
using SharedFrameWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMs.Infrastructure.Impelemention
{
    public class ReportMsService : BaseRepository<Report>, IReportMsService
    {
        private readonly IContextHelper _helper;
        private readonly IDbConnection _connection;

        public ReportMsService(IContextHelper helper)
            : base(helper)
        {
            _helper = helper;
            _connection = helper.Create();


            try
            {
                _connection.Open();
            }
            catch
            {
                throw new Exception($"Error occured while opening the connection in the {nameof(ReportMsService)}");
            }
        }

        public ListResultDTO<ReportsViewModel> SearchReports(SearchReportModel model)
        {
            List<ReportsViewModel> data = new();

            var paramters = new DynamicParameters();
            paramters.Add("@Name", model.Name);
            paramters.Add("@UserName", model.UserName);
            paramters.Add("@CategoryName", model.CategoryName);

            if (_connection.State == ConnectionState.Open)
            {
                data = _connection.Query<ReportsViewModel>(SqlQueries.SearchQuery, paramters).ToList();

                if (data.Count > 0)
                    return new ListResultDTO<ReportsViewModel> { Data = data, Message = "OK", Succss = true };
                else
                    return new ListResultDTO<ReportsViewModel> { Data = null, Message = "There is no Data Found in the Server" };
            }
            else
                return new ListResultDTO<ReportsViewModel> { Data = null, Succss = false, Message = $"the Connection is not Open in the {nameof(SearchReports)}" };

        }
    }
}
