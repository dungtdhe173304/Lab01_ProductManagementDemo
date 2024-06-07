using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MyStoreContext : DbContext
    {
        // Các thuộc tính DbSet để đại diện cho các bảng trong cơ sở dữ liệu
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Override phương thức OnConfiguring để thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Thiết lập chuỗi kết nối đến cơ sở dữ liệu của bạn
            optionsBuilder.UseSqlServer("Server=DUNGTD\\MSSQLSERVER01;uid=sa;pwd=123;Database=MyStoreProductManagement;Trusted_Connection=True;");
        }

        // Override phương thức OnModelCreating để cấu hình Fluent API nếu cần thiết
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình các mối quan hệ hoặc thuộc tính của các thực thể nếu cần thiết
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
