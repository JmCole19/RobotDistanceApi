using Microsoft.AspNetCore.Mvc;
using RobotDistanceApi.Models;

namespace RobotDistanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotDistanceController : ControllerBase
    {
        private readonly ILogger<RobotDistanceController> _logger;

        public RobotDistanceController(ILogger<RobotDistanceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "RobotList")]
        public IEnumerable<Robot> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Robot
            {
            })
            .ToArray();
        }
    }
}