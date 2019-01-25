using Models;
using Microsoft.EntityFrameworkCore;


public class ThorpeContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    public ThorpeContext(DbContextOptions<ThorpeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
