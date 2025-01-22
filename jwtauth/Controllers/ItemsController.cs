using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using jwtauth.Model;

namespace jwtauth.ItemsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Title = "Item 1", Description = "First Item" },
            new Item { Id = 2, Title = "Item 2", Description = "Second Item" }
        };

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(items);
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Item> GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<Item> AddItem([FromBody] Item newItem)
        {
            if (newItem == null || string.IsNullOrWhiteSpace(newItem.Title))
                return BadRequest(new { message = "Title is required" });

            newItem.Id = items.Count + 1;
            items.Add(newItem);
            return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            if (string.IsNullOrWhiteSpace(updatedItem.Title))
                return BadRequest(new { message = "Title is required" });

            item.Title = updatedItem.Title;
            item.Description = updatedItem.Description;
            return NoContent();
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            items.Remove(item);
            return NoContent();
        }
    }
}
        
