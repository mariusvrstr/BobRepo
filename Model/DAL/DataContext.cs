﻿
namespace JBOB
{
    using System.Data.Entity;
    using Database.Entities;
    
    internal partial class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
