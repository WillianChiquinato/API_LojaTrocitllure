using Api_LojaTricotllure.Models.DTO;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IShoppingCartRepository
{
    public Task<ShoppingCartDTO> AddToCart(ShoppingCartRequest shoppingCartRequestDTO);
}
