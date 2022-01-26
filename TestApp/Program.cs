using CsvHelper;
using System.Globalization;



List<TestModel> records = new();

using (var reader = new StreamReader(@"D:\sales_data_sample.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{    
    records=csv.GetRecords<TestModel>().ToList();
    SumData(records);
}



void SumData(List<TestModel> datas)
{
    int[] Gorgeinmonth = {1,3,4,5,6,7,8,9,10,11,12};
    decimal sumprice = 0;
    List<OperationModel> omodel = new List<OperationModel>();
    List<TestModel> testmodel = new List<TestModel>();


    for (int i = 1; i <= Gorgeinmonth.Count(); i++)
    {
        foreach (var data in datas)
        {
            if (i == data.ORDERDATE.Month)
            {
                sumprice += data.PRICEEACH;
                testmodel.Add(data);
            }
        }
        omodel.Add(new OperationModel { value = sumprice,model = testmodel,month = i });
        sumprice = 0;
    }
}


public class TestModel {

    public string PRODUCTLINE { get; set; }
    public decimal PRICEEACH { get; set; }
    public DateTime ORDERDATE { get; set; }
    public long ORDERNUMBER { get; set; }
}

public class OperationModel
{
    public int month { get; set; }
    public decimal value { get; set; }
    public List<TestModel> model { get; set; }
    public string[] persiandate { get; set; }
}


