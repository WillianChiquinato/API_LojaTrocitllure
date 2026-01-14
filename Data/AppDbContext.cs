using Api_LojaTricotllure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<LogsAdminTransaction> LogsAdminTransactions { get; set; }
    public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
    public DbSet<OrderPurchase> OrderPurchases { get; set; }
    public DbSet<ParentCategory> ParentCategories { get; set; }
    public DbSet<ProductConsolidatedsCategory> ProductConsolidatedsCategories { get; set; }
    public DbSet<ProductConsolidatedsImage> ProductConsolidatedsImages { get; set; }
    public DbSet<ProductConsolidateds> ProductConsolidateds { get; set; }
    public DbSet<ProductConsolidatedsSku> ProductConsolidatedsSkus { get; set; }
    public DbSet<ProductInOrder> ProductInOrders { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Retail> Retails { get; set; }
    public DbSet<RetailSkus> RetailSkus { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<UserCashback> UserCashbacks { get; set; }
    public DbSet<User> Users { get; set; }
}