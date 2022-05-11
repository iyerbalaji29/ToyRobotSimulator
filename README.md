**Toy Robot Simulator**

Created a console application that can read in commands of the following form:

-PLACE X, Y, DIRECTION
-MOVE
-LEFT
-RIGHT
-REPORT

**Movements**:-
You will need to initiate the robot with PLACE command (even if its misplaced or out of the board/table).
You can move the robot to any direction unless its not out of the table which is when you will need to do a PLACE command again to reset with position

**Steps to Run**:-

To run the code, just clone the repository in a chosen folder location.
Open a terminal/Command prompt and navigate to the cloned folder
Go until the rootfolder ~\ToyRobot\

Now run the following command   **"dotnet publish --configuration Release"**
This should populate the release folder under the below mentioned path

**~\ToyRobot\bin\Release\net6.0\publish**

Inside publish folder, you should see an executable file named ToyRobot.exe

Open it in the terminal and shoot commands as above.



