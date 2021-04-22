using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using PromoCodeService.Helpers;
using PromoCodeService.Models.Response;

namespace PromoCodeService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PromocodesController : ControllerBase
    {
        private readonly DataContext _context;

        public PromocodesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Promocodes
        [HttpGet]
        public async Task<IActionResult> GetPromocodes()
        {
            var userId = this.GetUserId();
            var ctx = ApplySort(_context.Promocodes).Select(p =>
                        new PromocodesResponseItem(p, p.Users.FirstOrDefault(u => u.Id == userId) != null));
            return await this.Paginate(ctx);
        }

        [HttpPost("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var userId = this.GetUserId();

            var promocode = await _context.Promocodes.Include(p => p.Users).Where(p => p.Id == id).Select(p => new
                {
                    Activated = p.Users.FirstOrDefault(u => u.Id == userId) != null
                }
            ).FirstOrDefaultAsync();

            if (promocode != null)
            {
                if (!promocode.Activated)
                {
                    _context.Add(new UserPromocode { UserId = userId, PromocodeId = id });
                    await _context.SaveChangesAsync();

                }

                return Ok();
            }                 

            return NotFound();            
        }

        // GET: api/Promocodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promocode>> GetPromocode(int id)
        {
            var promocode = await _context.Promocodes.FindAsync(id);

            if (promocode == null)
            {
                return NotFound();
            }

            return promocode;
        }

        // PUT: api/Promocodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromocode(int id, Promocode promocode)
        {
            if (id != promocode.Id)
            {
                return BadRequest();
            }

            _context.Entry(promocode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocodeExists(id))
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

        // POST: api/Promocodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Promocode>> PostPromocode(Promocode promocode)
        {
            _context.Promocodes.Add(promocode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromocode", new { id = promocode.Id }, promocode);
        }

        // DELETE: api/Promocodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocode(int id)
        {
            var promocode = await _context.Promocodes.FindAsync(id);
            if (promocode == null)
            {
                return NotFound();
            }

            _context.Promocodes.Remove(promocode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromocodeExists(int id)
        {
            return _context.Promocodes.Any(e => e.Id == id);
        }

        private IQueryable<Promocode> ApplySort(IQueryable<Promocode> source)
        {
            var sort = HttpContext.Request.Query["sort"].ToString();
            var sortDir = HttpContext.Request.Query["sortDir"].ToString();
            var ctx = source;

            var allowedSorts = new string[] { "date_added" };
            var allowedSortDirs = new string[] { "asc", "desc" };

            if (!String.IsNullOrEmpty(sort) && allowedSorts.Contains(sort))
            {
                if (!allowedSortDirs.Contains(sortDir))
                {
                    sortDir = "asc";
                }


                // Replace with sort delegates
                switch (sort)
                {
                    case "name":
                        if (sortDir == "asc")
                            ctx = ctx.OrderBy(s => s.DateAdded);
                        else
                            ctx = ctx.OrderByDescending(s => s.DateAdded);
                        break;
                }
            }

            return ctx;
        }
    }
}
