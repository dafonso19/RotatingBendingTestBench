using RotatingBendingTestBench.Models;


namespace RotatingBendingTestBench.Services
{
    public class TestSimulationService
    {
        private readonly Random _random = new Random();

        public List<TestResult> SimulateTest(TestSimulator simulator)
        {
            var results = new List<TestResult>();
            var currentTime = DateTime.Now;

            foreach (var data in simulator.Data)
            {
                for(var i = 0; i< data.Duration; i++)
                {
                    double speed = data.RotationSpeedSetpoint * (1 + _random.NextDouble() * 0.05 - 0.025); // ±2.5% variation
                    double stress = speed * 0.1 + _random.NextDouble() * 10; //  (MPa)
                    double temp = 20 + speed * 0.05 + _random.NextDouble() * 5; //  (Celsius)

                    results.Add(new TestResult
                    {
                        TestSimulatorId = simulator.Id,
                        Timestamp = currentTime.AddSeconds(temp),
                        RotationSpeed = speed,
                        StressLevel = stress,
                        Temperature = temp
                    });
                }
                currentTime = currentTime.AddSeconds(data.Duration);
            }
            return results;
        }
    }
}
