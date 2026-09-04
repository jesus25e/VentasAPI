using Inventory.Application.Interfaces;
using Inventory.Domain.Common;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public readonly ICurrentUserService _currentUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleDetails> SalesDetails => Set<SaleDetails>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>( b =>
            {
                b.Property(u => u.Id)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Product>()
                .HasQueryFilter(x =>
                    !x.IsDeleted &&
                    x.TenantId == _currentUserService.TenantId);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(x =>
                    !x.IsDeleted &&
                    x.TenantId == _currentUserService.TenantId);

            modelBuilder.Entity<Supplier>()
                .HasQueryFilter(x => 
                    !x.IsDeleted &&
                    x.TenantId == _currentUserService.TenantId);

            modelBuilder.Entity<SaleDetails>()
                .HasQueryFilter(x =>
                    !x.IsDeleted &&
                    x.TenantId == _currentUserService.TenantId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<TenantEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.SetTenant(_currentUserService.TenantId);
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.MarkAsUpdated();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
