using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CAVWAApp.Data;
using CAVWAApp.Models;

namespace CAVWAApp.Controllers
{
    public class AppEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppEvents
        public async Task<IActionResult> Index()
        {
              return _context.AppEvent != null ? 
                          View(await _context.AppEvent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AppEvent'  is null.");
        }

        // GET: AppEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppEvent == null)
            {
                return NotFound();
            }

            var appEvent = await _context.AppEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appEvent == null)
            {
                return NotFound();
            }

            return View(appEvent);
        }

        // GET: AppEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Content,DateCreated,DateUpdated,EventDate,Author,ImageUrl")] AppEvent appEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appEvent);
        }

        // GET: AppEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppEvent == null)
            {
                return NotFound();
            }

            var appEvent = await _context.AppEvent.FindAsync(id);
            if (appEvent == null)
            {
                return NotFound();
            }
            return View(appEvent);
        }

        // POST: AppEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Content,DateCreated,DateUpdated,EventDate,Author,ImageUrl")] AppEvent appEvent)
        {
            if (id != appEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppEventExists(appEvent.Id))
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
            return View(appEvent);
        }

        // GET: AppEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppEvent == null)
            {
                return NotFound();
            }

            var appEvent = await _context.AppEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appEvent == null)
            {
                return NotFound();
            }

            return View(appEvent);
        }

        // POST: AppEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppEvent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AppEvent'  is null.");
            }
            var appEvent = await _context.AppEvent.FindAsync(id);
            if (appEvent != null)
            {
                _context.AppEvent.Remove(appEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppEventExists(int id)
        {
          return (_context.AppEvent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
