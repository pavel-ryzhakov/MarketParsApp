using MarketParsApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketParsApp.Data.DataBase
{
    internal class DataBaseContext : DbContext

    {
        //public DataBaseContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }



        public DbSet<Processor> Processors { get; set; } = null!;
        public DbSet<Motherboard> Motherboards { get; set; } = null!;
        public DbSet<GraphicCard> GraphicCards { get; set; } = null!;
        public DbSet<RanAcMemory> RanAcMemories { get; set; } = null!;
        public DbSet<ProcessorCooler> ProcessorCoolers { get; set; } = null!;
        public DbSet<SolStateDrive> SolStateDrives { get; set; } = null!;
        public DbSet<HardDisk> HardDisks { get; set; } = null!;
        public DbSet<PowSuppUnit> PowSuppUnits { get; set; } = null!;
        public DbSet<PcCase> PcCases { get; set; } = null!;
    }
}
