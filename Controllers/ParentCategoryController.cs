using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParentCategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public ParentCategoryController(AppDbContext context)
    {
        _context = context;
    }
}