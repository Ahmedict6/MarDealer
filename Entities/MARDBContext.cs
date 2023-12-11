using Entities.Models.Common;
using Entities.Models.Product_Management;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class MARDBContext : DbContext
    {
        public MARDBContext(DbContextOptions<MARDBContext> options)
        : base(options)
        //public MARDBContext() 
        {
           // Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //Adds configurations for Student from separate class
        //    //modelBuilder.Configurations.Add(new StudentConfigurations());

        //    //modelBuilder.Entity<Product>()
        //    //    .ToTable("TeacherInfo");

        //    //modelBuilder.Entity<ProductCategory>()
        //    //    .MapToStoredProcedures();
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddressInformation> UserAddressInformations { get; set; }
        public DbSet<UserPaymentInformation> UserPaymentInformations { get; set; }
        public DbSet<DocumentItem> DocumentItems { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

    }
}
