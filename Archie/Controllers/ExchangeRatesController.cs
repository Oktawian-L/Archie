﻿using System;
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
    public class ExchangeRatesController : Controller
    {
        private readonly SyrakuzaContext _context;

        public ExchangeRatesController(SyrakuzaContext context)
        {
            _context = context;
        }

        // GET: ExchangeRates
        public async Task<IActionResult> Index()
        {
            List<ExchangeRate> results = new List<ExchangeRate>();

            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id,dateInput,EUR,GBP,PLN from archie.dbo.ExchangeRates;";
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExchangeRate sp = new ExchangeRate();
                            sp.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            sp.dateInput = reader.GetDateTime(reader.GetOrdinal("dateInput"));
                            //wadliwe typy SQL
                            //sp.EUR= reader.GetDouble(reader.GetOrdinal("EUR"));
                           // sp.GBP = reader.GetDouble(reader.GetOrdinal("GBP"));
                           // sp.PLN = reader.GetDouble(reader.GetOrdinal("PLN"));
                            results.Add(sp);

                        }
                    }
                }
            }
            return View(results);
        }
        public string ConnectionString
        {
            get
            {
                return new Db().ConnectionString;
            }
        }

        // GET: ExchangeRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .SingleOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // GET: ExchangeRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExchangeRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,dateInput,PLN,EUR,GBP")] ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exchangeRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        // GET: ExchangeRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates.SingleOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        // POST: ExchangeRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,dateInput,PLN,EUR,GBP")] ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(exchangeRate.Id))
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
            return View(exchangeRate);
        }

        // GET: ExchangeRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .SingleOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // POST: ExchangeRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exchangeRate = await _context.ExchangeRates.SingleOrDefaultAsync(m => m.Id == id);
            _context.ExchangeRates.Remove(exchangeRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRateExists(int id)
        {
            return _context.ExchangeRates.Any(e => e.Id == id);
        }
    }
}
