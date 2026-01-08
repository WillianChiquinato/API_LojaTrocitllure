using Api_LojaTricotllure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<Personagem> Tricotllure { get; set; }
}