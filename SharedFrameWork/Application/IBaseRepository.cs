using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedFrameWork.Application
{
    public interface IBaseRepository<TEntity>
    {
        ResultDTO<long> Create(TEntity model);
        ResultDTO<bool> Update(TEntity model);
        ResultDTO<TEntity> GetById(object Id);
        ListResultDTO<TEntity> GetAll();
    }
}
