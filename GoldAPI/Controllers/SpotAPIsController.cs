using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldAPI.Data;
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
        /*[HttpGet]
        public IEnumerable<SpotAPI> GetSpotAPI()
        {
            return _context.SpotAPI;
        }*/
        [HttpGet]
        [Route("")]
        public List<SpotAPI> Get()
        {
            /* var results = new SpotsResult
             {

             };*/
            List<SpotAPI> results = new List<SpotAPI>();

            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                using (var command = connection.CreateCommand())
                {   // ,[dateInput]
      //,[goldVal]
     // ,[silverVal]
     // ,[platiniumVal]
                    command.CommandText = "select id,dateInput,goldVal,silverVal,platiniumVal from archie.dbo.SpotAPItable";
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SpotAPI sp = new SpotAPI();
                            sp.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            sp.dateInput = reader.GetDateTime(reader.GetOrdinal("dateInput"));
                            sp.goldVal = reader.GetDecimal(reader.GetOrdinal("goldVal"));
                            sp.silverVal = reader.GetDecimal(reader.GetOrdinal("silverVal"));
                            sp.platiniumVal = reader.GetDecimal(reader.GetOrdinal("platiniumVal"));
                            //TODO pozostale kolumny
                            results.Add(sp);
                           /* if ((string)reader["vote"] == "a")
                            {
                                results.VoteA = reader.GetInt32(reader.GetOrdinal("votes"));
                            }*/
                            /*else if ((string)reader["vote"] == "b")
                            {
                                results.VoteB = reader.GetInt32(reader.GetOrdinal("votes"));
                            }*/
                        }
                    }
                }
            }

            return results;
        }
        public string ConnectionString
        {
            get
            {
                return new Db().ConnectionString;
            }
        }
        public class SpotsResult
        {
            //public int VoteA { get; set; }
            public List<SpotAPI> listaZbazy { get; set; }
            //public int VoteB { get; set; }
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