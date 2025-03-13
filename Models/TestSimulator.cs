namespace RotatingBendingTestBench.Models
{
    public class TestSimulator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TestData> Data { get; set; } = new();
        public List<TestResult> Results { get; set; } = new();
    }
}
