﻿using ForgetfulJames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ForgetfulJames.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        DbSet<ToDo> ToDo { get; set; }
    }
}
