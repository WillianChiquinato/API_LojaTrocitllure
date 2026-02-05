using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Repository;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly AppDbContext _efDbContext;

    public ShoppingCartRepository(AppDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }

    public async Task<ShoppingCartDTO> AddToCart(ShoppingCartRequest shoppingCartRequestDTO)
    {
        ShoppingCart? shoppingCart = null;

        if (shoppingCartRequestDTO.UserId != 0)
        {
            shoppingCart = await _efDbContext.ShoppingCarts
                .FirstOrDefaultAsync(c => c.UserId == shoppingCartRequestDTO.UserId);
        }
        else if (!string.IsNullOrEmpty(shoppingCartRequestDTO.SessionId))
        {
            shoppingCart = await _efDbContext.ShoppingCarts
                .FirstOrDefaultAsync(c => c.SessionId == shoppingCartRequestDTO.SessionId);
        }

        if (shoppingCart == null)
        {
            shoppingCart = new ShoppingCart
            {
                UserId = shoppingCartRequestDTO.UserId != 0 ? shoppingCartRequestDTO.UserId : null,
                SessionId = shoppingCartRequestDTO.UserId == 0
                    ? shoppingCartRequestDTO.SessionId ?? Guid.NewGuid().ToString()
                    : Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _efDbContext.ShoppingCarts.Add(shoppingCart);
            await _efDbContext.SaveChangesAsync();
        }

        var createdItems = await CreateProductsInCartAsync(
            shoppingCart,
            shoppingCartRequestDTO
        );

        var items = createdItems.Select(i => new ShoppingCartItemDTO
        {
            ShoppingCartId = i.ShoppingCartId,
            ProductSkuId = i.ProductSkuId,
            UnitPrice = i.UnitPrice,
            Quantity = i.Quantity,
            Created = i.CreatedAt ?? DateTime.UtcNow,
        }).ToList();

        var totalPrice = items.Sum(i => i.UnitPrice * i.Quantity);

        return new ShoppingCartDTO
        {
            Id = shoppingCart.Id,
            Items = items,
            TotalPrice = totalPrice
        };
    }

    public async Task<ShoppingCart?> GetCartByUserId(int userId)
    {
        var cart = await _efDbContext.ShoppingCarts
            .FirstOrDefaultAsync(c => c.UserId == userId);

        return cart ?? null;
    }

    public Task<List<ShoppingCartItemDTO>> GetItemsInCart(int shoppingCartId)
    {
        var items = _efDbContext.ShoppingCartItems
            .Where(i => i.ShoppingCartId == shoppingCartId)
            .Select(i => new ShoppingCartItemDTO
            {
                ShoppingCartId = i.ShoppingCartId,
                ProductSkuId = i.ProductSkuId,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity,
                Created = i.CreatedAt ?? DateTime.UtcNow,
            })
            .OrderByDescending(p => p.Created)
            .ToListAsync();

        return items;
    }

    public async Task<bool> RemoveItemFromCart(int productSkuId)
    {
        var item = await _efDbContext.ShoppingCartItems
            .FirstOrDefaultAsync(x => x.ProductSkuId == productSkuId);

        if (item == null)
            return false;

        _efDbContext.ShoppingCartItems.Remove(item);
        return await _efDbContext.SaveChangesAsync() > 0;
    }

    private async Task<List<ShoppingCartItem>> CreateProductsInCartAsync(
        ShoppingCart shoppingCart,
        ShoppingCartRequest shoppingCartRequestDTO)
    {
        var affectedItems = new List<ShoppingCartItem>();

        foreach (var product in shoppingCartRequestDTO.Products)
        {
            var sku = await _efDbContext.ProductConsolidatedsSkus
                .FirstOrDefaultAsync(s =>
                    s.ProductId == product.ProductId &&
                    s.Color == product.Color &&
                    s.Size == product.Size);

            if (sku == null)
                continue;

            var existingItem = await _efDbContext.ShoppingCartItems
                .FirstOrDefaultAsync(i =>
                    i.ShoppingCartId == shoppingCart.Id &&
                    i.ProductSkuId == sku.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += product.Quantity;
                existingItem.UnitPrice = sku.Price ?? 0;
                existingItem.CreatedAt = DateTime.UtcNow;

                affectedItems.Add(existingItem);
            }
            else
            {
                var cartItem = new ShoppingCartItem
                {
                    ShoppingCartId = shoppingCart.Id,
                    ProductSkuId = sku.Id,
                    UnitPrice = sku.Price ?? 0,
                    Quantity = product.Quantity,
                    CreatedAt = DateTime.UtcNow
                };

                _efDbContext.ShoppingCartItems.Add(cartItem);
                affectedItems.Add(cartItem);
            }
        }

        await _efDbContext.SaveChangesAsync();
        return affectedItems;
    }
}