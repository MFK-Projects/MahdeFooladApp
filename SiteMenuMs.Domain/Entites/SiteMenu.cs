using SharedFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteMenuMs.Domain.Entites
{
    public class SiteMenu:BaseEntity<Guid>
    {
        public string Titel { get; set; }
        public string Description { get; set; }
        public Guid ParentId { get; set; }
        public List<SiteMenu> SiteMenues { get; set; }
    }
}
