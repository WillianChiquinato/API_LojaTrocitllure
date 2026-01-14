using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetailSkusController : ControllerBase
{
    private readonly AppDbContext _context;

    public RetailSkusController(AppDbContext context)
    {
        _context = context;
    }
}