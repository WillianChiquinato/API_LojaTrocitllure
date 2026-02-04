using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;
using Api_LojaTricotllure.Models.DTO;
using Microsoft.EntityFrameworkCore;

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

    public async Task<CustomResponse<ProductDTO>> GetProductsById(int productId)
    {
        try
        {
            var product = await _productConsolidatedsRepository.GetProductById(productId);
            if (product == null)
            {
                return CustomResponse<ProductDTO>.Fail("Produto não encontrado.");
            }
    
            var images = await _productConsolidatedsRepository.GetImagesByProductIds(new List<int> { productId });
            var skus = await _productConsolidatedsRepository.GetSkusByProductIds(new List<int> { productId });

            var productDTO = new ProductDTO
            {
                Product = product,
                Skus = skus.Select(sku => new ProductSkuDTO
                {
                    Id = sku.Id,
                    ProductId = sku.ProductId,
                    SkuCode = sku.SkuCode!,
                    Color = sku.Color!,
                    Size = sku.Size!,
                    Price = sku.Price ?? 0.0m,
                    Stock = sku.Stock ?? 0,
                    IsActive = sku.IsActive
                }).ToList(),
                Images = images.Select(img => new ProductImageDTO
                {
                    Id = img.Id,
                    ProductId = img.ProductId ?? 0,
                    ImageURL = img.ImageURL,
                    IsPrimary = img.IsPrimary
                }).ToList()
            };

            return CustomResponse<ProductDTO>.SuccessTrade(productDTO);
        }
        catch (Exception e)
        {
            return CustomResponse<ProductDTO>.Fail("Erro ao buscar produto por ID", e.Message);
        }
    }

    public async Task<CustomResponse<List<ProductDTO>>> GetProductsConsolidateds(int page, int pageSize)
    {
        try
        {
            var productsConsolidateds = await _productConsolidatedsRepository.GetProductsConsolidateds(page, pageSize);
            var productIds = productsConsolidateds.Select(p => p.Id).ToList();

            var images = await _productConsolidatedsRepository.GetImagesByProductIds(productIds);
            var skus = await _productConsolidatedsRepository.GetSkusByProductIds(productIds);

            var result = productsConsolidateds.Select(product => new ProductDTO
            {
                Product = product,
                Skus = skus
                    .Where(sku => sku.ProductId == product.Id)
                    .Select(sku => new ProductSkuDTO
                    {
                        Id = sku.Id,
                        ProductId = sku.ProductId,
                        SkuCode = sku.SkuCode!,
                        Color = sku.Color!,
                        Size = sku.Size!,
                        Price = sku.Price ?? 0.0m,
                        Stock = sku.Stock ?? 0,
                        IsActive = sku.IsActive
                    })
                    .ToList(),
                Images = images
                    .Where(img => img.ProductId == product.Id)
                    .Select(img => new ProductImageDTO
                    {
                        Id = img.Id,
                        ProductId = img.ProductId ?? 0,
                        ImageURL = img.ImageURL,
                        IsPrimary = img.IsPrimary
                    })
                    .ToList()
                }).ToList();

            var totalRows = await _productConsolidatedsRepository.GetProductsConsolidatedsTotalRows();

            return CustomResponse<List<ProductDTO>>.SuccessTrade(result, totalRows);
        }
        catch (Exception e)
        {
            return CustomResponse<List<ProductDTO>>.Fail("Erro ao buscar produtos consolidados", e.Message);
        }
    }

    

    public async Task<CustomResponse<StockVerificationDTO>> VerifyStock(int productId, string sizeId, string colorId, int? quantity)
    {
        try
        {
            var sku = await _productConsolidatedsRepository.GetSkuByAttributes(productId, sizeId, colorId);

            if (sku == null)
            {
                return CustomResponse<StockVerificationDTO>.Fail("SKU não encontrado para os atributos fornecidos.");
            }

            int availableStock = sku.Stock ?? 0;
            bool isStockSufficient = quantity.HasValue ? availableStock >= quantity.Value : true;

            var stockVerification = new StockVerificationDTO
            {
                ProductId = productId,
                Size = sizeId,
                Color = colorId,
                AvailableStock = availableStock,
                IsStockSufficient = isStockSufficient
            };

            return CustomResponse<StockVerificationDTO>.SuccessTrade(stockVerification);
        }
        catch (Exception e)
        {
            return CustomResponse<StockVerificationDTO>.Fail("Erro ao verificar o estoque", e.Message);
        }
    }
}