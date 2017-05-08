using System.IO;
using System;

class Spiral
{
	/*
	 * Function for human debugging, showing in the console the values
	 * that x, and y produces at (x,0) and (0,y).
    */
	private static void showValues(int x, int y)
	{
		long yValue = getValueForY(y);
		long xValue = getValueForX(x);

		Console.WriteLine("Value for x: " + x + " = " + xValue);
		Console.WriteLine("Value for y: " + y + " = " + yValue);}


	/*
	 * To calculate (X,0) and (0,Y) the Sum is same but it differs
	 * on the start and limit of it.
	 * For the return value formula of getValueForY or getValueForX
	 * the loop is: 4*Sum(i) where i > start and i < limit and we only want
	 * the pair values not all.
	 * So this is based on Gauss, using this formula instead of a loop:
	 * n(a+b)/2 where
	 * n = Number of items
	 * a = First numer
	 * b = Last number
	 * For example:
	 * 0..8 = 0+2+4+6+8 where in our formula 5*(0+8) / 2 = 20
    */
	private static long SumOfValues(int start, int limit)
	{
		// This variation is needed because of the differences between
		// X and Y axis and the spiral values.
		int variation = 1;
		if (start == 0)
		{
			variation = 2;
		}
		int realLimit = limit / 2;
		long value = ((realLimit) * (start + limit - variation)) / 2;
		return 4 * value;
	}

	/* The value of the spiral at the point (0,Y) will be:
	 * Y + 4*Sum(i) where i > (0|1) and i < 2*abs(y) with double step.
	 * Explanation of this calculations will be given later.
	*/
	private static long getValueForY(int y)
	{
		int k = 1;
		if (y < 0)
		{
			k = 0;
		}
		return Math.Abs(y) + SumOfValues(k, 2 * Math.Abs(y));
	}

	/*
	 * The value of the spiral at the point (x,0) will be:
	 * 3*x + 4*Sum(i) where i > (1|0) and i < 2*abs(x) with double step
	 * Explanation of this calculations will be given later.
	*/
	private static long getValueForX(int x)
	{
		int k = 0;
		if (x < 0)
		{
			k = 1;
		}
		return 3 * Math.Abs(x) + SumOfValues(k, 2 * Math.Abs(x));
	}


	private static long ValueFromPositiveAxisY(int x, int y)
	{
		// Value goes from right to left
		if (-y <= x && x <= y)
		{
			return getValueForY(y) - x;
		}
		// Value goes from down to up
		return getValueForX(x) + y; // vertical move
	}

	private static long ValueFromNegativeAxisY(int x, int y)
	{
		// Value goes from left to right
		if (y < x && x <= -y)
		{
			return getValueForY(y) + x;
		}
		// Value goes from up to down
		return getValueForX(x) - y;
	}

	/*
	 * Return true when values are correct.
	 * In case they are not, wills how an error message and will return false
    */
	private static bool AreLimitsCorrect(int x, int y)
	{
		if (x > Math.Abs(1000000) || y > Math.Abs(1000000))
		{
			Console.Error.WriteLine("Error: Input values are between -1000000 -> 1000000");
			return false;
		}
		return true;
	}

	/*
	 * Method used to calculate the number:
	 *
	 * First we check if the values are between the limits.
	 * Then we will calculate the value depending on if it is on horizontal
	 * or vertical move. The calc for it also depends on the value of Y axis,
	 * if is positive or negative.
	 *
	 * Basically we can sumarise saying that we will use the value at (0, y) or (x, 0)
	 * and substracting or adding x or y values.
	 *
    */
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

	/*
    Internal function which checks that the result of GetNumberAtPosition is same as
    the expected one.
    */
	public static void CheckValue(int x, int y, long expected)
	{
		long result = GetNumberAtPosition(x, y);
		if (result != expected)
		{
			Console.WriteLine("Error, expected and given values are not same: (" + x + "," + y + ") != " + expected);
		}
	}

	static void Main()
	{
		Console.WriteLine("Spiral value will run some basic tests now.");

		CheckValue(1, 1, 4);
		CheckValue(0, 1, 5);
		CheckValue(-1, 1, 6);
		CheckValue(2, 2, 16);
		CheckValue(1, 2, 17);
		CheckValue(0, 2, 18);
		CheckValue(-1, 2, 19);
		CheckValue(-2, 2, 20);

		CheckValue(-4, -5, 81);
		CheckValue(-3, -5, 82);
		CheckValue(-2, -5, 83);
		CheckValue(-1, -5, 84);
		CheckValue(0, -5, 85);
		CheckValue(-1, -1, 8);
		CheckValue(-2, -1, 23);
		CheckValue(0, 0, 0);
		CheckValue(999999, 999999, 59);
		CheckValue(10000000, 100403240, -1);

		// todo check wrogn values
	}
}
