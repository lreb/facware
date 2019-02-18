using System;
using Microsoft.EntityFrameworkCore;
using NetCore.Data.Access.Models;

namespace NetCore.Data.Access
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<SystemConfiguration> SystemConfiguration { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}
