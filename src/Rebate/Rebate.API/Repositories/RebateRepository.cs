using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateRebate(Voucher voucher)
        {
            _db.Vouchers.Add(voucher);
            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<Voucher> GetRebate(string name)
        {
            var rebate = await _db.Vouchers.Where(x => x.Name == name).FirstOrDefaultAsync();
            return rebate;
        }

        public async Task<bool> RemoveRebate(string name)
        {
            var rebate = _db.Vouchers.Where(x => x.Name == name).FirstOrDefault();
            if (rebate != null)
            {
                _db.Vouchers.Remove(rebate);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;


        }

        public async Task<bool> UpdateRebate(Voucher voucher)
        {
            _db.Entry(voucher).State = EntityState.Modified;
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}
