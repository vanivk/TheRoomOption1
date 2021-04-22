using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Bogus;
using System.Linq;
using System.Collections.Generic;

namespace Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DataContext() : base()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var connString = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=PromoCodeData";
                optionsBuilder.UseSqlServer(connString, options =>
                {

                }).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var now = "getdate()";
            // PROMOCODES
            var promocodeEntity = modelBuilder.Entity<Promocode>();

            promocodeEntity
              .HasMany(s => s.Users)
              .WithMany(b => b.Promocodes)
              .UsingEntity<UserPromocode>
               (bs => bs.HasOne<User>().WithMany(),
                bs => bs.HasOne<Promocode>().WithMany())
              .Property(bs => bs.DateActivated)
              .HasDefaultValueSql(now);

            promocodeEntity.Property(p => p.AvailableFrom)
                .HasDefaultValueSql(now);
            promocodeEntity.Property(p => p.DateAdded)
                .HasDefaultValueSql(now);
            promocodeEntity.Property(p => p.Status)
                .HasDefaultValue(false);

            // SERVICES
            var serviceEntity = modelBuilder.Entity<Service>();

            serviceEntity.Property(s => s.DateAdded)
                .HasDefaultValueSql(now);


            // USERS
            var usersEntity = modelBuilder.Entity<User>();

            usersEntity.Property(u => u.Status)
                .HasDefaultValue(true);


            // REFRESH TOKENS
            var refreshTokensEntity = modelBuilder.Entity<RefreshToken>();

            refreshTokensEntity.HasKey(rt => rt.Token);

            // SEED FOR TEST
            var appUser = new User("test_user@optionone.com")
            {
                Id = "02994cf0–3422–5cfe-erye-62f706d98cf6",
                Email = "test_user@optionone.com",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "User",
                NormalizedUserName = "test_user@optionone.com"
            };

            var ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "12345");

            modelBuilder.Entity<User>().HasData(appUser);



            var services = new Faker<Service>()
                 .RuleFor(s => s.Id, f => f.IndexFaker + 1)
                 .RuleFor(s => s.Name, f => f.Company.CompanyName())
                 .RuleFor(s => s.Description, f => f.Lorem.Paragraphs(f.Random.Int(1, 2))).Generate(20);

            modelBuilder.Entity<Service>().HasData(services);


            var promocodes = new List<Promocode>();
            var pf = new Faker<Promocode>();
            services.Skip(1).ToList().ForEach(s =>
            {
                var pc = new Faker().Random.Int(5, 25);
                promocodes.AddRange(pf
                    .RuleFor(s => s.Id, f => f.IndexFaker + 1)
                    .RuleFor(p => p.ServiceId, f => s.Id)
                    .RuleFor(p => p.Status, f => f.Random.Bool(.90f))
                    .RuleFor(p => p.Code, f => f.Random.String2(f.Random.Int(5, 12)))
                    .RuleFor(p => p.Description, f => f.Lorem.Text())
                    .RuleFor(p => p.AvailableFrom, f => f.PickRandom(DateTime.Now, f.Date.Past(), f.Date.Soon()))
                    .RuleFor(p => p.AvailableTill, f => f.PickRandom(f.Date.Past(), f.Date.Soon()))
                    .Generate(pc));
            });

            modelBuilder.Entity<Promocode>().HasData(promocodes);
        }
    }
}
