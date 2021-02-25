using System;
using System.Collections.Generic;

namespace Detyra2
{
    class Program
    {
        //Validimi i elementit të matricës.
        public static Boolean isValid(int[][] M, int i, int j)
        {
            return (i >= 0 && i < M.Length && j >= 0 && j < M.Length);
        }

        //Gjetja e sekuencës më të gjatë duke kërkuar për elementet fqinje të matricës.
        public static string findLongestPath(int[][] M, int i, int j, Dictionary<string, string> lookup)
        {
            if (!isValid(M, i, j))
            {
                return null;
            }

            //Krijimi i çelësit unik për çdo sekuencë të matricës.
            string key = i + "|" + j;

            //Nëse kemi ndonjë sekuencë të re, gjindet dhe ruhet në dictonary
            if (!lookup.ContainsKey(key))
            {
                //Stringu për ruajtjen e sekuencës për elementin e caktuar të matricës.
                string path = null;

                //Rekursioni për gjetjen e sekuencës nga lartë nëse vlera e elementit të matricës është +1.
                if (i > 0 && M[i - 1][j] - M[i][j] == 1)
                    path = findLongestPath(M, i - 1, j, lookup);

                //Rekursioni për gjetjen e sekuencës nga ana e djathtë nëse vlera e elementit të matricës është +1.
                if (j + 1 < M.Length && M[i][j + 1] - M[i][j] == 1)
                    path = findLongestPath(M, i, j + 1, lookup);

                //Rekursioni për gjetjen e sekuencës nga poshtë nëse vlera e elementit të matricës është +1.
                if (i + 1 < M.Length && M[i + 1][j] - M[i][j] == 1)
                    path = findLongestPath(M, i + 1, j, lookup);

                //Rekursioni për gjetjen e sekuencës nga ana e majtë nëse vlera e elementit të matricës është +1.
                if (j > 0 && M[i][j - 1] - M[i][j] == 1)
                    path = findLongestPath(M, i, j - 1, lookup);


                if (path != null) 
                    lookup.Add(key, M[i][j] + " — " + path);
                else
                    lookup.Add(key, (M[i][j]).ToString());
            }

            return lookup[key];
        }

        public static void Main()
        {
            int[][] M = new int[][]
                        {
                        new int[]  { 10, 13, 14, 21, 23 },
                        new int[]  { 11, 9, 22, 2, 3 },
                        new int[]  { 12, 8, 1, 5, 4 },
                        new int[]  { 15, 24, 7, 6, 20 },
                        new int[]  { 16, 17, 18, 19, 25 }
                        };

            string res = ""; //Sekuenca më e gjatë.
            string str; //Sekuenca aktuale.
            long res_size = Int64.MinValue; //Madhësia e sekuencës më të gjatë.

            //Krijimi i dictionary për ruajtjen e të gjitha sekuencave të elementeve të matricës.
            Dictionary<string, string> lookup = new Dictionary<string, string>();

            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M.Length; j++)
                {
                    // Sekuenca str = `2 — 3 — 4 — 5 — 6 — 7`
                    str = findLongestPath(M, i, j, lookup);

                    //Numri i elementeve të përfshira në sekuencën aktuale
                    long size = str.Split('—').Length;

                    if (size > res_size)
                    {
                        res = str;
                        res_size = size;
                    }
                }
            }

            //Printimi i rezultatit
            Console.WriteLine("---------------------Sekuenca më e gjatë në matricë--------------------\n\n\n");
            for (int n = 0; n < M.Length; n++)
            {
                for (int k = 0; k < M[n].Length; k++)
                {
                    Console.Write("{0} \t\t\t", M[n][k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\nSekuenca më e gjatë në matricë: {0}. \n\n", res);
        }
    }
}

