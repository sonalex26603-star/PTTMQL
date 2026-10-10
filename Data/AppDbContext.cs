
using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;

namespace DemoMVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<SanPham> SanPhams => Set<SanPham>();
}
