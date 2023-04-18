using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Entities;
using MyPlace.BusinessLogic.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Contexts
{
    public class MyPlaceDbContext : DbContext
    {
        public MyPlaceDbContext(DbContextOptions<MyPlaceDbContext> options) : base(options) { }


        public DbSet<Building> Buildings { get; set; } = null!;
        public DbSet<Office> Offices { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Reservation>(builder =>
            {
                builder.Property(x => x.Date)
                    .HasConversion<Helpers.DateOnlyConverter, DateOnlyComparer>();

            });

            base.OnModelCreating(modelBuilder);

        }

    }
}
