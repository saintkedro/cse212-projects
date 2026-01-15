public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {


        // The goal of this function is to create and return an array(list) of a given number. 

        // step 1: Create an array of doubles with size = length.
        double[] multiples = new double[length];

        //  step 2: Loop through the list from index 0 up to length - 1.
        for (int i = 0; i < length; i++)
        {
            // step 3: For each index i, calculate the multiple: multiple = number * (i+1). i + 1 is used because arrays start at index 0.
            double multiple = number * (i + 1);

            // step 4: Store the calculated multiple in the array.
            multiples[i] = multiple;
        }

        // step 5: Return the filled array of multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // The goal of this function is to:
        // 1. Rotate a list to the right.
        // 2. Modify the existing list.
        // 3. Should not return a new list.
        
        /// It simply means to take the last element on the list and insert it at the beginning and repeat this a couple of times (amount).
        
        // step 1: Repeat the rotation process 'amount' times
        for (int i = 0; i < amount; i++)
        {
            // step 2: Save the last element in the list
            int lastElement = data[data.Count - 1];

            // step 3: remove the last element in the list
            data.RemoveAt(data.Count - 1);

            // step 4: Insert the saved element at the beginng of the list
            data.Insert(0, lastElement);
        }

        
        
    }
}
