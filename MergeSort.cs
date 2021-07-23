using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[] {3, 1, 5, 2, 4};

        MergeSort(arr, 0, arr.Length - 1);

        for (int i = 0; i < arr.Length; i++)
            Console.WriteLine(arr[i]);
    }    
     
    private static void MergeSort(int[] input, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
     
            MergeSort(input, left, middle);
            MergeSort(input, middle + 1, right);
     
            Merge(input, left, middle, right);
        }
    } 
    
    private static void Merge(int[] input, int left, int middle, int right)
    {
        int[] leftArray = new int[middle - left + 1];
        int[] rightArray = new int[right - middle];
     
        Array.Copy(input, left, leftArray, 0, middle - left + 1);
        Array.Copy(input, middle + 1, rightArray, 0, right - middle);
     
        int i = 0;
        int j = 0;
        for (int k = left; k < right + 1; k++)
        {
            if (i == leftArray.Length)
            {
                input[k] = rightArray[j];
                j++;
            }
            else if (j == rightArray.Length)
            {
                input[k] = leftArray[i];
                i++;
            }
            else if (leftArray[i] <= rightArray[j])
            {
                input[k] = leftArray[i];
                i++;
            }
            else
            {
                input[k] = rightArray[j];
                j++;
            }
        }
    }
}
