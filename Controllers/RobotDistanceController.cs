using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RobotDistanceApi.Models;
using System.Linq;
using System.Text.Json;

namespace RobotDistanceApi.Controllers
{
    [ApiController]
    [Route("robots")]
    public class RobotDistanceController : ControllerBase
    {
        private readonly ILogger<RobotDistanceController> _logger;
        private HttpClient client = new();
        

        public RobotDistanceController(ILogger<RobotDistanceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("closest")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async IAsyncEnumerable<Robot> Post(Load load)
        {
            await using Stream stream = await client.GetStreamAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
            var robots = await JsonSerializer.DeserializeAsync<List<Robot>>(stream);

            foreach (Robot robot in robots)
            {
                double distanceToGoal = Math.Sqrt(Math.Pow(robot.x - load.x, 2) + Math.Pow(robot.y - load.y, 2));
                robot.distanceToGoal = distanceToGoal;
            }
            Robot closestRobot = robots.Find(robot => robot.distanceToGoal == robots.Min(robot => robot.distanceToGoal));

            yield return closestRobot;
        }
    }
}