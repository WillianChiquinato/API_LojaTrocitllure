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
                return CustomResponse<ShoppingCartResponseWithProductsDTO>.Fail("Carrinho não encontrado para o usuário", "Carrinho não encontrado.");
            }

            var items = await _shoppingCartRepository.GetItemsInCart(shoppingCart.Id);

            //Cada product SKU que veio eu faço um product getById para pegar as infos do produto.
            var searchProductsBySku = await _productConsolidatedsRepository.GetProductsConsolidatedsBySkuId(items.Select(i => i.ProductSkuId).ToList());
            var productsComplete = new List<ProductDTO>();

            foreach (var product in searchProductsBySku)
            {
                var productDTO = await _productConsolidatedsService.GetProductsById(product.Id);
                if (productDTO != null)
                {
                    productsComplete.Add(new ProductDTO { Product = productDTO.Result.Product, Images = productDTO.Result.Images, Skus = productDTO.Result.Skus });
                }
            }

            var response = new ShoppingCartResponseWithProductsDTO
            {
                UserId = shoppingCart.UserId ?? 0,
                ShoppingCartId = shoppingCart.Id,
                Products = productsComplete
            };

            return CustomResponse<ShoppingCartResponseWithProductsDTO>.SuccessTrade(response);
        }
        catch (Exception ex)
        {
            return CustomResponse<ShoppingCartResponseWithProductsDTO>.Fail("Erro ao buscar itens do carrinho", ex.Message);
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