using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // My plan:
        // I want to create an array that contains multiples of the number.
        // First I create an array with the size "length".
        // Then I loop from 0 to length - 1.
        // For each step, I calculate the multiple by doing number * (i + 1).
        // I store each result inside the array.
        // At the end, I return the array with all the multiples.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // My thinking:
        // I want to rotate the list to the right.
        // That means the last "amount" values should move to the front of the list.
        // I calculate where this part starts: start = data.Count - amount.
        // I take that part of the list using GetRange.
        // I remove this part from the end.
        // Then I insert this part at position 0 in the list.
        // After this process, the list is rotated to the right correctly.

        if (data == null || data.Count == 0)
        {
            return;
        }

        amount = amount % data.Count;
        if (amount == 0)
        {
            return;
        }

        int start = data.Count - amount;
        List<int> tail = data.GetRange(start, amount);
        data.RemoveRange(start, amount);
        data.InsertRange(0, tail);
    }
}
