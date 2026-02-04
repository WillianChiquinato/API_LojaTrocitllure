using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IProductConsolidatedsRepository
{
    Task<ProductConsolidateds?> GetProductById(int productId);
    Task<ProductConsolidatedsSku?> GetSkuByAttributes(int productId, string sizeId, string colorId);
    Task<int> GetProductsConsolidatedsTotalRows();
    Task<List<ProductConsolidateds>> GetProductsConsolidateds(int page, int pageSize);
    Task<List<ProductConsolidatedsImage>> GetImagesByProductIds(List<int> productIds);
    Task<List<ProductConsolidatedsSku>> GetSkusByProductIds(List<int> productIds);
    Task<List<ProductConsolidateds>> GetProductsConsolidatedsBySkuId(List<int> skuIds);
}