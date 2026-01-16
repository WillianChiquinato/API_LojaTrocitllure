using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetailController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IRetailService _retailService;

    public RetailController(AppDbContext context, IRetailService retailService)
    {
        _context = context;
        _retailService = retailService;
    }

    [HttpGet]
    [Route("GetRetails")]
    public async Task<IActionResult> GetRetails()
    {
        var retails = await _retailService.GetRetails();
        
        return retails.Result != null ? Ok(retails) : NotFound();
    }
}