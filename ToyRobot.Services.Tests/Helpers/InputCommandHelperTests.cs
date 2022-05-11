using NUnit.Framework;
using ToyRobot.Services.Helpers;

namespace ToyRobot.Services.Tests.Helpers
{
    public class InputCommandHelperTests
    {
        [Test]
        public void Is_Valid_Command()
        {
            var isValid= InputCommandHelper.IsValid("Place 0,0,North");
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Is_Invalid_Command_With_Space_Between_Direction()
        {
            var isInvalid = InputCommandHelper.IsValid("Place 0,0, North");
            Assert.IsFalse(isInvalid);
        }

        [Test]
        public void Is_Invalid_Command_With_Random()
        {
            var isInvalid = InputCommandHelper.IsValid("test");
            Assert.IsFalse(isInvalid);
        }

        [Test]
        public void Is_Valid_Command_With_Valid_Action()
        {
            var isValid = InputCommandHelper.IsValid("move");
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Is_Valid_Command_With_Valid_Action_Case_Insensitive()
        {
            var isValid = InputCommandHelper.IsValid("mOvE");
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Is_Valid_Command_With_Place_Action_Without_Direction()
        {
            var isValid = InputCommandHelper.IsValid("Place 2,1");
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Parse_Place_Without_Direction_Successfully()
        {
            var isValid = InputCommandHelper.IsValid("Place 2,1");
            Assert.IsTrue(isValid);

            var command = InputCommandHelper.ParseCommand("Place 2,1");
            Assert.IsTrue(command.Action == Shared.RobotAction.Place);
            Assert.IsTrue(command.PositionX == 2);
            Assert.IsTrue(command.PositionY == 1);
        }

        [Test]
        public void Parse_Move_Action_Successfully()
        {
            var isValid = InputCommandHelper.IsValid("Move");
            Assert.IsTrue(isValid);

            var command = InputCommandHelper.ParseCommand("Move");
            Assert.IsTrue(command.Action == Shared.RobotAction.Move);
        }

        [Test]
        public void Parse_Left_Successfully()
        {
            var isValid = InputCommandHelper.IsValid("Left");
            Assert.IsTrue(isValid);

            var command = InputCommandHelper.ParseCommand("LEft");
            Assert.IsTrue(command.Action == Shared.RobotAction.Left);
        }
    }
}