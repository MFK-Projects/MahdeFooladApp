using SharedFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMs.Domain.Entities
{
    public class User : BaseEntity<long>
    {
        public string Name { get; set; }
        public string UserName { get; set; }    
        public string password { get; set; }
        public string PictureName { get; set; }
    }


    public class Role : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }


    public class UserRole
    {
        public long UserId { get; set; }
        public int RoelId { get; set; }
    }
}
