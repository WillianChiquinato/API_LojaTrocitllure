using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IProductConsolidatedsRepository
{
    Task<List<ProductConsolidateds>> GetProductsConsolidateds(int page, int pageSize);
}