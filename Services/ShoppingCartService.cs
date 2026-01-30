using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<CustomResponse<ShoppingCartDTO>> AddToCart(ShoppingCartRequest shoppingCartRequestDTO)
    {
        var shoppingCart = await _shoppingCartRepository.AddToCart(shoppingCartRequestDTO);

        return CustomResponse<ShoppingCartDTO>.SuccessTrade(shoppingCart);
    }
}