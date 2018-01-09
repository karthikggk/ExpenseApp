using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Repository.Entities;

namespace Repository
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Cat_id)
                    .HasName("PK_Category");
                //entity.HasMany(x => x.Expenses);
                entity.ToTable("Category");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(c => c.Sub_Cat_id)
                .HasName("PK_Sub_Category");
                //entity.HasOne(c => c.Category);
                //entity.HasMany(x => x.Expenses);
                entity.ToTable("Sub_Category");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Sub_Category");
                entity.HasOne(x => x.Category)
                .WithMany(x => x.Expenses)
                .HasForeignKey(x => x.Category_ref_id);
                entity.HasOne(x => x.SubCategory)
                .WithMany(x => x.Expenses)
                .HasForeignKey(x => x.Sub_Category_ref_id);
                //entity.HasOne(e => e.Category);
                //entity.HasOne(s => s.SubCategory).WithMany(x => x.Expenses);
                entity.ToTable("Expense");
            });


        }

        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
    }
}
