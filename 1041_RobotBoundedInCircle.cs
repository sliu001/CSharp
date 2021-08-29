/*
LC1041: On an infinite plane, a robot initially stands at (0, 0) and faces north. The robot can receive one of three instructions:
"G": go straight 1 unit;
"L": turn 90 degrees to the left;
"R": turn 90 degrees to the right.
The robot performs the instructions given in order, and repeats them forever.

Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.

Input: instructions = "GGLLGG"
Output: true
Explanation: The robot moves from (0,0) to (0,2), turns 180 degrees, and then returns to (0,0).
When repeating these instructions, the robot remains in the circle of radius 2 centered at the origin.

Input: instructions = "GG"
Output: false
Explanation: The robot moves north indefinitely.
*/

public class Solution {
    private int currentDirNum = 0;
        
    public bool IsRobotBounded(string instructions) {
        int x = 0, y = 0;
        
        for (var i = 0; i<4; i++)
        {
            foreach (var c in instructions)
            {                
                if (c == 'L')
                    currentDirNum--;
                else if (c == 'R')
                    currentDirNum++;
                else if (c == 'G')
                {                    
                    var dirIdx = getDirectionIndex(c);
                    
                    if (dirIdx == 0) //up
                        y++;
                    else if (dirIdx == 1) //right
                        x++;
                    else if (dirIdx == 2) //down
                        y--;
                    else    //left
                        x--;
                }
            }
        }
        
        return (x==0 && y==0) ? true: false;
    }
    
    private int getDirectionIndex(char instr)
    {
        if (currentDirNum < 0)
            return 4+(1+currentDirNum)%4 - 1;
        else
            return (1+currentDirNum)%4 - 1;
    }
}
