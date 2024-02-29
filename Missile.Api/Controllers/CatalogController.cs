using Microsoft.AspNetCore.Mvc;
using Missile.Domain.Catalog;
using Missile.Data;
using System.Reflection.Metadata.Ecma335;

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
            var item = new Item("Shirt", "Ohio State shirt", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);

        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            /*
            POST https://localhost:5067/catalog
            Content-Type: application/json
            {
                "name": "Shoes",
                "description": "Ohio State shoes",
                "brand": "Nike",
                "price": 129.99
            }
            */

            return Created("/catalog/42", item);

        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);

        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            return NoContent();

        }

    }

}