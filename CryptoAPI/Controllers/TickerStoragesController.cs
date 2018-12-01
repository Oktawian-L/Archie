using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Archie.Models;
using CryptoAPI.Models;

namespace CryptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerStoragesController : ControllerBase
    {
        private readonly CryptoAPIContext _context;

        public TickerStoragesController(CryptoAPIContext context)
        {
            _context = context;
        }

        // GET: api/TickerStorages
        [HttpGet]
        public IEnumerable<TickerStorage> GetTickerStorage()
        {
            return _context.TickerStorage.ToList();
        }

        // GET: api/TickerStorages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTickerStorage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tickerStorage = await _context.TickerStorage.FindAsync(id);

            if (tickerStorage == null)
            {
                return NotFound();
            }

            return Ok(tickerStorage);
        }

        // PUT: api/TickerStorages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickerStorage([FromRoute] int id, [FromBody] TickerStorage tickerStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tickerStorage.Id)
            {
                return BadRequest();
            }

            _context.Entry(tickerStorage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TickerStorageExists(id))
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

        // POST: api/TickerStorages
        [HttpPost]
        public async Task<IActionResult> PostTickerStorage([FromBody] TickerStorage tickerStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TickerStorage.Add(tickerStorage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTickerStorage", new { id = tickerStorage.Id }, tickerStorage);
        }

        // DELETE: api/TickerStorages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickerStorage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tickerStorage = await _context.TickerStorage.FindAsync(id);
            if (tickerStorage == null)
            {
                return NotFound();
            }

            _context.TickerStorage.Remove(tickerStorage);
            await _context.SaveChangesAsync();

            return Ok(tickerStorage);
        }

        private bool TickerStorageExists(int id)
        {
            return _context.TickerStorage.Any(e => e.Id == id);
        }
    }
}