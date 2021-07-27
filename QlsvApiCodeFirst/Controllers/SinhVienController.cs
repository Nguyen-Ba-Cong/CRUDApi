using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QlsvApi.Models;

namespace QlsvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly SinhVienContext _context;

        public SinhVienController(SinhVienContext context)
        {
            _context = context;
        }

        // GET: api/SinhVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhViens()
        {

            return await _context.SinhViens.ToListAsync();
        }

        // GET: api/SinhVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVien>> GetSinhVien(int id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);

            if (sinhVien == null)
            {
                return NotFound();
            }

            return sinhVien;
        }

        // PUT: api/SinhVien/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien(int id, SinhVien sinhVien)
        {
            if (id != sinhVien.ID)
            {
                return BadRequest();
            }

            _context.Entry(sinhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhVienExists(id))
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

        // POST: api/SinhVien
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien sinhVien)
        {
            _context.SinhViens.Add(sinhVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSinhVien), new { id = sinhVien.ID }, sinhVien);
        }

        // DELETE: api/SinhVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(int id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            _context.SinhViens.Remove(sinhVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinhVienExists(int id)
        {
            return _context.SinhViens.Any(e => e.ID == id);
        }
    }
}
