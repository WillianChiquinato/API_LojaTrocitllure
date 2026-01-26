using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface INewLetterService
{
    public Task<CustomResponse<NewsletterSubscriber>> SubscriberNewLetter(NewLetterRequest request);
}