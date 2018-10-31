using System;
/*Given two sequences, print longest common subsequence
        LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
        LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4. */
namespace String6
{
    class Program
    {
        static void LongComSub(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;
            int[,] matrix = new int[m + 1, n + 1];
            //Following steps build matrix[m+1][n+1] in bottom up. Note that matrix[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] 
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        matrix[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }

            // Following code is used to print LCS
            int index = matrix[m, n];
            int temp = index;

            // Create a character array to store the lcs string
            char[] lcs = new char[index + 1];

            // Set the terminating character
            //lcs[index] = '\0';
        
            // Start from the right-most-bottom-most corner and one by one store characters in lcs[]
            int k = m, l = n;
            while (k > 0 && l > 0)
            {
                // If current character in X[] and Y[] are same, then current character is part of LCS
                if (str1[k - 1] == str2[l - 1])
                {
                    lcs[index] = str1[k - 1];
                    k--;
                    l--;
                    index--;
                }
                // If not same, then find the larger of two and go in the direction of larger value
                else if (matrix[k - 1, l] > matrix[k, l - 1])
                    k--;
                else
                    l--;                    
            }

            //PrintMatrix(matrix);

            // Print the lcs
            Console.Write("LCS of '" + str1 + "' and '" + str2 + "' is '");
            for (int i = 1; i <= temp; i++)
                Console.Write(lcs[i]);
            Console.Write("' of length " + temp);
            Console.WriteLine();
        }

        static void PrintMatrix(int[,] matrix)
        {
            int i, j;
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write("  " + matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //string str1 = "ABCDGH";
            //string str2 = "AEDFHR";
            string str1 = "AGGTAB";
            string str2 = "GXTXAYB";
            //int m = str1.Length;
            //int n = str2.Length;
            LongComSub(str1, str2);
        }
    }
}
