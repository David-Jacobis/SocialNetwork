using DataAccess.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Reflection.Emit;

namespace DataAccess.Context
{
    public class MainContext : DbContext
    {
        //private readonly IUser _user;
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<User> TabMapUsuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("MAIN");

            builder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(false);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
