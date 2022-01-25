using SharedFrameWork.Application;
using UserMs.Application.Models;
using UserMs.Domain.Entities;

namespace UserMs.Application.Interfaces
{
    public interface IUserService:IBaseRepository<User>
    {
        ListResultDTO<UserViewModel> SearchUser(UserSearchModel model);
    }
}
