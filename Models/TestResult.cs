namespace RotatingBendingTestBench.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public int TestSimulatorId { get; set; } // Foreign key
        public DateTime Timestamp { get; set; }
        public double RotationSpeed { get; set; } 
        public double StressLevel { get; set; } 
        public double Temperature { get; set; } 
    }
}
