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

    public async Task<List<ProductConsolidateds>> GetProductsConsolidateds(int page, int pageSize)
    {
        return await _efDbContext.ProductConsolidateds
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}