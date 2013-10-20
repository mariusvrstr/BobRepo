
namespace JBOB
{
    using System.Data.Entity;
    using Entities;
    
    internal partial class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
