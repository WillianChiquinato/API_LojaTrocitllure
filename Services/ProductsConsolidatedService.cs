using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class ProductsConsolidatedService : IProductConsolidatedsService
{
    private readonly ILogger<ProductsConsolidatedService> _logger;
    private readonly IProductConsolidatedsRepository _productConsolidatedsRepository;
    
    public ProductsConsolidatedService(ILogger<ProductsConsolidatedService> logger, IProductConsolidatedsRepository productConsolidatedsRepository)
    {
        _logger = logger;
        _productConsolidatedsRepository = productConsolidatedsRepository;
    }

    public async Task<CustomResponse<List<ProductConsolidateds>>> GetProductsConsolidateds(int page, int pageSize)
    {
        try
        {
            var productsConsolidateds = await _productConsolidatedsRepository.GetProductsConsolidateds(page, pageSize);
            
            return CustomResponse<List<ProductConsolidateds>>.SuccessTrade(productsConsolidateds);
        }
        catch (Exception e)
        {
            return CustomResponse<List<ProductConsolidateds>>.Fail("Erro ao buscar produtos consolidados", e.Message);
        }
    }
}