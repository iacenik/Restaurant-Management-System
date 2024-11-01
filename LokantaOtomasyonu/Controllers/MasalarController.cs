using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LokantaOtomasyonu.Controllers
{
    public class MasalarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MasalarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public   async Task<IActionResult>Index()
        {
            var tumu =   await _context.Masalars.ToListAsync();
            return View(tumu);
        }
        [HttpGet]
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Masalar gelen)
        {
            if(ModelState.IsValid)
            {
                _context.Masalars.Add(gelen);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        public async Task<IActionResult> Edit(int Id)
        {
            if(Id==null)
            {
                return NotFound();
            }
            var bul = await _context.Masalars.FindAsync(Id);
            return View(bul);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Masalar gelen)
        {
            if(gelen.Masa_Id==null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Masalars.Update(gelen);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var bul = await _context.Masalars.FindAsync(Id);
            return View(bul);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Masalar gelen)
        {
            _context.Masalars.Remove(gelen);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}

