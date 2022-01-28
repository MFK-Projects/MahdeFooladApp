using Dapper;
using SharedFrameWork.Application;
using SharedFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSideQueries.Reports.GozareshSori
{
    public class GozareshSoriLogic
    {

        int[] Gorgeinmonth = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        //Query For Geting Report
        private static string GetAllData = string.Empty;
        private static string GetRelatedData=string.Empty;

        private readonly IDbConnection _connection;
        public GozareshSoriLogic(IContextHelper context)
        {
            _connection = context.Create();
        }

        public ListResultDTO<GozaresSoriReportModel> SumDataByMonth()
        {
            var data = _connection.Query<GozareshSoriDataModel>(GetAllData);
            decimal sum = default;
            List<GozareshSoriDataModel> datamodel = default;
            List<GozaresSoriReportModel> reportmodel = new();



            for (int i = 0; i < Gorgeinmonth.Length; i++)
            {
                datamodel = new();

                foreach (var item in data)
                {
                    if (Gorgeinmonth[i] == item.CreateionOn.Month)
                    {
                        sum += item.price;
                        datamodel.Add(item);
                    }
                    reportmodel.Add(new GozaresSoriReportModel { Details = datamodel, LastUpdaet = DateTime.Now.ToFarsi(), PersianMonthName = item.CreateionOn.ToFarsi().FarsiMonthName(), Values = sum });
                    datamodel = null;

                }
            }

            if (reportmodel.Count > 0)
                return new ListResultDTO<GozaresSoriReportModel> { Data = reportmodel, Message = "Success", Succss = true };
            else
                return new ListResultDTO<GozaresSoriReportModel> { Data = default, Message = "failer", Succss = false };
        }


        public ListResultDTO<GozaresSoriReportModel> RelatedData(string monthname)
        {
            if(string.IsNullOrEmpty(monthname))
            {
                var monthnumber = monthname.ToFarsiMonthNumber();
                var data = _connection.Query<GozareshSoriDataModel>(GetAllData).Select(x => new GozaresSoriReportModel{Values = x.price,});

                if(data.Count > 0)
                    return new ResultDTO<GozaresSoriReportModel> { Data = }
            }
        }
    }


}
