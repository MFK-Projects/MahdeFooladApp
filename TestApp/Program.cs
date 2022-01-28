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
{ sumprice = 0;
    }
}

