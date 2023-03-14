# RobotDistanceApi

## Additional Thoughts and Features

- Method to route low battery Robots to charging stations
> I would add an additional function that checks current battery level, if that level is below a certain percentage (say, 10%) it would send a command to move the robot to its nearing charging station (if applicable)
- Z axis coordinates if load point is larger than a single load
> I'm sure there are plenty of scenarios where a robot is working in an environment (say a grocery warehouse) that could have multiple rows stacked sequentially behind each other, I think adding a check for an additional axis would help ensure depth within a load point.
