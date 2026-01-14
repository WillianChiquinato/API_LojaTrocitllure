using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("product_consolidateds_image")]
public class ProductConsolidatedsImage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int? ProductId { get; set; }
    
    [Column("image")]
    public string ImageURL { get; set; }
    
    [Column("is_primary")]
    public bool IsPrimary { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(ProductId))]
    public ProductConsolidateds Product { get; set; }
}