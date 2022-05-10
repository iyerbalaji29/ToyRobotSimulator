using ToyRobot.Shared.Utils;

namespace ToyRobot.Shared;

public class ToyRobot
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public Direction Direction { get; private set; }
    
    public string Report { get; set; }
    
    public void Place(int x, int y, Direction? direction)
    {
        this.PositionX = x;
        this.PositionY = y;
        if(direction!= null)
            this.Direction = direction.Value;
    }

    public (int, int) GetNextPosition()
    {
        switch (Direction)
        {
            case Direction.North:
                PositionY += 1;
                break;
            case Direction.East:
                PositionX += 1;
                break;
            case Direction.South:
                PositionY -= 1;
                break;
            case Direction.West:
                PositionX -= 1;
                break;
        }

        return (PositionX, PositionY);
    }

    public void RotateLeft()
    {
        Rotate(-1);
    }

    public void RotateRight()
    {
        Rotate(1);
    }

    public string GetReport()
    {
        return $"Robot Position: {PositionX}, {PositionY}, {Direction.GetDisplayName()}";
    }

    private void Rotate(int rotationNumber)
    {
        var directions = (Direction[]) Enum.GetValues(typeof(Direction));
        Direction newDirection;
        if (Direction + rotationNumber < 0)
            newDirection = directions[directions.Length - 1];
        else
        {
            var index = (int) (Direction + rotationNumber) % directions.Length;
            newDirection = directions[index];
        }

        Direction = newDirection;
    } 
}