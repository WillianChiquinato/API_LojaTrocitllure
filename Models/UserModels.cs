using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("user")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("cpf_cnpj")]
    public string? CpfCnpj { get; set; }
    
    [Column("document_type")]
    public int? DocumentType { get; set; }
    
    [Column("user_name")]
    public string? UserName { get; set; }
    
    [Column("name")]
    public string? Name { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("phoneDDD")]
    public int? PhoneDDD { get; set; }
    
    [Column("primary_phone")]
    public string? PrimaryPhone { get; set; }
    
    [Column("sex")]
    public string? Sex { get; set; }
    
    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }
    
    [Column("first_acess")]
    public DateTime? FirstAcess { get; set; }
    
    [Column("last_acess")]
    public DateTime? LastAcess { get; set; }
    
    [Column("password")]
    public string? Password { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
}