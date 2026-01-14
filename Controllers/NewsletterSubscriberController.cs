using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterSubscriberController : ControllerBase
{
    private readonly AppDbContext _context;

    public NewsletterSubscriberController(AppDbContext context)
    {
        _context = context;
    }
}