using FoodAPI.Data;
using FoodAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvintoriesController : Controller
    {
        private readonly InventoryDbContext inventoryDbContext;

        public InvintoriesController(InventoryDbContext inventoryDbContext)
        {
            this.inventoryDbContext = inventoryDbContext;
        }

        //Get all the inventory...
        [HttpGet]
        public async Task<IActionResult> getInventory()
        {
            var foods = await inventoryDbContext.Inventories.ToListAsync();
            return Ok(foods);
        }

        //Add inventory...
        [HttpPost]
        public async Task<IActionResult> addInventory([FromBody] Inventory inventory)
        {
            inventory.Item = inventory.Item;
            await inventoryDbContext.Inventories.AddAsync(inventory);
            await inventoryDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(getInventory), inventory.Item, inventory);
        }

        //Update an inventory item...
        [HttpPut]
        public async Task<IActionResult> updateItem([FromRoute] string theItem, [FromBody] Inventory inventory)
        {
            var existingItem = await inventoryDbContext.Inventories.FirstOrDefaultAsync(x => x.Item == theItem);
            if(existingItem != null)
            {
                existingItem.Item = inventory.Item;
                existingItem.Qty = inventory.Qty;
                existingItem.Location = inventory.Location;
                existingItem.Expires = inventory.Expires;
                await inventoryDbContext.SaveChangesAsync();
                return Ok(existingItem);
            }
            return NotFound("That item was not found");
        }
    }
}
