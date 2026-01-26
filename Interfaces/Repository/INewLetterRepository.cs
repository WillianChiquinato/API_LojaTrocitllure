using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface INewLetterRepository
{
    public Task<NewsletterSubscriber> SubscriberNewLetter(string Email, string PhoneNumber, string Source);
}