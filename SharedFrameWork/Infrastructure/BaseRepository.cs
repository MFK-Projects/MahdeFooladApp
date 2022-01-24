using SharedFrameWork.Application;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System;
using System.Linq;

namespace SharedFrameWork.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {


        private readonly IContextHelper _helper;
        private readonly SqlConnection _connection;

        public BaseRepository(IContextHelper helper)
        {
            _helper = helper;
            _connection = helper.Create();

            try
            {
                _connection.Open();
            }
            catch
            {
                throw new Exception($"Error while openin the connection in the {nameof(BaseRepository<TEntity>)}");
            }
        }




        public ResultDTO<long> Create(TEntity model)
        {
            try
            {
                var data = _connection.Insert<TEntity>(model);

                return new ResultDTO<long> { Data = data, Message = "OK", Succss = true };
            }
            catch
            {
                throw new Exception($"Error happend while adding the Entity{nameof(TEntity)}");
            }
        }

        public ListResultDTO<TEntity> GetAll()
        {
            try
            {
                var data = _connection.GetAll<TEntity>().ToList();

                return new ListResultDTO<TEntity> { Data = data, Message = "OK", Succss = true };
            }
            catch
            {
                throw new Exception($"Error happend while adding the Entity{nameof(TEntity)}");
            }
        }

        public ResultDTO<TEntity> GetById(object Id)
        {
            try
            {
                var data = _connection.Get<TEntity>(Id);

                return new ResultDTO<TEntity> { Data = data, Message = "OK", Succss = true };
            }
            catch
            {
                throw new Exception($"Error happend while adding the Entity{nameof(TEntity)}");
            }
        }

        public ResultDTO<bool> Update(TEntity model)
        {
            try
            {
                var data = _connection.Update<TEntity>(model);

                return new ResultDTO<bool> { Data = data, Message = "OK", Succss = true };
            }
            catch
            {
                throw new Exception($"Error happend while Editing the Entity{nameof(TEntity)}");
            }
        }
    }
}
