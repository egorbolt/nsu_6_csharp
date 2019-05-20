using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab4_worker_ui.Data;
using Lab4Worker.UI.DB;

namespace lab4_worker_ui.Controllers
{
    public class ConnectionTablesController : Controller
    {
        private readonly ApplicationContext _context;

        public ConnectionTablesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ConnectionTables
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ConnectionTables.Include(c => c.Project).Include(c => c.Worker);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ConnectionTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectionTable = await _context.ConnectionTables
                .Include(c => c.Project)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.ConnectionTableID == id);
            if (connectionTable == null)
            {
                return NotFound();
            }

            return View(connectionTable);
        }

        // GET: ConnectionTables/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID");
            ViewData["WorkerID"] = new SelectList(_context.Workers, "WorkerID", "WorkerID");
            return View();
        }

        // POST: ConnectionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConnectionTableID,WorkerID,ProjectID")] ConnectionTable connectionTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(connectionTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", connectionTable.ProjectID);
            ViewData["WorkerID"] = new SelectList(_context.Workers, "WorkerID", "WorkerID", connectionTable.WorkerID);
            return View(connectionTable);
        }

        // GET: ConnectionTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectionTable = await _context.ConnectionTables.FindAsync(id);
            if (connectionTable == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", connectionTable.ProjectID);
            ViewData["WorkerID"] = new SelectList(_context.Workers, "WorkerID", "WorkerID", connectionTable.WorkerID);
            return View(connectionTable);
        }

        // POST: ConnectionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConnectionTableID,WorkerID,ProjectID")] ConnectionTable connectionTable)
        {
            if (id != connectionTable.ConnectionTableID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connectionTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectionTableExists(connectionTable.ConnectionTableID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", connectionTable.ProjectID);
            ViewData["WorkerID"] = new SelectList(_context.Workers, "WorkerID", "WorkerID", connectionTable.WorkerID);
            return View(connectionTable);
        }

        // GET: ConnectionTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectionTable = await _context.ConnectionTables
                .Include(c => c.Project)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.ConnectionTableID == id);
            if (connectionTable == null)
            {
                return NotFound();
            }

            return View(connectionTable);
        }

        // POST: ConnectionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var connectionTable = await _context.ConnectionTables.FindAsync(id);
            _context.ConnectionTables.Remove(connectionTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectionTableExists(int id)
        {
            return _context.ConnectionTables.Any(e => e.ConnectionTableID == id);
        }
    }
}
