using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedFrameWork.Application
{
    public class ResultDTO<TEntity>
    {
        public string Message { get; set; }
        public bool Succss { get; set; }
        public TEntity Data { get; set; }
    }

    public class ListResultDTO<TEntity> : ResultDTO<TEntity>
    {
        new public List<TEntity> Data { get; set; }
    }
}
