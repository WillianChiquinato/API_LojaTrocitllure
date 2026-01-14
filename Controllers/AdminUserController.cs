using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminUserController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminUserController(AppDbContext context)
    {
        _context = context;
    }
}