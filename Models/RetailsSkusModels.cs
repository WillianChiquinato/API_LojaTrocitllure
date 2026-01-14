using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("retail_skus")]
public class RetailSkus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("retail_id")]
    public int RetailId { get; set; }

    [Column("sku_id")]
    public int SkuId { get; set; }

    // 🔗 Relacionamentos
    [ForeignKey(nameof(RetailId))]
    public Retail? Retail { get; set; }

    [ForeignKey(nameof(SkuId))]
    public ProductConsolidatedsSku? Sku { get; set; }
}