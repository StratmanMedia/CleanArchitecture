using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; }
    }
}
