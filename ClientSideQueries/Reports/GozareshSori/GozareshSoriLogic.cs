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

        int[] MonthNUmber = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        //Query For Geting Report
        private static string GetSellsData = string.Empty;
        private static string GetBuyData = string.Empty;
        private static string GetRelatedData = string.Empty;

        private readonly IDbConnection _connection;
        public GozareshSoriLogic(IContextHelper context)
        {
            _connection = context.Create();
        }

        public ListResultDTO<GozaresSoriReportModel> GetSum(GozareshSoriFilterModel filter)
        {
            List<GozareshSoriDataModel> data = new List<GozareshSoriDataModel>();


            decimal sum = default;
            List<GozareshSoriDataModel> datamodel = default;
            List<GozaresSoriReportModel> reportmodel = new();


            if (filter.Type == "sells")
                data = _connection.Query<GozareshSoriDataModel>(GetSellsData).ToList();
            else if (filter.Type == "buys")
                data = _connection.Query<GozareshSoriDataModel>(GetBuyData).ToList();


            for (int i = 0; i < MonthNUmber.Length; i++)
            {
                datamodel = new();

                foreach (var item in data)
                {
                    if (MonthNUmber[i] == item.New_Shamsi_Month_Number)
                    {
                        sum += item.New_Profit;
                        datamodel.Add(item);
                    }
                    reportmodel.Add(new GozaresSoriReportModel {Values = sum,Details = datamodel,LastUpdaet=DateTime.Now.ToFarsi(),Shamsi_Month_Name  = MonthNUmber[i].ToString().FarsiMonthName()});
                    datamodel = null;

                }
            }

            if (reportmodel.Count > 0)
                return new ListResultDTO<GozaresSoriReportModel> { Data = reportmodel, Message = "Success", Succss = true };
            else
                return new ListResultDTO<GozaresSoriReportModel> { Data = default, Message = "failer", Succss = false };
        }

        public ListResultDTO<GozaresSoriReportModel> RelatedData(GozareshSoriFilterModel model)
        {
            if (model.Type == "sells")
            {
               GetSellsData += " WHERE MONTHNAME = "
                var data = _connection.Query<GozareshSoriDataModel>(GetSellsData).Select(x => new GozaresSoriReportModel { Values = x.price });

                if (data.Count > 0)
                    return new ResultDTO<GozaresSoriReportModel> { Data = }
            }
            else if(model.Type == "buys")
            {

            }
        }
    }


}
