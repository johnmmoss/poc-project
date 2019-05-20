using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleTokenService.Data.Entities;

namespace SimpleTokenService.Data
{
    public class TokenContext : IdentityDbContext<User, Role , int>
    {
        public TokenContext(DbContextOptions<TokenContext> options)
            : base(options)
        {
           
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Statement>()
                   .Property(p => p.OpeningBalance)
                   .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Statement>()
                   .Property(p => p.ClosingBalance)
                   .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaim");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogin");
                entity.Property(e => e.UserId).HasColumnName("Id");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaim");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.RoleId).HasColumnName("RoleId");
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRole");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.RoleId).HasColumnName("RoleId");
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserToken");
                entity.Property(e => e.UserId).HasColumnName("Id");
            });
        }
    }
}
