using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Thing> Things { get; set; }
    }
}