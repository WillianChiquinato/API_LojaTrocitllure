using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderPurchaseController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderPurchaseController(AppDbContext context)
    {
        _context = context;
    }
}