using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using ToyRobot.Shared;

namespace ToyRobot.Services.Tests;

public class RobotServiceTests
{
    private Robot _toyRobot;
    private IRobotService _service;
    [SetUp]
    public void Setup()
    {
        _toyRobot = new Robot();
        _service = new RobotService(new Logger<RobotService>(new NullLoggerFactory()),_toyRobot);
    }
    
    [Test]
    public void Is_Robot_Placed()
    {
        var robot = _service.Process("Place 0,0,North");
        Assert.IsTrue(robot.IsPlaced);
    }
    
    [Test]
    public void Robot_Should_Not_Be_Placed()
    {
        var robot = _service.Process("Move");
        Assert.IsFalse(robot.IsPlaced);
    }
    
    [Test]
    public void Robot_Should_Be_Move_After_Place_Command()
    {
        var robot = _service.Process("Place 2,3,North");
        robot = _service.Process("Move");
        Assert.IsTrue(robot.IsPlaced);
        Assert.IsTrue(robot.PositionX == 2);
        Assert.IsTrue(robot.PositionY == 4);
        Assert.IsTrue(robot.Direction == Direction.North);
    }
    
    [TestCase("Place 2,3,North")]
    [TestCase("Place 2,4,North")]
    public void Robot_Should_Not_Move_After_Place_Command(string input)
    {
        var robot = _service.Process(input);
        Assert.IsTrue(robot.IsPlaced);
        Assert.IsTrue(robot.Direction == Direction.North);
    }
    
    [TestCase("Place 2,3,North")]
    [TestCase("Place 2,4,North")]
    public void Robot_Should_Not_Move_Right_After_Place_Command(string input)
    {
        var robot = _service.Process(input);
        Assert.IsTrue(robot.IsPlaced);
        Assert.IsTrue(robot.Direction == Direction.North);
    }
    
    [TestCase("Place 10,9,North")]
    [TestCase("Place 5,6")]
    [TestCase("Move")]
    public void Robot_Should_Not_Move_Since_Out_of_Table_Coordinates(string input)
    {
        var robot = _service.Process(input);
        Assert.IsFalse(robot.IsPlaced);
    }
    [Test]
    public void Robot_Should_Move_Example1()
    {
        _toyRobot = _service.Process("PLACE 0,0,NORTH");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("REPORT");
        Assert.IsTrue(_toyRobot.GetReport() == "0,1,NORTH" );
    }
    [Test]
    public void Robot_Should_Move_Example2()
    {
        _toyRobot = _service.Process("PLACE 0,0,NORTH");
        _toyRobot = _service.Process("LEFT");
        _toyRobot = _service.Process("REPORT");
        Assert.IsTrue(_toyRobot.GetReport() == "0,0,WEST" );
    }
    
    [Test]
    public void Robot_Should_Move_Example3()
    {
        _toyRobot = _service.Process("PLACE 1,2,EAST");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("LEFT");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("REPORT");
        Assert.IsTrue(_toyRobot.GetReport() == "3,3,NORTH" );
    }
    
    [Test]
    public void Robot_Should_Move_Example4()
    {
        _toyRobot = _service.Process("PLACE 1,2,EAST");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("LEFT");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("PLACE 3,1");
        _toyRobot = _service.Process("MOVE");
        _toyRobot = _service.Process("REPORT");
        Assert.IsTrue(_toyRobot.GetReport() == "3,2,NORTH" );
    }
}