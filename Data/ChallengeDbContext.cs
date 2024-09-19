namespace Data
{
    using Data.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class ChallengeDbContext : DbContext
    {
        public DbSet<TTask> Task { get; set; }

        public ChallengeDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            

            var path = Environment.GetEnvironmentVariable("DB_PATH") ?? "";
            path = Path.Combine(path, "task.db");
            options.UseSqlite($"Data Source={path}");
        }

    }
}
