using Microsoft.EntityFrameworkCore;
using StatementsTracker.Data.Entities;
using StatementsTracker.Data.Extensions;
using System;

namespace StatementsTracker.Data
{
    public class StatementsContext : DbContext
    {

        public StatementsContext(DbContextOptions<StatementsContext> options)
             : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                   .Property(p => p.Amount)
                   .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Statement>()
                   .Property(p => p.OpeningBalance)
                   .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Statement>()
                   .Property(p => p.ClosingBalance)
                   .HasColumnType("decimal(10,2)");

            modelBuilder.EnumHasData<PaymentMethodEnum, PaymentMethod>();
            modelBuilder.EnumHasData<PaymentTypeEnum, PaymentType>();
        }


        public DbSet<Payment> Payments { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
