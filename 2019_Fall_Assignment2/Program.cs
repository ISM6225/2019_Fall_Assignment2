using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            //int[] nums1 = { 2, 5, 5, 2 };
            int[] nums1 = { 3, 6, 2 };
            //int[] nums2 = { 5,5 };
            int[] nums2 = { 6, 3, 6, 7, 3 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //use binary search
                int start = 0, end = nums.Length - 1,
                    index = start + (end - start) / 2;

                if (target > nums[nums.Length - 1])
                {
                    // target is greater than last element in array
                    index = nums.Length;
                }
                else
                {
                    while (start < end)
                    {
                        int val = nums[index];

                        if (val == target)
                        {
                            return index;

                        }
                        else if (val < target)
                        {
                            //
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }

                        index = start + (end - start) / 2;
                    }
                }
                return index;

            }

            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return -1;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Using Dictionaries
                Dictionary<int, int> n1 = new Dictionary<int, int>();
                Dictionary<int, int> n2 = new Dictionary<int, int>();

                // check which array is longest
                int arrayLength;
                if (nums1.Length > nums2.Length)
                {
                    arrayLength = nums2.Length;
                }
                else
                {
                    arrayLength = nums1.Length;
                }


                int[] output = new int[arrayLength];

                for (int i = 0; i < nums1.Length; i++)
                {
                    n1.Add(i, nums1[i]);
                }
                for (int j = 0; j < nums2.Length; j++)
                {
                    n2.Add(j, nums2[j]);
                }

                int index = 0;
                foreach (KeyValuePair<int, int> item in n1)
                {
                    if (n2.ContainsValue(item.Value) && index < arrayLength)
                    {
                        output[index] = item.Value;
                        n2.Remove(item.Key);
                        ++index;
                    }
                }

                return output;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {   //using dictionary to find out the larest unique number
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                int value;

                //we run the for loop and select the first element 
                for (int i = 0; i < A.Length - 1; i++)
                {   //condition to check if there is common number in the array
                    if (dictionary.TryGetValue(A[i], out value))
                    {
                        dictionary[A[i]]++;
                    }

                    else
                    {
                        dictionary.Add(A[i], 0);
                    }
                }
                return dictionary.Where(pair => pair.Value == 0).Select(pair => pair.Key).Max();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {   //using dictionary to Calculate Time 
                Dictionary<char, int> dictionary = new Dictionary<char, int>();
                char[] Arraykey = keyboard.ToCharArray();
                char[] Arrayword = word.ToCharArray();
                int value, time;
                //we run the for loop and select the first element
                for (int i = 0; i < Arraykey.Length; i++)
                {   //condition to check if there is no common number in the array
                    if (!dictionary.TryGetValue(Arraykey[i], out value))
                    {
                        dictionary.Add(Arraykey[i], i);
                    }
                }

                time = dictionary[Arrayword[0]];
                for (int i = 0; i < Arrayword.Length - 1; i++)
                {
                    time =+ Math.Abs(dictionary[Arrayword[i]] - dictionary[Arrayword[i + 1]]);
                }
                return time;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                int[,] rev_flip = new int[A.GetLength(0), A.GetLength(1)];

                for (int i = 0; i < A.GetLength(0); i++)

                {

                    for (int j = 0; j < A.GetLength(1); j++)

                    {

                        rev_flip[i, j] = A[i, Math.Abs(j - A.GetLength(1) + 1)] ^ 1;

                    }



                }

                return rev_flip;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                int n = intervals.Length / 2;
                int[] start = new int[n];
                int[] end = new int[n];


                for (int i = 0; i < n; i++)
                {
                    start[i] = intervals[i, 0];
                }


                for (int j = 0; j < n; j++)
                {
                    end[j] = intervals[j, 1];
                }

                //sort start and end time 
                Array.Sort(start);
                Array.Sort(end);



                int room_needed = 1, result = 1;
                int x = 1, y = 0;

                while (x < n && y < n)
                {

                    // If next meeting in sorted order  
                    // is started, increment count 
                    // of room needed 
                    if (start[x] <= end[y])
                    {
                        room_needed++;
                        x++;

                        // Update result if needed  
                        if (room_needed > result)
                            result = room_needed;
                    }

                    // Else decrement count of  
                    // meeting needed 
                    else
                    {
                        room_needed--;
                        y++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] *= A[i];
                }
                //to sort an array with O(N) we will use radix sort 
                radixsort(A, A.Length);

                return A;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {

            try
            {
                int check = 0;
                //Console.Write("\n String is not a palindrome,lets check if the string can made Palindrome\n");
                for (int i = 0; i < s.Length; i++)
                {

                    string sub_string = s.Remove(i, 1);
                    if (isPalindrome(sub_string) == 0)
                    {

                        check = 1;
                        break;
                    }
                }

                if (check == 1)
                    return true;
                else
                    return false;
            }

            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }

        public static int isPalindrome(string s)
        {
            int pal = 0;
            int x = 0, y = s.Length - 1;
            while (x != y)
            {
                if (s[x] == s[y])
                {
                    x++;
                    y--;
                    if (x > y)
                    {
                        break;
                    }
                }
                else
                {
                    pal = 1;
                    break;
                }
            }
            return pal;
        }

        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        // A function to do counting sort of arr[] according to  
        // the digit represented by exp.  
        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array  
            int i;
            int[] count = new int[10];

            //initializing all elements of count to 0 
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]  
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array  
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now  
            // contains sorted numbers according to current digit  
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }

        public static void radixsort(int[] arr, int n)
        {
            // Find the maximum number to know number of digits  
            int m = getMax(arr, n);

            // Do counting sort for every digit. Note that instead  
            // of passing digit number, exp is passed. exp is 10^i  
            // where i is current digit number  
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
    }
}
