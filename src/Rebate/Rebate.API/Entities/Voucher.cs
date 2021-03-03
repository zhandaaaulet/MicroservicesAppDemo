using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebate.API.Entities
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
