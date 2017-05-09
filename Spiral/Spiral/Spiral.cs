using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Spiral
 {
    /// <summary>
    /// Function which calculates the sum of each other number from start to limit
    /// Depending on the start we will need to do small adjustment due to differences
    /// between values on axis-x and axis-y.
    /// The formula is based on Gauss with small changes -> n(a+b)/2:
    /// n = Number of items
    /// a = First number
    /// b = Last number
    /// Example:
    /// 0..8 = 0 + 2 + 4 + 6 + 8 = 5 * (0+8) / 2 = 20 
    /// </summary>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <returns>A long value with the result of the sum. </returns>
    public static long SumOfValues(long start, long limit)
    {
        // Correction mentioned before
        int variation = 1;
        if (start == 0)
        {
            variation = 2;
        }
        long realLimit = limit / 2;
        long value = ((realLimit) * (start + limit - variation)) / 2;
        return 4 * value;
    }

    /// <summary>
    /// Calculates the value at the Spiral for the point (0, y)
    /// The value will be |y| + SumOfValues from k to twice |y|
    /// </summary>
    /// <param name="y">Axis-y Value</param>
    /// <returns> Spiral(0,Y) </returns>
    public static long getValueForY(int y)
    {
        int k = 1;
        if (y < 0)
        {
            k = 0;
        }
        return Math.Abs(y) + SumOfValues(k, 2 * Math.Abs(y));
    }

    /// <summary>
    /// Calculates the value at the Spiral for the point (x, 0)
    /// The value will be |x| + SumOfValues from k to twice |x|
    /// </summary>
    /// <param name="x">Axis-x Value</param>
    /// <returns> Spiral(x, 0) </returns>
    public static long getValueForX(int x)
    {
        int k = 0;
        if (x < 0)
        {
            k = 1;
        }
        return 3 * Math.Abs(x) + SumOfValues(k, 2 * Math.Abs(x));
    }


    /// <summary>
    /// Will calculate the values of points x, y for values of y >= 0
    /// </summary>
    /// <param name="x">Coordinate value of axis-x</param>
    /// <param name="y">Coordinate value of axis-y</param>
    /// <returns>Spiral(x,y)</returns>
    public static long ValueFromPositiveAxisY(int x, int y)
    {   
        // Y must be positive
        if (y < 0)
        {
            return -1;
        }
        // Value goes from right to left
        if (-y <= x && x <= y)
        {
            return getValueForY(y) - x;
        }
        // Value goes from down to up
        return getValueForX(x) + y;
    }

    /// <summary>
    /// Will calculate the values of points x, y for values of y <= 0
    /// </summary>
    /// <param name="x">Coordinate value of axis-x</param>
    /// <param name="y">Coordinate value of axis-y</param>
    /// <returns>Spiral(x,y)</returns>
    public static long ValueFromNegativeAxisY(int x, int y)
    {
        // Y must be negative
        if (y > 0)
        {
            return -1;
        }
        // Value goes from left to right
        if (y < x && x <= -y)
        {
            return getValueForY(y) + x;
        }
        // Value goes from up to down
        return getValueForX(x) - y;
    }

    /// <summary>
    /// Check that the given values are inside the limits |1000000|
    /// </summary>
    /// <param name="x">Axis-X value</param>
    /// <param name="y">Axis-Y value</param>
    /// <returns>False if the given values are greater of the limits</returns>
    public static bool AreLimitsCorrect(int x, int y)
    {
        if ((Math.Abs(x) >= 1000000) || (Math.Abs(y) >= 1000000))
        {
            Console.Error.WriteLine("Error: Input values are between -1000000 -> 1000000");
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the value at the point x, y of a Spiral type like:
    /// ... 20  19  18  17  16
    ///     21  6   5   4   15
    ///     22  7   0   3   14
    ///     23  8   1   2   13
    ///     24  9   10  11  12
    ///     25  26  27  28  29 ...
    /// Where 0 is the origin x=0, y=0.
    /// The method to calculate it is based on the values of the axis-y or axis-x
    /// We first check value of y in order to calculate if we are in horizontal
    /// or vertical move.
    /// Then, we calculate the value at (0, y) or (x, 0) and add or substract n steps which
    /// will be x or y depending on the situation.
    /// </summary>
    /// <param name="x">Axis-x value</param>
    /// <param name="y">Axis-y value</param>
    /// <returns>Spiral(x, y)</returns>
    public static long GetNumberAtPosition(int x, int y)
    {
        if (!AreLimitsCorrect(x, y))
        {
            return -1;
        }
        if (y >= 0)
        {
            return ValueFromPositiveAxisY(x, y);
        }
        return ValueFromNegativeAxisY(x, y);
    }

    public static int Main()
    {

        int x;
        int y;
        Console.WriteLine("Spiral values");
        Console.WriteLine("...  20  19  18  17  16");
        Console.WriteLine("...  21  6   5   4   15");
        Console.WriteLine("...  22  7   0   3   14");
        Console.WriteLine("...  23  8   1   2   13");
        Console.WriteLine("...  24  9   10  11  12");
        Console.WriteLine("...  25  26  27  28  29 ...");

        Console.WriteLine("Press 1 to manual input");
        Console.WriteLine("Press 2 to run some hardcoded values");
        int k = int.Parse(Console.ReadLine());
        if (k == 1)
        {
            Console.WriteLine("Insert value for x: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert value for y: ");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Value for: (" + x + ", " + y + ") = " + GetNumberAtPosition(x, y));
        }
        else
        {
            Console.WriteLine("Value for: (5, -5) = " + GetNumberAtPosition(5, -5));
            Console.WriteLine("Value for: (0, -3) = " + GetNumberAtPosition(0, -3));
            Console.WriteLine("Value for: (2, 2) = " + GetNumberAtPosition(2, 2));
            Console.ReadKey();
        }
        return 0;
    }
}
