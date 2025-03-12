using Microsoft.EntityFrameworkCore;
using RotatingBendingTestBench.Models;

namespace RotatingBendingTestBench.Data
{
    public class TestBenchContext : DbContext
    {
        public DbSet<TestSimulator> TestSimulator { get; set; }
        public DbSet<TestData> TestData { get; set; }
        public DbSet<TestResult> TestResult { get; set; }

        public TestBenchContext(DbContextOptions<TestBenchContext> options) : base(options) { }
    }
}
