using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rebate.API.Entities;
using Rebate.API.Repositories.Interfaces;

namespace Rebate.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RebateController : ControllerBase
    {
        private readonly IRebateRepository _rebateRepository;

        public RebateController(IRebateRepository rebateRepository)
        {
            _rebateRepository = rebateRepository;
        }

        [HttpGet("{name}", Name = "GetRebate")]
        [ProducesResponseType(typeof(Voucher), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Voucher>> GetRebate(string name)
        {
            var rebate = await _rebateRepository.GetRebate(name);
            return Ok(rebate);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Voucher), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Voucher>> CreateRebate([FromBody] Voucher voucher)
        {
            await _rebateRepository.CreateRebate(voucher);
            return CreatedAtRoute("GetRebate", new { name = voucher.Name }, voucher);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Voucher), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Voucher>> UpdateBasket([FromBody] Voucher voucher)
        {
            return Ok(await _rebateRepository.UpdateRebate(voucher));
        }

        [HttpDelete("{name}", Name = "RemoveRebate")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string name)
        {
            return Ok(await _rebateRepository.RemoveRebate(name));
        }
    }
}
