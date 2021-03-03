using Microsoft.EntityFrameworkCore;
using Rebate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebate.API.Data
{
    public class RebateContext : DbContext
    {
        public RebateContext(DbContextOptions<RebateContext> options) : base(options)
        {

        }

        public DbSet<Voucher> Vouchers { get; set; }
    }
}
