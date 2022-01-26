using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.TestSelligData
{
    public class Model<TEntity>
        where TEntity : class
    {
        public TEntity entity { get; set; }
        public decimal SALES { get; set; }
        public DateTime ORDERDATEORDERDATE { get; set; }
    }

    public class Product
    {
        public string PRODUCTLINE { get; set; }
        public string ORDERNUMBER { get; set; }
    }
}
