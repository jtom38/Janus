using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Janus.Domain.Entities;
using Janus.Persistence;

namespace Janus.Gui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerIDsController : ControllerBase
    {
        private readonly JanusDbContext _context;

        public ComputerIDsController(JanusDbContext context)
        {
            _context = context;
        }

        // GET: api/ComputerIDs
        [HttpGet]
        public IEnumerable<ComputerID> GetComputerIDs()
        {
            return _context.ComputerIDs;
        }

        // GET: api/ComputerIDs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComputerID([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computerID = await _context.ComputerIDs.FindAsync(id);

            if (computerID == null)
            {
                return NotFound();
            }

            return Ok(computerID);
        }

        // PUT: api/ComputerIDs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputerID([FromRoute] Guid id, [FromBody] ComputerID computerID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computerID.ID)
            {
                return BadRequest();
            }

            _context.Entry(computerID).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerIDExists(id))
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

        // POST: api/ComputerIDs
        [HttpPost]
        public async Task<IActionResult> PostComputerID([FromBody] ComputerID computerID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ComputerIDs.Add(computerID);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputerID", new { id = computerID.ID }, computerID);
        }

        // DELETE: api/ComputerIDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputerID([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computerID = await _context.ComputerIDs.FindAsync(id);
            if (computerID == null)
            {
                return NotFound();
            }

            _context.ComputerIDs.Remove(computerID);
            await _context.SaveChangesAsync();

            return Ok(computerID);
        }

        private bool ComputerIDExists(Guid id)
        {
            return _context.ComputerIDs.Any(e => e.ID == id);
        }
    }
}