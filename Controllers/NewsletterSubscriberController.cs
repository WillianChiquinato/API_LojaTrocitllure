using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterSubscriberController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly INewLetterService _newsletterService;

    public NewsletterSubscriberController(AppDbContext context, INewLetterService newsletterService)
    {
        _context = context;
        _newsletterService = newsletterService;
    }
    
    [HttpPost]
    [Authorize]
    [Route("SubscriberNewLetter")]
    public async Task<IActionResult> SubscriberNewLetter([FromBody] NewLetterRequest request)
    {
        var newLetter = await _newsletterService.SubscriberNewLetter(request);

        return newLetter.Success
            ? Ok(newLetter)
            : BadRequest(newLetter);
    }
}