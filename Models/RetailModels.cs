using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("retail")]
public class Retail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("active")]
    public bool Active { get; set; }
    
    [Column("image")]
    public string ImageURL { get; set; }
    
    [Column("discount")]
    public int Discount { get; set; }
    
    [Column("is_emphasis")]
    public bool IsEmphasis { get; set; }
    
    [Column("start_date", TypeName = "datetime(6)")]
    public DateTime? StartsAt { get; set; }
    
    [Column("end_date", TypeName = "datetime(6)")]
    public DateTime EndsAt { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }
    
    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdateAt { get; set; }
}