﻿using BussinessObject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Database
{
    public class PetManagementContext : DbContext
    {
        public PetManagementContext(DbContextOptions<PetManagementContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PetRecord> PetRecords { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Kennel> Kennels { get; set; }
        public DbSet<KennelRecord> KennelRecords { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Định nghĩa khóa ngoại cho quan hệ giữa Booking và User
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            // Định nghĩa khóa ngoại cho quan hệ giữa PetRecord và Pet
            modelBuilder.Entity<PetRecord>()
                .HasOne(pr => pr.Pet)
                .WithMany(p => p.PetRecords)
                .HasForeignKey(pr => pr.PetId);

            // Định nghĩa khóa ngoại cho quan hệ giữa PetRecord và Vet
            modelBuilder.Entity<PetRecord>()
                .HasOne(pr => pr.Vet)
                .WithMany(v => v.PetRecords)
                .HasForeignKey(pr => pr.VetId);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
