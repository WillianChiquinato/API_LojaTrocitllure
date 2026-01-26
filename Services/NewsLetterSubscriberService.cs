using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class NewsLetterSubscriberService : INewLetterService
{
    private readonly ILogger<NewsLetterSubscriberService> _logger;
    private readonly INewLetterRepository _newLetterRepository;
    
    public NewsLetterSubscriberService(ILogger<NewsLetterSubscriberService> logger, INewLetterRepository newLetterRepository)
    {
        _logger = logger;
        _newLetterRepository = newLetterRepository;
    }

    public async Task<CustomResponse<NewsletterSubscriber>> SubscriberNewLetter(NewLetterRequest request)
    {
        try
        {
            var newLetter = await _newLetterRepository.SubscriberNewLetter(request.Email, request.PhoneNumber, request.Source);
            
            return CustomResponse<NewsletterSubscriber>.SuccessTrade(newLetter);
        }
        catch (Exception e)
        {
            return CustomResponse<NewsletterSubscriber>.Fail("Erro ao tentar gerar uma novidade");
        }
    }
}