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

        public PancakeContext()
        {
            _connectionString = "Host=localhost;Database=Words;Username=postgres;Password=marshmallow";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}