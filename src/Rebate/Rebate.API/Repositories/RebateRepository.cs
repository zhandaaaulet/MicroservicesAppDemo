using Rebate.API.Data;
using Rebate.API.Entities;
using Rebate.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebate.API.Repositories
{
    public class RebateRepository : IRebateRepository
    {
        private readonly RebateContext _db;

        public RebateRepository(RebateContext db)
        {
            _db = db;
        }

        public Task<bool> CreateRebate(Voucher voucher)
        {
            throw new NotImplementedException();
        }

        public Task<Voucher> GetRebate(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRebate(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRebate(Voucher voucher)
        {
            throw new NotImplementedException();
        }
    }
}
