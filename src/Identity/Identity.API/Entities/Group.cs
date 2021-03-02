using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
