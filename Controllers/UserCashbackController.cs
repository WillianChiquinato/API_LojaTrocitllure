using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserCashbackController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserCashbackController(AppDbContext context)
    {
        _context = context;
    }
}