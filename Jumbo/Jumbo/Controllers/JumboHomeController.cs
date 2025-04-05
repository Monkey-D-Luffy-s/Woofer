using AutoMapper;
using Jumbo.Data;
using Jumbo.Modals;
using Jumbo.Modals.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Jumbo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JumboHomeController : ControllerBase
    {
        private readonly WooferDbContext woofer;
        private readonly IMapper mapper;

        public JumboHomeController(WooferDbContext _woofer, IMapper _mapper)
        {
            woofer = _woofer;
            mapper = _mapper;
        }
        [HttpGet]
        [Route("getTest")]
        public async Task<IActionResult> GetTestAsync()
        {
            List<Woofer> woofs = await woofer.Woofers.ToListAsync();

            if (woofs.Count == 0) 
            {
                return Ok("no woofers found");
            }
            return Ok(woofs);
        }

        [HttpGet]
        [Route("getSingle/{id}")]
        public async Task<IActionResult> GetSingleAsync([FromRoute] Guid id)
        {
            Woofer woofs = await woofer.Woofers.FirstOrDefaultAsync(w => w.Id == id);

            if (woofs == null)
            {
                return Ok("no woofers found");
            }
            return Ok(woofs);
        }

        [HttpPost]
        [Route("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] AddWoofDTO woofDTO)
        {
            Woofer woof = mapper.Map<Woofer>(woofDTO);
            await woofer.Woofers.AddAsync(woof);
            await woofer.SaveChangesAsync();

            return Ok(woofDTO);
        }

        [HttpPost]
        [Route("UpdateTest/{Id}")]
        public async Task<IActionResult> UpdateTest([FromBody] AddWoofDTO woofDTO, [FromRoute] Guid Id)
        {
            //Woofer woof = mapper.Map<Woofer>(woofDTO);
            Woofer woofs = await woofer.Woofers.FirstOrDefaultAsync(w => w.Id == Id);
            if (woofs == null)
                return NotFound("Woofer not found.");
            mapper.Map(woofDTO, woofs);
            await woofer.SaveChangesAsync();
            Woofer getWoof = await woofer.Woofers.FirstOrDefaultAsync(w => w.Id == Id);
            return Ok(getWoof);
        }
    }
}
