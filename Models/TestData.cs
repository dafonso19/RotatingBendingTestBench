namespace RotatingBendingTestBench.Models
{
    public class TestData
    {
        public int Id { get; set; }
        public int TestSimulatorId { get; set; } // Foreign key
        public double RotationSpeedSetpoint { get; set; } // RPM
        public int Duration { get; set; } // Seconds
    }
}
