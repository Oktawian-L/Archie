using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SpotAPIs")]
    public class SpotAPIsController : Controller
    {
        private readonly CatalogContext _context;

        public SpotAPIsController(CatalogContext context)
        {
            _context = context;
        }

        // GET: api/SpotAPIs
        [HttpGet]
        public IEnumerable<SpotAPI> GetSpotAPI()
        {
            return _context.SpotAPI;
        }

        // GET: api/SpotAPIs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotAPI([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spotAPI = await _context.SpotAPI.SingleOrDefaultAsync(m => m.Id == id);

            if (spotAPI == null)
            {
                return NotFound();
            }

            return Ok(spotAPI);
        }

        // PUT: api/SpotAPIs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpotAPI([FromRoute] int id, [FromBody] SpotAPI spotAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spotAPI.Id)
            {
                return BadRequest();
            }

            _context.Entry(spotAPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotAPIExists(id))
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

        // POST: api/SpotAPIs
        [HttpPost]
        public async Task<IActionResult> PostSpotAPI([FromBody] SpotAPI spotAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SpotAPI.Add(spotAPI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpotAPI", new { id = spotAPI.Id }, spotAPI);
        }

        // DELETE: api/SpotAPIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpotAPI([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spotAPI = await _context.SpotAPI.SingleOrDefaultAsync(m => m.Id == id);
            if (spotAPI == null)
            {
                return NotFound();
            }

            _context.SpotAPI.Remove(spotAPI);
            await _context.SaveChangesAsync();

            return Ok(spotAPI);
        }

        private bool SpotAPIExists(int id)
        {
            return _context.SpotAPI.Any(e => e.Id == id);
        }
    }
}