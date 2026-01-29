using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IProductConsolidatedsService
{
    public Task<CustomResponse<List<ProductConsolidateds>>> GetProductsConsolidateds(int page, int pageSize);
}