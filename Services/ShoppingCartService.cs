using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IProductConsolidatedsRepository _productConsolidatedsRepository;
    private readonly IProductConsolidatedsService _productConsolidatedsService;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductConsolidatedsRepository productConsolidatedsRepository, IProductConsolidatedsService productConsolidatedsService)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _productConsolidatedsRepository = productConsolidatedsRepository;
        _productConsolidatedsService = productConsolidatedsService;
    }

    public async Task<CustomResponse<ShoppingCartDTO>> AddToCart(ShoppingCartRequest shoppingCartRequestDTO)
    {
        try
        {
            var shoppingCart = await _shoppingCartRepository.AddToCart(shoppingCartRequestDTO);

            return CustomResponse<ShoppingCartDTO>.SuccessTrade(shoppingCart);
        }
        catch (Exception ex)
        {
            return CustomResponse<ShoppingCartDTO>.Fail("Erro ao adicionar item ao carrinho", ex.Message);
        }
    }

    public async Task<CustomResponse<ShoppingCartResponseWithProductsDTO>> GetItemsInCart(int userId)
    {
        try
        {
            var shoppingCart = await _shoppingCartRepository.GetCartByUserId(userId);

            if (shoppingCart == null)
            {
                return CustomResponse<ShoppingCartResponseWithProductsDTO>
                    .Fail("Carrinho não encontrado", "Carrinho não encontrado para o usuário.");
            }

            var items = await _shoppingCartRepository.GetItemsInCart(shoppingCart.Id);

            if (items == null || !items.Any())
            {
                return CustomResponse<ShoppingCartResponseWithProductsDTO>.SuccessTrade(
                    new ShoppingCartResponseWithProductsDTO
                    {
                        UserId = shoppingCart.UserId ?? 0,
                        ShoppingCartId = shoppingCart.Id,
                        Products = new List<ProductDTO>()
                    }
                );
            }

            var products = new List<ProductDTO>();

            foreach (var item in items)
            {
                // 🔹 SKU é o coração do carrinho
                var sku = await _productConsolidatedsRepository
                    .GetSkuBySkuId(item.ProductSkuId);

                if (sku == null)
                    continue;

                // 🔹 Dados do produto (derivados do SKU)
                var images = await _productConsolidatedsRepository
                    .GetImagesByProductIds(new List<int> { sku.ProductId });
                
                var product = await _productConsolidatedsRepository
                    .GetProductById(sku.ProductId);

                var getShoppingCart = await _shoppingCartRepository.GetCartByUserId(userId);

                products.Add(new ProductDTO
                {
                    Product = new
                    {
                        ProductId = sku.ProductId,
                        Name = product?.Name ?? "",
                        CartItemId = getShoppingCart.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.Quantity * item.UnitPrice
                    },
                    Images = images.Select(img => new ProductImageDTO
                    {
                        Id = img.Id,
                        ProductId = img.ProductId,
                        ImageURL = img.ImageURL,
                        IsPrimary = img.IsPrimary
                    }).ToList(),
                    Skus = new List<ProductSkuDTO>
                    {
                        new ProductSkuDTO
                        {
                            Id = sku.Id,
                            ProductId = sku.ProductId,
                            SkuCode = sku.SkuCode,
                            Color = sku.Color,
                            Size = sku.Size,
                            Price = item.UnitPrice,
                            Stock = sku.Stock ?? 0,
                            IsActive = sku.IsActive
                        }
                    }
                });
            }

            var response = new ShoppingCartResponseWithProductsDTO
            {
                UserId = shoppingCart.UserId ?? 0,
                ShoppingCartId = shoppingCart.Id,
                Products = products
            };

            return CustomResponse<ShoppingCartResponseWithProductsDTO>.SuccessTrade(response);
        }
        catch (Exception ex)
        {
            return CustomResponse<ShoppingCartResponseWithProductsDTO>
                .Fail("Erro ao buscar itens do carrinho", ex.Message);
        }
    }

    public async Task<CustomResponse<bool>> RemoveItemFromCart(int itemId)
    {
        try
        {
            var result = await _shoppingCartRepository.RemoveItemFromCart(itemId);

            return CustomResponse<bool>.SuccessTrade(result);
        }
        catch (Exception ex)
        {
            return CustomResponse<bool>.Fail("Erro ao remover item do carrinho", ex.Message);
        }
    }
}