using Microsoft.AspNetCore.Mvc;
using Missile.Domain.Catalog;
using Missile.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Missile.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetItems()
        {

            return Ok(_db.Items);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetItems(int id)
        {

            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpPost]
        public IActionResult Post(Item item)
        {

            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);

        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);

        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Item item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }

            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();

        }

    }

}