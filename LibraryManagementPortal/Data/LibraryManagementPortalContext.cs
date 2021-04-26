using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementPortal.Data
{
    public class LibraryManagementPortalContext : DbContext
    {
        public LibraryManagementPortalContext(DbContextOptions<LibraryManagementPortalContext> options) :
            base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>().HasKey(o => new { o.BookId, o.OrderId });

            builder.Entity<Order>()
                .HasMany(o => o.OrderDetail)
                .WithOne(od => od.Order)
                .HasForeignKey(o => o.OrderId)
                .IsRequired();

            builder.Entity<Book>()
               .HasMany(o => o.OrderDetail)
               .WithOne(od => od.Book)
               .HasForeignKey(o => o.BookId)
               .IsRequired();

            builder.Entity<User>()
               .HasMany(u => u.Orders)
               .WithOne(o => o.User)
               .HasForeignKey(o => o.UserId)
               .IsRequired();


            builder.Entity<Role>().HasData(
                new Role { Id = "1", Name = "Admin", CreateAt = new DateTime(2021, 01, 14) },
                new Role { Id = "2", Name = "Normal", CreateAt = new DateTime(2021, 01, 14) }
            );
            builder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    Name = "admin",
                    email = "chunguyenchuong2014bg@gmail.com",
                    Password = "123",
                    RoleId = "1",
                    CreateAt = new DateTime(2021, 01, 14)
                },
                new User
                {
                    Id = "2",
                    Name = "user",
                    email = "chuongcnbhaf180208@fpt.edu.vn",
                    Password = "123",
                    RoleId = "2",
                    CreateAt = new DateTime(2021, 01, 14),
                }
                );
            builder.Entity<Category>().HasData(
            new Category { Id = "1", Name = "Anime", Description = "Anime type", CreateAt = new DateTime(2021, 01, 14) },
            new Category { Id = "2", Name = "Romantic", Description = "Romatic type", CreateAt = new DateTime(2021, 01, 14) }
            );
            builder.Entity<Author>().HasData(
                new Author { Id = "1", Name = "Chu Nguyen Chuong", CreateAt = new DateTime(2021, 01, 14) },
                new Author { Id = "2", Name = "Some One Else", CreateAt = new DateTime(2021, 01, 14) }
                );
            builder.Entity<Book>().HasData(
                new Book { Id = "1", AuthorId = "1", CategoryId = "1", CountBook = 10, Name = "tesst name", CreateAt = new DateTime(2021, 01, 14), });
            builder.Entity<Order>().HasData(
                new Order { Id = "2", Name = "test order", UserId = "1", CreateAt = new DateTime(2021, 01, 14), Status = true }
                );
        }
        public DbSet<LibraryManagementPortal.Models.Book> Book { get; set; }
    }
}
