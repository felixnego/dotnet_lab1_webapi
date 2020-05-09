using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cars_api_example.Models;

namespace cars_api_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarItemsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarItemsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/CarItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarItem>>> GetCarItems()
        {
            return await _context.CarItems.ToListAsync();
        }

        // GET: api/CarItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarItem>> GetCarItem(long id)
        {
            var carItem = await _context.CarItems.FindAsync(id);

            if (carItem == null)
            {
                return NotFound();
            }

            return carItem;
        }

        // PUT: api/CarItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarItem(long id, CarItem carItem)
        {
            if (id != carItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(carItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarItemExists(id))
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

        // POS T: api/CarItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarItem>> PostCarItem(CarItem carItem)
        {
            if (carItem.Year < 0)
            {
                return BadRequest("Invalid value entered for 'year' field!");
            }

            _context.CarItems.Add(carItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarItem), new { id = carItem.Id }, carItem); // TODO ask about the return
        }

        // DELETE: api/CarItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarItem>> DeleteCarItem(long id)
        {
            var carItem = await _context.CarItems.FindAsync(id); // TODO ask here
            if (carItem == null)
            {
                return NotFound();
            }

            _context.CarItems.Remove(carItem);
            await _context.SaveChangesAsync();

            return carItem;
        }

        private bool CarItemExists(long id)
        {
            return _context.CarItems.Any(e => e.Id == id);
        }
    }
}
