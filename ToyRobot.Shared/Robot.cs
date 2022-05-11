using ToyRobot.Shared.Utils;

namespace ToyRobot.Shared;

public class Robot: IRobot
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public Direction Direction { get; set; }
    public bool IsPlaced { get; set; }

    public void Place(int x, int y, Direction? direction)
    {
        this.PositionX = x;
        this.PositionY = y;
        this.IsPlaced = true;
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
        Rotate(2);
    }

    public void RotateRight()
    {
        Rotate(-2);
    }

    public string GetReport()
    {
        return $"{PositionX},{PositionY},{Direction.GetDisplayName()}";
    }
    
    

    private void Rotate(int rotationNumber)
    {
        var directions = (Direction[]) Enum.GetValues(typeof(Direction));
        var filteredDirections = directions.Except(new []{Direction.None});
        var directionArray = filteredDirections.ToArray();
        Direction newDirection;
        if (Direction + rotationNumber < 0)
        {
            newDirection = directionArray[directionArray.Length - 1];
        }
        else
        {
            var index = (int) (Direction + rotationNumber) % directionArray.Length;
            newDirection = directionArray[index];
        }

        Direction = newDirection;
        IsPlaced = true;
    } 
}
