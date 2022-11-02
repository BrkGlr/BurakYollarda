using BurakYollarda.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Context
{
    public class BurakYollardaContext:DbContext
    {
        
        public BurakYollardaContext(DbContextOptions<BurakYollardaContext>options):base(options)
        {

        }
        public DbSet<AdminEntity> Admins => Set<AdminEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<SubCategoryEntity> SubCategories => Set<SubCategoryEntity>();
        public DbSet<PostEntity> Posts => Set<PostEntity>();
        public DbSet<CommentEntity> Comments => Set<CommentEntity>();




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());


            modelBuilder.Entity<AdminEntity>().HasData(new List<AdminEntity>() {
                new AdminEntity()
                {
                    Id=1,
                    Email="admin@burakyollarda.com",
                    Password="12345",
                    UserType="admin"
                }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
