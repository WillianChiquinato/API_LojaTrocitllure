using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("newsletter_subscriber")]
public class NewsletterSubscriber
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("confirmed_at")]
    public DateTime ConfirmedAt { get; set; }
    
    [Column("unsubscribed_at")]
    public DateTime? UnsubscribedAt { get; set; }
    
    [Column("source")]
    public string Source { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }
}