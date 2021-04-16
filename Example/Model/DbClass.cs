using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class DbClass:DbContext
    {
        public DbClass(DbContextOptions<DbClass> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                .HasOne(i => i.Author)
                .WithMany(i => i.Quotes)
                .HasForeignKey(i => i.Author_id)
                .IsRequired();

            modelBuilder.Entity<Category_Quote>()
                .HasOne(i => i.Category)
                .WithMany(i => i.category_s)
                .HasForeignKey(i => i.Category_Id)
                .IsRequired();

            modelBuilder.Entity<Category_Quote>()
                .HasOne(i => i.Quote)
                .WithMany(i => i.category_s)
                .HasForeignKey(i => i.Quote_Id)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Category_Quote> Category_Quotes { get; set; }
    }
}
