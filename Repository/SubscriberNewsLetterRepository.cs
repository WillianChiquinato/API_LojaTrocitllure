using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Repository;

public class SubscriberNewsLetterRepository : INewLetterRepository
{
    private readonly AppDbContext _efDbContext;

    public SubscriberNewsLetterRepository(AppDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }
    
    public async Task<NewsletterSubscriber> SubscriberNewLetter(string Email, string PhoneNumber, string Source)
    {
        var createNewsletter = new NewsletterSubscriber
        {
            Email = Email,
            PhoneNumber = PhoneNumber,
            IsActive = true,
            ConfirmedAt = DateTime.Now,
            UnsubscribedAt = null,
            Source = Source,
            CreatedAt = DateTime.Now
        };

        _efDbContext.NewsletterSubscribers.Add(createNewsletter);
        await _efDbContext.SaveChangesAsync();
        
        return createNewsletter;
    }
}