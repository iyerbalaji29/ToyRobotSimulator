using ToyRobot.Shared;

namespace ToyRobot.Services;

public interface IRobotService
{
    Robot Process(string input);
}