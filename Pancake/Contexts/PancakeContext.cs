using Microsoft.EntityFrameworkCore;
using Pancake.Configurations;
using Pancake.Models;

namespace Pancake.Contexts
{
    public class PancakeContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<WordsTableModel> Words { get; set; }

        public PancakeContext(PancakeConfiguration pancakeConfiguration)
        {
            _connectionString = pancakeConfiguration.DBConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}