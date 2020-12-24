using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Korelskiy.GlobalStatistic.Domain.Entities;

namespace Korelskiy.GlobalStatistic.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a911265e-b593-44c5-88c3-eb0aea4744d1",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "09cc1511-1fcd-4d8b-8d38-e71eb472aafd",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "korelskiy.kirill@mail.ru",
                NormalizedEmail = "KORELSKIY.KIRILL@MAIL.RU",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "parol"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "a911265e-b593-44c5-88c3-eb0aea4744d1",
                UserId = "09cc1511-1fcd-4d8b-8d38-e71eb472aafd"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id =  new Guid("8ed2bad5-c323-4259-9f95-56d836056336"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("46f47f9a-4439-41ec-9bce-195f8ef50483"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("750e0c7c-2ed3-4cb7-abf7-679571b33cdb"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
