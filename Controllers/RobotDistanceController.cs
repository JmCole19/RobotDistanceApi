using Microsoft.AspNetCore.Mvc;
using RobotDistanceApi.Models;
using System.Text.Json;

namespace RobotDistanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotDistanceController : ControllerBase
    {
        private readonly ILogger<RobotDistanceController> _logger;
        private HttpClient client = new();

        public RobotDistanceController(ILogger<RobotDistanceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "RobotList")]
        public async IAsyncEnumerable<Robot[]> Get()
        {
            await using Stream stream = await client.GetStreamAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
            var robots = await JsonSerializer.DeserializeAsync<List<Robot>>(stream);

            foreach (var robot in robots)
            {
                Console.WriteLine("RobotID: " + robot.robotId + " BatteryLevel: " + robot.batteryLevel);
            }

            yield return Enumerable.Range(1, 5).Select(index => new Robot()).ToArray();
        }
    }
}