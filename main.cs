using System.IO;
using System;

class Spiral
{
    // Function for human debugging, showing in the console the values
    // that x, and y produces at (x,0) and (0,y).
    private static void showValues(int x, int y)
    {
        long yValue = getValueForY(y);
        long xValue = getValueForX(x);

        Console.WriteLine("Value for x: " + x + " = " + xValue);
        Console.WriteLine("Value for y: " + y + " = " + yValue);
    }


    // To calculate (X,0) and (0,Y) the loop is same but it differs
    // on the start and limit of it.
    // For the return value formula of getValueForY or getValueForX
    // the loop is: 4*Sum(i) where i > start and i < limit
    private static long SumLoop(int start, int limit)
    {
        long value = 0;
        for (int i = start; i < limit; i+=2)
        {
            value += i;
        }
        return 4*value;
    }

    // The value of the spiral at the point (0,Y) will be:
    // Y + 4*Sum(i) where i > (0|1) and i < 2*abs(y) with double step.
    // ** Explanation of this calculations will be given later.
    private static long getValueForY(int y)
    {
        int k = 1;
        if (y < 0)
        {
            k = 0;
        }
        return Math.Abs(y) + SumLoop(k, 2*Math.Abs(y));
    }

    // The value of the spiral at the point (x,0) will be:
    // 3*x + 4*Sum(i) where i > (1|0) and i < 2*abs(x) with double step.
    // ** Explanation of this calculations will be given later.
    private static long getValueForX(int x)
    {
        int k = 0;
        if (x < 0)
        {
            k = 1;
        }
        return 3*Math.Abs(x) + SumLoop(k, 2*Math.Abs(x));
    }

    /*
    Method used to calculate the number:

    1) Check on which y-axis we are. We need that in order to do the 2nd step
    2) We determine wherever we are in a horizontal or vertical move
    2-a) If we are in horizontal move we get the value at (0,y) and move x times.
    2-b) Otherwise, we are in a vertical move. Returned value will be (x,0) and move y times.

    3)  This is not an step itself but a call to get either value at (0,y) or at (x,0)
        given by the functions getValueForX or getValueForY.
    */
    public static long GetNumberAtPosition(int x, int y)
    {
        if (x>Math.Abs(10000) || y>Math.Abs(10000))
        {
            Console.Error.WriteLine("Error: Input values are between -1000000 -> 1000000");
            return -1;
        }
        if (y >= 0)
        {
            if (-y <= x && x<= y) // Horizontal move
            {
                return getValueForY(y)-x;
            }
            else // Vertical move
            {
                return getValueForX(x)+y;
            }
        }
        else
        {
            if (y < x && x <= -y) //Horizontal move
            {
                return getValueForY(y)+x;
            }
            else // Vertical move
            {
                return getValueForX(x)-y;
            }
        }
    }

    //  Internal function which checks that the result of GetNumberAtPosition is same as
    //  the expected one.
    public static void CheckValue(int x, int y, long expected)
    {
        long result = GetNumberAtPosition(x,y);
        if (result != expected)
        {
            Console.WriteLine("Error, expected and given values are not same: ("+x+","+y+") != "+expected);
        }
    }

    static void Main()
    {
        Console.WriteLine("Spiral value will run some basic tests now.");

        CheckValue(1,1,4);
        CheckValue(0,1,5);
        CheckValue(-1,1,6);
        CheckValue(2,2,16);
        CheckValue(1,2,17);
        CheckValue(0,2,18);
        CheckValue(-1,2,19);
        CheckValue(-2,2,20);

        CheckValue(-4, -5, 81);
        CheckValue(-3, -5, 82);
        CheckValue(-2, -5, 83);
        CheckValue(-1, -5, 84);
        CheckValue(0, -5, 85);
        CheckValue(-1,-1, 8);
        CheckValue(-2, -1, 23);
        CheckValue(0, 0, 0);
    }
}
