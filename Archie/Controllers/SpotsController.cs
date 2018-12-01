using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Archie.Data;
using Archie.Models;

namespace Archie.Controllers
{
    public class SpotsController : Controller
    {
        private readonly SyrakuzaContext _context;

        public SpotsController(SyrakuzaContext context)
        {
            _context = context;
        }

        // GET: Spots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spots.ToListAsync());
        }

        // GET: Spots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spots
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // GET: Spots/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Diagram()
        {
            return View(await _context.Spots.ToListAsync());
        }
        public IActionResult newView()
        {
            return View();
        }
        public IActionResult XList()
        {
            //przekaznaie modelu danych do widoku, typ = lista
            var cenySpot = new[]
            {
              new Models.Spots()
              {
                dateInput = System.DateTime.Now,
                goldVal = 13,
                silverVal = 16,
                platiniumVal = 66
               },
             new Models.Spots()
              {
                dateInput = System.DateTime.Now,
                goldVal = 13,
                silverVal = 16,
                platiniumVal = 66
               }

            };
        
            return View(cenySpot);
        }


        // POST: Spots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,dateInput,goldVal,silverVal,platiniumVal")] Spots spot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spot);
        }

        // GET: Spots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spots.SingleOrDefaultAsync(m => m.Id == id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }

        // POST: Spots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,dateInput,goldVal,silverVal,platiniumVal")] Spots spot)
        {
            if (id != spot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotExists(spot.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(spot);
        }

        // GET: Spots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spots
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // POST: Spots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spot = await _context.Spots.SingleOrDefaultAsync(m => m.Id == id);
            _context.Spots.Remove(spot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotExists(int id)
        {
            return _context.Spots.Any(e => e.Id == id);
        }
    }
}
