﻿using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.DataBase
{
    public class DataBaseService: DbContext, IDataBaseService
    {

        public DataBaseService(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<UserEntity> User {  get; set; }

        public DbSet<CustomerEntity> Customer { get; set; }

        public DbSet<BookingEntity> Booking { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0 ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de la clave primaria para BookingEntity
            modelBuilder.Entity<BookingEntity>()
                .HasKey(b => b.BookingId); // Aquí defines la clave primaria

            // Configuración de otras entidades
            EntityConfiguration(modelBuilder);

        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }
    }
}
