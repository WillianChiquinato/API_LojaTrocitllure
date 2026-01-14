using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsAdminTransactionController : ControllerBase
{
    private readonly AppDbContext _context;

    public LogsAdminTransactionController(AppDbContext context)
    {
        _context = context;
    }
}