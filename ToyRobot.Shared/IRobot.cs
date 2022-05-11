namespace ToyRobot.Shared;

public interface IRobot
{ 
    int PositionX { get; set; }
    int PositionY { get; set; }
    Direction Direction { get;  set; }
    bool IsPlaced { get; set; }
    void Place(int x, int y, Direction? direction);
    void RotateRight();
    void RotateLeft();
    string GetReport();
}