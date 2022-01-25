using Dapper;
using SharedFrameWork.Application;
using SharedFrameWork.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UserMs.Application.Common;
using UserMs.Application.Interfaces;
using UserMs.Application.Models;
using UserMs.Domain.Entities;

namespace UserMs.Infrastructure.Impelementions
{
    public class UserService : BaseRepository<User>, IUserService
    {
        private readonly IContextHelper _helper;
        private readonly IDbConnection _connection;

        public UserService(IContextHelper context)
            : base(context)
        {
            _helper = context;
            _connection = _helper.Create();


            try
            {
                _connection.Open();
            }
            catch
            {

                throw new System.Exception($"Error ouccer while opening Connection at {nameof(UserService)}");
            }
        }

        public ListResultDTO<UserViewModel> SearchUser(UserSearchModel model)
        {
            List<UserViewModel> data = new();

            var parameters = new DynamicParameters();

            parameters.Add("@Name", model.Name);
            parameters.Add("@RoleName", model.RoleName);


            if (_connection.State == ConnectionState.Open)
            {
                data = _connection.Query<UserViewModel>(SqlQueries.SearchQuery, parameters).ToList();

                if (data.Count > 0)
                    return new ListResultDTO<UserViewModel> { Data = data, Message = "Ok", Succss = true };
                else
                    return new ListResultDTO<UserViewModel> { Data = null, Message = "Not Found Data", Succss = true };
            }
            else
                return new ListResultDTO<UserViewModel> { Data = null, Message = "Connection was not open in this request!" ,Succss= false};
        }
    }
}
