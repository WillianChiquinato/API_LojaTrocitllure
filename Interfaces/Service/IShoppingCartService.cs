using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IShoppingCartService
{
    public Task<CustomResponse<ShoppingCartDTO>> AddToCart(ShoppingCartRequest shoppingCartRequestDTO);
}