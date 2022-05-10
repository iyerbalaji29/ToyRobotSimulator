using System.Security.Cryptography.X509Certificates;

namespace ToyRobot.Shared;

public class TableTop
{
    public int AxisX { get; set; }
    public int AxisY { get; set; }
    
    public TableTop(int axisX, int axisY)
    {
        this.AxisX = axisX;
        this.AxisY = axisY;
    }
    
    public bool IsValid(int x, int y)
    {
        return x < AxisX && x >= 0 &&
               y < AxisY && y >= 0;
    }
}