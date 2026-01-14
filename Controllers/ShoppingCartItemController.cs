using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartItemController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShoppingCartItemController(AppDbContext context)
    {
        _context = context;
    }
}