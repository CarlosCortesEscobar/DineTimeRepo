#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DineTime.Models;

namespace DineTime.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly DineTimeDbContext _context;

        public ReservationsController(DineTimeDbContext context)
        {
            _context = context;
        }

        public IActionResult FieriReservation()
        {

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");
            return View();
        }
        public IActionResult SantanaReservation()
        {

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");
            return View();
        }

        public IActionResult LaCasaReservation()
        {

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");
            return View();
        }


        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var dineTimeDbContext = _context.Reservations.Include(r => r.Client).Include(r => r.Restaurant);
            return View(await dineTimeDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");

            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,RestaurantId,ClientId,ReservationTime,ReservationDate,NumberInParty")] Reservation reservation)
        {

            reservation.ReservationTime = reservation.ReservationDate.TimeOfDay;




            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");
            return View(reservation);
            

        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", reservation.ClientId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", reservation.RestaurantId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,RestaurantId,ClientId,ReservationTime,ReservationDate,NumberInParty")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", reservation.ClientId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", reservation.RestaurantId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        public IActionResult ReservationError()
        {
            return View();
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
