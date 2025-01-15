using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HttpStatusCode.Model;

namespace ItemManagementAPI.Controllers
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
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> AddItem([FromBody] Item newItem)
        {
            if (newItem == null || string.IsNullOrWhiteSpace(newItem.Title))
                return BadRequest(new { message = "Title is required" });

            newItem.Id = items.Count + 1;
            items.Add(newItem);
            return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            if (string.IsNullOrWhiteSpace(updatedItem.Title))
                return BadRequest(new { message = "Title is required" });

            item.Title = updatedItem.Title;
            item.Description = updatedItem.Description;
            return Ok("item Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            items.Remove(item);
            return Ok("item deleted");
        }
    }
}