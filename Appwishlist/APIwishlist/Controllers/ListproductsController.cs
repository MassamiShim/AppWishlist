using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIwishlist.Models;

namespace APIwishlist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListproductsController : ControllerBase
    {
        private readonly WishlistContext _context;

        public ListproductsController(WishlistContext context)
        {
            _context = context;
        }

        // GET: api/Listproducts
        [HttpGet]
        public IEnumerable<Listproduct> GetListProduct()
        {
            return _context.ListProduct;
        }

        // GET: api/Listproducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListproduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listproduct = await _context.ListProduct.Where(lp => lp.IdList == id).ToListAsync();

            if (listproduct == null)
            {
                return NotFound();
            }

            return Ok(listproduct);
        }

        // PUT: api/Listproducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListproduct([FromRoute] int id, [FromBody] Listproduct listproduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listproduct.IdList)
            {
                return BadRequest();
            }

            _context.Entry(listproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListproductExists(id))
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

        // POST: api/Listproducts
        [HttpPost]
        public async Task<IActionResult> PostListproduct([FromBody] Listproduct listproduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ListProduct.Add(listproduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListproductExists(listproduct.IdList))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetListproduct", new { id = listproduct.IdList }, listproduct);
        }

        // DELETE: api/Listproducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListproduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listproduct = await _context.ListProduct.FindAsync(id);
            if (listproduct == null)
            {
                return NotFound();
            }

            _context.ListProduct.Remove(listproduct);
            await _context.SaveChangesAsync();

            return Ok(listproduct);
        }

        private bool ListproductExists(int id)
        {
            return _context.ListProduct.Any(e => e.IdList == id);
        }
    }
}