using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IShoppingCartRepository
{
    public Task<ShoppingCartDTO> AddToCart(ShoppingCartRequest shoppingCartRequestDTO);
    public Task<ShoppingCart?> GetCartByUserId(int userId);
    public Task<List<ShoppingCartItemDTO>> GetItemsInCart(int shoppingCartId);
    public Task<bool> RemoveItemFromCart(int itemId);
}
