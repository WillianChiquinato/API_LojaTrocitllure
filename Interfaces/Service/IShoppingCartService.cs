using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IShoppingCartService
{
    public Task<CustomResponse<ShoppingCartDTO>> AddToCart(ShoppingCartRequest shoppingCartRequestDTO);
    public Task<CustomResponse<ShoppingCartResponseWithProductsDTO>> GetItemsInCart(int userId);
    public Task<CustomResponse<bool>> RemoveItemFromCart(int itemId);
}