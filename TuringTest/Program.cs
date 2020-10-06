using System;
using System.Collections.Generic;

namespace T
{
    public class Program
    {
        private static IList<string> _pathlist;// = new List<string>();
        private static IList<IList<string>> _pathlistG;// = new List<IList<string>>();

        public static void Main(string[] args)
        {
            ////var matrix = GetMatrix();
            ////var numOffices = Solution.NumOffices(matrix);
            ////Console.WriteLine(numOffices);

            //string[,] answerMatrix = new string[8, 8];
            //string wb = "wbbwwbww bbbbwbww wwwbbwww wbwbwwbb wbwwwbwb wbbbbwww wbwbbwww wbwbbwww";
            //wb = "bbwwwwww bbwwbwwb wwbbwbbw wwbbwbbw wbwwbwwb wwbbwbbw wwbbwbbw wbwwbwwb";
            //wb = "bbwwwbbb bbwwwbbb wwbwwbbb wwwbbbbb bbbbbbbb bbbbbbbb bbbbbbbb bbbbbbbb";
            //var wbsplit = wb.Split(' ');

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        answerMatrix[i, j] = wbsplit[i][j].ToString();
            //    }
            //}
            ////answersVisited = answerMatrix;
            //NumberOfWhiteAreaAndTheirSize(answerMatrix);

            int[,] matrix = {{1, 1, 0, 0}, {0, 1, 1, 0}, {0, 0, 1, 0}, {1, 0, 0, 0}};
            //int[,] matrix = {{1, 1, 0, 0, 0, 1}, {0, 1, 1, 0, 0, 0}, {0, 0, 0, 1, 0, 0}};
            int totCells = CountCellsInRegionsAndTheirSize(matrix);
        }

        private static int NumberOfWhiteAreaAndTheirSize(string[,] answerMatrix)
        {
            int total = 0;
            var arealist =new List<int>();
            var max = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (answerMatrix[i, j] == "w" && answerMatrix[i, j] != "wv")
                    {
                        var tot = CountWhites(answerMatrix, i, j);
                        max = Math.Max(max, tot);
                        arealist.Add(tot);
                        total += tot;
                    }
                }
            }

            return total;
        }
        
        private static int CountWhites(string[,] answerMatrix, int i, int i1)
        {
            if (i < 0 || i1 < 0 || i>7 || i1 > 7)
                return 0;
            if (answerMatrix[i, i1] == "b")
                return 0;
            if (answerMatrix[i, i1] == "wv")
                return 0;
            //if (answersVisited[i, i1] == "wv")
            //    return 0;
            //if (answerMatrix[i, i1] == "w")
            //    answersVisited[i, i1] = "wv";
            if (answerMatrix[i, i1] == "w")
                answerMatrix[i, i1] = "wv";
            return 1 + CountWhites(answerMatrix, i - 1, i1)
                   + CountWhites(answerMatrix, i, i1-1)
                   + CountWhites(answerMatrix, i + 1, i1)
                   + CountWhites(answerMatrix, i, i1 + 1);
        }
        
        private static int CountCellsInRegionsAndTheirSize(int[,] answerMatrix)
        {
            int total = 0;
            var arealist = new List<int>();
            var max = 0;

            var width = answerMatrix.GetLength(0);
            var height = answerMatrix.GetLength(1);
            _pathlist = new List<string>();
            _pathlistG = new List<IList<string>>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (answerMatrix[i, j] == 1) 
                    {
                        var tot = CountCellsInRegions(answerMatrix, i, j);
                        max = Math.Max(max, tot);
                        arealist.Add(tot);
                        _pathlistG.Add(_pathlist);
                        _pathlist = new List<string>();
                        total += tot;
                    }
                }
            }

            return total;
        }


        private static int CountCellsInRegions(int[,] answerMatrix, int i, int i1)
        {
            var width = answerMatrix.GetLength(0);
            var height = answerMatrix.GetLength(1);

            if (i < 0 || i1 < 0 || i > width-1 || i1 > height-1)
                return 0;
            if (answerMatrix[i, i1] == 0)
                return 0;
            if (answerMatrix[i, i1] == 1)
            {
                answerMatrix[i, i1] = 0;
                _pathlist.Add(i.ToString() +"_"+ i1.ToString());
            }

            return 1 + CountCellsInRegions(answerMatrix, i - 1, i1)
                   + CountCellsInRegions(answerMatrix, i, i1 - 1)
                   + CountCellsInRegions(answerMatrix, i + 1, i1)
                   + CountCellsInRegions(answerMatrix, i, i1 + 1)

                   + CountCellsInRegions(answerMatrix, i - 1, i1 - 1)
                   + CountCellsInRegions(answerMatrix, i - 1, i1 + 1)
                   + CountCellsInRegions(answerMatrix, i + 1, i1 - 1)
                   + CountCellsInRegions(answerMatrix, i + 1, i1 + 1);
        }

        //public static char[][] GetMatrix()
        //{
        //    var rows = Int32.Parse(Console.ReadLine());
        //    var cols = Int32.Parse(Console.ReadLine());

        //    char[][] matrix = new char[rows][];
        //    for (var i = 0; i < rows; i++)
        //    {
        //        var line = Console.ReadLine();
        //        matrix[i] = line.ToCharArray();
        //    }
        //    return matrix;
        //}
    }
}

class Solution
{
    public static int NumOffices(char[][] grid)
    {
        int result = 0;
        // place your code here

        return result;
    }
}
