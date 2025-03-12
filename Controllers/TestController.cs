using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotatingBendingTestBench.Data;
using RotatingBendingTestBench.Models;
using RotatingBendingTestBench.Services;

namespace RotatingBendingTestBench.Controllers
{
    public class TestController : Controller
    {
        private readonly TestBenchContext _context;
        private readonly TestSimulationService _simulationService;

        public TestController(TestBenchContext context, TestSimulationService simulationService)
        {
            _context = context;
            _simulationService = simulationService;
        }
        //Get: display form
        public IActionResult Index()
        {
            return View(new TestSimulator());
        }
        //POst: star the simulation
        [HttpPost]
        public IActionResult Start(TestSimulator simulator)
        {
            if (ModelState.IsValid)
            {
                _context.TestSimulator.Add(simulator);
                _context.SaveChanges(); //save sequence and id

                var results = _simulationService.SimulateTest(simulator);
                _context.TestResult.AddRange(results);
                _context.SaveChanges(); //save results

                return RedirectToAction("Results", new { id = simulator.Id });
            }
            return View("Index", simulator);
        }
        //Get: Display results
        public IActionResult Result(int id)
        {
            var simulator = _context.TestSimulator
                .Include(x => x.Data)
                .Include(x => x.Results) 
                .FirstOrDefault(x => x.Id == id);
            if (simulator == null) return NotFound();
            return View(simulator);
        }
    }
}
