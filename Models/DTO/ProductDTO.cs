using System.Collections.Generic;

namespace Api_LojaTricotllure.Models.DTO
{
    public class ProductDTO
    {
        public object Product { get; set; }
        public List<ProductImageDTO> Images { get; set; }
        public List<ProductSkuDTO> Skus { get; set; }
    }

    public class ProductImageDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ImageURL { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class ProductSkuDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SkuCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}