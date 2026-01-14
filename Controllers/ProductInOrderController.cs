using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductInOrderController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductInOrderController(AppDbContext context)
    {
        _context = context;
    }
}