using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IProductConsolidatedsService
{
    public Task<CustomResponse<List<ProductDTO>>> GetProductsConsolidateds(int page, int pageSize);
    public Task<CustomResponse<StockVerificationDTO>> VerifyStock(int productId, string sizeId, string colorId, int? quantity);
    public Task<CustomResponse<ProductDTO>> GetProductsById(int productId);
}