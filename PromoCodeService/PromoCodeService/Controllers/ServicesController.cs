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
using PromoCodeService.Models.DTO;
using PromoCodeService.Models.Response;

namespace PromoCodeService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ServicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {          
            return await this.Paginate(ApplySort(_context.Services.AsNoTracking()));
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchServices([FromBody]ServiceSearchDTO searchParams)
        {
            var ctx = _context.Services.AsNoTracking();

            var name = searchParams.Name.Trim().ToLower();

            if (String.Empty != name)
            {
                if (searchParams.FullMatch)
                {
                    ctx = ctx.Where(s => s.Name.ToLower().Equals(name));
                }
                else
                {
                    ctx = ctx.Where(s => s.Name.ToLower().Contains(name));
                }
            }

            return await this.Paginate(ApplySort(ctx));
        }

        [HttpGet("{id}/promocodes")]
        public async Task<IActionResult> Promocodes(int id) {
            if (id > 0)
            {
                var service = await _context.Services.FindAsync(id);

                if (service == null)
                {
                    return NotFound();
                }
                var userId = this.GetUserId();
                var items = _context.Promocodes
                    .Where(p => p.ServiceId == id)
                    .Select(p => 
                        new PromocodesResponseItem(p, p.Users.FirstOrDefault(u => u.Id == userId) != null)
                    );

                return await this.Paginate(items);
            }
            return NotFound();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private IQueryable<Service> ApplySort(IQueryable<Service> source)
        {
            var sort = HttpContext.Request.Query["sort"].ToString();
            var sortDir = HttpContext.Request.Query["sortDir"].ToString();
            var ctx = source;

            var allowedSorts = new string[] { "name" };
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
                            ctx = ctx.OrderBy(s => s.Name);
                        else
                            ctx = ctx.OrderByDescending(s => s.Name);
                        break;
                }
            }

            return ctx;
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
