using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data {
    public class BudgetTrackerDbContext : DbContext {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options) {

        }
        public DbSet<Users> Users {get; set;}
        public DbSet<Incomes> Incomes { get; set; }
        public DbSet<Expenditures> Expenditures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Users>(ConfigureUsers);
            modelBuilder.Entity<Incomes>(ConfigureIncomes);
            modelBuilder.Entity<Expenditures>(ConfigureExpenditures);
        }

        private void ConfigureUsers(EntityTypeBuilder<Users> builder) {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10);
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.JoinedOn).HasDefaultValueSql("getdate()");
        }
        
        private void ConfigureIncomes(EntityTypeBuilder<Incomes> builder) {
            builder.ToTable("Incomes");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.UserId);
            builder.Property(i => i.Amount).IsRequired();
            builder.Property(i => i.Description).HasMaxLength(100);
            builder.Property(i => i.IncomeDate).HasDefaultValueSql("getdate()");
            builder.Property(i => i.Remarks).HasMaxLength(500);
            builder.HasOne(i => i.User).WithMany(i => i.Incomes).HasForeignKey(i => i.UserId);
        }

        private void ConfigureExpenditures(EntityTypeBuilder<Expenditures> builder) {
            builder.ToTable("Expenditures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId);
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.ExpDate).HasDefaultValueSql("getdate()");
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.HasOne(e => e.User).WithMany(e => e.Expenditures).HasForeignKey(e => e.UserId);
        }
    }
}
