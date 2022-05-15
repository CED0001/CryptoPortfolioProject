#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoPortfolio.Data;
using CryptoPortfolio.Models;

namespace CryptoPortfolio.Controllers
{
    public class CoinGeckoCoinsController : Controller
    {
        private readonly CryptoPortfolioContext _context;

        public CoinGeckoCoinsController(CryptoPortfolioContext context)
        {
            _context = context;
        }

        // GET: CoinGeckoCoins
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.CoinGeckoCoin.ToListAsync());
        //}

        // GET: CoinGeckoCoins/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var coinGeckoCoin = await _context.CoinGeckoCoin
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (coinGeckoCoin == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(coinGeckoCoin);
        //}

        // GET: CoinGeckoCoins/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: CoinGeckoCoins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,CoinGeckoId,Symbol,CoinGeckoName")] CoinGeckoCoin coinGeckoCoin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(coinGeckoCoin);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(coinGeckoCoin);
        //}

        // GET: CoinGeckoCoins/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var coinGeckoCoin = await _context.CoinGeckoCoin.FindAsync(id);
        //    if (coinGeckoCoin == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(coinGeckoCoin);
        //}

        // POST: CoinGeckoCoins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CoinGeckoId,Symbol,CoinGeckoName")] CoinGeckoCoin coinGeckoCoin)
        //{
        //    if (id != coinGeckoCoin.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(coinGeckoCoin);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CoinGeckoCoinExists(coinGeckoCoin.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(coinGeckoCoin);
        //}

        // GET: CoinGeckoCoins/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var coinGeckoCoin = await _context.CoinGeckoCoin
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (coinGeckoCoin == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(coinGeckoCoin);
        //}

        // POST: CoinGeckoCoins/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var coinGeckoCoin = await _context.CoinGeckoCoin.FindAsync(id);
        //    _context.CoinGeckoCoin.Remove(coinGeckoCoin);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CoinGeckoCoinExists(int id)
        {
            return _context.CoinGeckoCoin.Any(e => e.Id == id);
        }
    }
}
