namespace RobotDistanceApi.Models
{
    public class Robot
    {
        public string robotId { get; set; }
        public int batteryLevel { get; set; }
        public int y { get; set; }
        public int x { get; set; }
        public double distanceToGoal { get; set; }
    }
}