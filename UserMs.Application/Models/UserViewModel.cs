using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMs.Application.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserCreateignModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserEditModel : UserCreateignModel
    {
        public long Id { get; set; }
    }

    public class UserSearchModel
    {
        public string Name { get; set; }
        public string mobile { get; set; }
    }
}
