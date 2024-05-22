using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarHub.Models;
using CarHub.Data;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;

namespace CarHub.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars for buyers; should not see cars that are not available
        public async Task<IActionResult> Index()
        {
            var availableCars = await _context.CarViewModel.Where( x => (x.Available)).ToListAsync();
            return View(availableCars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.CarViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [Authorize]
        // GET: Cars for Admin View
        public async Task<IActionResult> Admin()
        {
            return View(await _context.CarViewModel.ToListAsync());
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile? img, [Bind("Id,Make,Model,Year,Trim,PurchaseDate,PurchasePrice,Repairs,RepairCost,LotDate,SellingPrice,SaleDate,Available")] CarViewModel car)
        {
            if (img != null)
            {
                // Convert the uploaded image to a byte array
                byte[]? imageBytes;
                using (var stream = new MemoryStream())
                {
                    await img.CopyToAsync(stream);
                    imageBytes = stream.ToArray();
                }

                car.Image = imageBytes;
            }
            else
            {
                car.Image = Array.Empty<byte>();
            }

            if (ModelState.IsValid)
            {

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Admin));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.CarViewModel.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile? img, [Bind("Id,Make,Model,Year,Trim,PurchaseDate,PurchasePrice,Repairs,RepairCost,LotDate,SellingPrice,SaleDate,Available")] CarViewModel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (img != null) 
            {
                // Convert the uploaded image to a byte array
                byte[]? imageBytes;
                using (var stream = new MemoryStream())
                {
                    await img.CopyToAsync(stream);
                    imageBytes = stream.ToArray();
                }

                car.Image = imageBytes;
            }
            else
            {
                car.Image = Array.Empty<byte>();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Admin));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.CarViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: CarViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.CarViewModel.FindAsync(id);
            if (car != null)
            {
                _context.CarViewModel.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.CarViewModel.Any(e => e.Id == id);
        }
    }
}
