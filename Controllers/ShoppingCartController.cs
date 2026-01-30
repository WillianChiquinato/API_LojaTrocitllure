using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(AppDbContext context, IShoppingCartService shoppingCartService)
    {
        _context = context;
        _shoppingCartService = shoppingCartService;
    }

    [HttpPost]
    [Route("addToCart")]
    public async Task<IActionResult> AddToCart([FromBody] ShoppingCartRequest shoppingCartRequestDTO)
    {
        var shoppingCart = await _shoppingCartService.AddToCart(shoppingCartRequestDTO);

        return shoppingCart.Result != null ? Ok(shoppingCart) : NotFound();
    }
}