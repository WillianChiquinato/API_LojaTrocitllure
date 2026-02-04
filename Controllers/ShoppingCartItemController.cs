using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartItemController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IShoppingCartService _shoppingCartItemService;

    public ShoppingCartItemController(AppDbContext context, IShoppingCartService shoppingCartItemService)
    {
        _context = context;
        _shoppingCartItemService = shoppingCartItemService;
    }

    [HttpGet]
    [Route("getItemsInCart")]
    public async Task<IActionResult> GetItemsInCart([FromQuery] int userId)
    {
        var items = await _shoppingCartItemService.GetItemsInCart(userId);
        
        return items.Result != null ? Ok(items) : NotFound();
    }
    
    [HttpDelete]
    [Route("removeItemFromCart")]
    public async Task<IActionResult> RemoveItemFromCart([FromQuery] int itemId)
    {
        var result = await _shoppingCartItemService.RemoveItemFromCart(itemId);
        
        return result.Result ? Ok(result) : BadRequest(result);
    }
}