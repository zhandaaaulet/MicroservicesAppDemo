using Rebate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebate.API.Repositories.Interfaces
{
    public interface IRebateRepository
    {
        Task<Voucher> GetRebate(string name);
        Task<bool> CreateRebate(Voucher voucher);
        Task<bool> UpdateRebate(Voucher voucher);
        Task<bool> RemoveRebate(string name);
    }
}
