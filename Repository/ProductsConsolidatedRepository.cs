using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Repository;

public class ProductsConsolidatedRepository : IProductConsolidatedsRepository
{
    private readonly AppDbContext _efDbContext;

    public ProductsConsolidatedRepository(AppDbContext context)
    {
        _efDbContext = context;
    }

    public async Task<int> GetProductsConsolidatedsTotalRows()
    {
        return await _efDbContext.ProductConsolidateds
            .Where(p => p.IsActive)
            .CountAsync();
    }

    public async Task<List<ProductConsolidateds>> GetProductsConsolidateds(int page, int pageSize)
    {
        return await _efDbContext.ProductConsolidateds
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<ProductConsolidateds?> GetProductById(int productId)
    {
        return _efDbContext.ProductConsolidateds
            .FirstOrDefaultAsync(p => p.Id == productId && p.IsActive);
    }

    public Task<List<ProductConsolidatedsImage>> GetImagesByProductIds(List<int> productIds)
    {
        return _efDbContext.ProductConsolidatedsImages
            .Where(img => img.ProductId != null && productIds.Contains(img.ProductId.Value))
            .ToListAsync();
    }

    public Task<List<ProductConsolidatedsSku>> GetSkusByProductIds(List<int> productIds)
    {
        return _efDbContext.ProductConsolidatedsSkus
            .Where(sku => productIds.Contains(sku.ProductId) && sku.IsActive)
            .ToListAsync();
    }

    public Task<ProductConsolidatedsSku?> GetSkuByAttributes(int productId, string sizeId, string colorId)
    {
        return _efDbContext.ProductConsolidatedsSkus
            .FirstOrDefaultAsync(sku => sku.ProductId == productId && sku.Size == sizeId && sku.Color == colorId && sku.IsActive);
    }

    public Task<List<ProductConsolidateds>> GetProductsConsolidatedsBySkuId(List<int> skuIds)
    {
        return _efDbContext.ProductConsolidateds
            .Where(p => skuIds.Contains(p.Id) && p.IsActive)
            .ToListAsync();
    }
}