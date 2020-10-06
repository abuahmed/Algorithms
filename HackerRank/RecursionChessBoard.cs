using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        private const int Squares = 8;
        private const int Norm = Squares-1;
        private static bool[] _column;
        private static int[] _positionInRow;
        private static bool[] _leftDiagonal;
        private static bool[] _rightDiagonal;

        static ArrayList arli = new ArrayList();
        static int countcases=0;
        public static void MainRecursionChessBoard(string[] args)
        {
            SetValues();
            var aa=PutQueen(0);
        }

        static void SetValues()
        {
            _column = new bool[Squares];
            _positionInRow = new int[Squares];
            _leftDiagonal = new bool[Squares * 2 - 1];
            _rightDiagonal = new bool[Squares * 2 - 1];

            int i;
            for (i = 0; i < Squares; i++)
            {
                _positionInRow[i] = -1;
                _column[i] = true;
            }
            for (i = 0; i < Squares * 2 - 1; i++)
            {
                _leftDiagonal[i] = _rightDiagonal[i] = true;
            }
        }

        
        static int[] PutQueen(int row)
        {
            for (int col = 0; col < Squares; col++)
            {
                if (_column[col] && _leftDiagonal[row + col] && _rightDiagonal[row - col + Norm])
                {
                    _positionInRow[row] = col;
                    _column[col] = false;
                    _leftDiagonal[row + col] = false;
                    _rightDiagonal[row - col + Norm] = false;

                    if (row < Squares - 1)
                        PutQueen(row + 1);
                    else
                    {
                        //Print Result
                        //return _positionInRow;
                        countcases++;
                        var res =_positionInRow.ToArray();//=new []{} ;
                        if(!arli.Contains(res))
                        arli.Add(res);
                    }

                    _column[col] = true;
                    _leftDiagonal[row + col] = true;
                    _rightDiagonal[row - col + Norm] = true;
                }
            }

            return _positionInRow;
        }
    }
}
