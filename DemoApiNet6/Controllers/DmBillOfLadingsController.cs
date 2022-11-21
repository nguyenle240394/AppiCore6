using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApiNet6.Data;
using DemoApiNet6.Domain;

namespace DemoApiNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmBillOfLadingsController : ControllerBase
    {
        private readonly IBillOfLadingRepository _context;

        public DmBillOfLadingsController(IBillOfLadingRepository context)
        {
            this._context = context;
        }

        // GET: api/DmBillOfLadings
        [HttpGet]
        public async Task<IEnumerable<DmBillOfLading>> GetDmBillOfLadings()
        {
            return await _context.GetAll();
        }

       /* // GET: api/DmBillOfLadings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmBillOfLading>> GetDmBillOfLading(string id)
        {
            var dmBillOfLading = await _context.DmBillOfLadings.FindAsync(id);

            if (dmBillOfLading == null)
            {
                return NotFound();
            }

            return dmBillOfLading;
        }

        // PUT: api/DmBillOfLadings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDmBillOfLading(string id, DmBillOfLading dmBillOfLading)
        {
            if (id != dmBillOfLading.ShipKey)
            {
                return BadRequest();
            }

            _context.Entry(dmBillOfLading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DmBillOfLadingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DmBillOfLadings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DmBillOfLading>> PostDmBillOfLading(DmBillOfLading dmBillOfLading)
        {
            _context.DmBillOfLadings.Add(dmBillOfLading);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DmBillOfLadingExists(dmBillOfLading.ShipKey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDmBillOfLading", new { id = dmBillOfLading.ShipKey }, dmBillOfLading);
        }

        // DELETE: api/DmBillOfLadings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDmBillOfLading(string id)
        {
            var dmBillOfLading = await _context.DmBillOfLadings.FindAsync(id);
            if (dmBillOfLading == null)
            {
                return NotFound();
            }

            _context.DmBillOfLadings.Remove(dmBillOfLading);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DmBillOfLadingExists(string id)
        {
            return _context.DmBillOfLadings.Any(e => e.ShipKey == id);
        }*/
    }
}
