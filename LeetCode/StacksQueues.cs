using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RecentCounter
    {
        private readonly Queue<int> _queue;
       
        public RecentCounter()
        {
            _queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            while (_queue.Count>0)
            {
                var head = _queue.Peek();
                if (t - head > 3000)
                {
                    _queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
          
            _queue.Enqueue(t);

            return _queue.Count;
        }
    }

    partial class Solution
    {
        private static void MainSQ(string[] args)
        {
            #region Tests
            var grid = new char[4][];
            grid[0] = new[] { '0', '0', '0', '0', '0' };
            grid[1] = new[] { '1', '1', '0', '0', '0' };
            grid[2] = new[] { '0', '0', '1', '1', '1' };
            grid[3] = new[] { '0', '0', '1', '1', '1' };
            //{
            //    {'1', '1', '0', '0', '0'}, 
            //    {'1', '1', '0', '0', '0'},
            //    {'0', '0', '1', '0', '0'}, 
            //    {'0', '0', '0', '1', '1'}
            //};
            ////grid = new char[,] {{'a'},{'a'}};
            ////var res = NumIslandsStack(grid);//new char[][]{});
            //string s = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";// "2[abc]3[cd]ef";// "3[a]2[bc]";//"3[a2[c]]";//
            ////zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef
            ////zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef
            //var res = DecodeString(s);
            //IList<IList<int>> lists = new List<IList<int>>();
            //lists.Add(new List<int> {1, 3});
            //lists.Add(new List<int> {3, 0, 1});
            //lists.Add(new List<int> {2});
            //lists.Add(new List<int> {0});
            ////lists.Add(new List<int>());
            //var res = CanVisitAllRooms(lists);
            ////[[4],[3],[],[2,5,7],[1],[],[8,9],[],[],[6]]

            //var matrix = new int[3][];
            //matrix[0] = new[] {1, 1, 1};
            //matrix[1] = new[] {1, 1, 0};
            //matrix[2] = new[] {1, 0, 1};
            //var res = FloodFill2(matrix, 1, 1, 2);

            //var nums = new int[] {73, 74, 75, 71, 69, 72, 76, 73 };//9,8,7,6,5,4,3};//
            //var res = DailyTemperaturesStack(nums);

            //            var nums = new[] {"2", "1", "+", "3", "*"};//"10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"};
            //            var res = EvalRPN(nums);

            //var res = IsValid("()[]{}"); 
            #endregion

//            var nums = new[] { -2, -1, 1, 2 };//{ 10, 2, -5 };//{ 5, 10, -5 };//  {8, -8};//
//            var result = AsteroidCollision(nums);

            RecentCounter recentCounter = new RecentCounter();
            var res=recentCounter.Ping(642);     // requests = [1], range is [-2999,1], return 1
            res=recentCounter.Ping(1849);   // requests = [1, 100], range is [-2900,100], return 2
            res=recentCounter.Ping(4921);  // requests = [1, 100, 3001], range is [1,3001], return 3
            res=recentCounter.Ping(5936);  // requests = [1, 100, 3001, 3002], range is [2,3002], return 3
            res = recentCounter.Ping(5957);
        }
        
        static int[] AsteroidCollision(int[] asteroids)
        {
            var stack=new Stack<int>();
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] > 0)
                    stack.Push(asteroids[i]);
                else
                {
                        bool isequal = false;
                        while (stack.Count>0)
                        {
                            if (stack.Peek() < 0)
                            {
                                stack.Push(asteroids[i]);
                                break;
                            }

                            var pop = stack.Pop();
                            if (pop > -asteroids[i])
                            {
                                stack.Push(pop);
                                break;
                            }
                            else if (pop == -asteroids[i])
                            {
                                isequal = true;
                                break;
                            }
                        }
                        if(stack.Count==0 && !isequal)
                            stack.Push(asteroids[i]);
                  
                }
            }

            var result=new int[stack.Count];
            var index = stack.Count - 1;
            while (stack.Count>0)
            {
                result[index] = stack.Pop();
                index--;
            }

            return result;
        }

        static bool IsValid(string s)
        {
            const string opening = "([{";
            const string closing = ")]}";

            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (opening.Contains(ch))
                {
                    stack.Push(ch);
                }
                else if (closing.Contains(ch))
                {
                    if (stack.Count > 0)
                    {
                        var ss = stack.Pop();
                        if (closing.IndexOf(ch) != opening.IndexOf(ss))
                            return false;
                    }
                    else return false;
                }
            }

            if (stack.Count == 0)
                return true;

            return false;
        }
        static int EvalRPN(string[] tokens)
        {
            if (tokens.Length == 0)
                return 0;

            const string arithmetic = "+-/*";
            
            var stack = new Stack<String>();
         
            foreach (var token in tokens)
            {
                if (arithmetic.Contains(token))
                {
                    int secondNum = Convert.ToInt32(stack.Pop());
                    int firstNum = Convert.ToInt32(stack.Pop());
                    var cursum = 0;
                    switch (token)
                    {
                        case "+":
                            cursum = firstNum + secondNum;
                            break;
                        case "-":
                            cursum = firstNum - secondNum;
                            break;
                        case "/":
                            cursum = firstNum / secondNum;
                            break;
                        case "*":
                            cursum = firstNum * secondNum;
                            break;
                    }
                    stack.Push(cursum.ToString());
                }
                else
                {
                    stack.Push(token);
                }

            }
             
            return Convert.ToInt32(stack.Pop());
        }
        private static int[] DailyTemperaturesStack(int[] temps)
        {
            int maxValue=Int32.MinValue;
            var stack = new Stack<int>();
            foreach (var temp in temps)
            {
                stack.Push(temp);
            }
            int i = temps.Length - 1;
            int maxvaluedays = 0;
            while (stack.Count>0)
            {
                var poped = stack.Pop();
                if (poped > maxValue)
                {
                    maxValue = poped;
                    temps[i] = 0;
                    maxvaluedays = 1;
                }
                else
                {
                    temps[i] = maxvaluedays;
                    maxvaluedays++;
                }
                i--;
            }

            return temps;
        }

        static int[] DailyTemperatures(int[] temps)
        {
            int i = 0;
            int j = i + 1;
            while (i < temps.Length-1)
            {
                if (temps[j] > temps[i])
                {
                    temps[i] = j - i;
                    i++;
                    j = i + 1;
                }
                else
                {
                    j++;
                }

                if (j == temps.Length)
                {
                    temps[i] = 0;
                    i++;
                    j = i + 1;
                }
            }
            temps[temps.Length - 1] = 0;
            return temps;
        }

        private static int[][] FloodFill2(int[][] image, int sr, int sc, int newColor)
        {
            if (image == null || image.Length == 0)
                return image;

            if (image[0].Length == 0)
                return image;

            var startingColor = image[sr][sc];

            if (startingColor == newColor)
                return image;

            FloodFillRecursion(image, sr , sc, newColor, startingColor);

            return image;
        }

        private static void FloodFillRecursion(int[][] image, int sr, int sc, int newColor, int startingColor)
        {
            var width = image.Length;
            var height = image[0].Length;

            if (sr < 0 || sc < 0)
                return ;
            if (sr >=width || sc >=height)
                return;

            if (image[sr][sc] == startingColor)
            {
                image[sr][sc] = newColor;
                FloodFillRecursion(image, sr - 1, sc, newColor, startingColor);
                FloodFillRecursion(image, sr + 1, sc, newColor, startingColor);
                FloodFillRecursion(image, sr, sc - 1, newColor, startingColor);
                FloodFillRecursion(image, sr, sc + 1, newColor, startingColor);
            }

        }

        static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image == null || image.Length == 0)
                return image;
            
            if (image[0].Length == 0)
                return image;

            var startingColor = image[sr][sc];

            if (startingColor == newColor)
                return image;
            
            var queue = new Queue<String>();
            queue.Enqueue(sr+"_"+sc);
            
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int k = 0; k < size; k++)
                {
                    var cell = queue.Dequeue().Split('_').Select(c => Convert.ToInt32(c)).ToArray();
                    int ii = cell[0], jj = cell[1];
                    if (image[ii][jj] == startingColor)
                    {
                        image[ii][jj] = newColor;
                        GetNeighbors(ref queue, ii, jj, image);
                    }
                }
            }
         
            return image;
        }
        private static int[][] UpdateMatrix(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return matrix;

            var width = matrix.Length;
            var height = matrix[0].Length;

            if (height == 0)
                return matrix;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (matrix[i][j] != 0)
                    {
                        var queue = new Queue<String>();
                        var step = 1;
                        GetNeighbors(ref queue, i, j, matrix);
                        bool found = false;
                        while (queue.Count > 0 && !found)
                        {
                            int size = queue.Count;
                            for (int k = 0; k < size; k++)
                            {
                                var cell = queue.Dequeue().Split('_').Select(c => Convert.ToInt32(c)).ToArray();
                                int ii = cell[0], jj = cell[1];
                                if (matrix[ii][jj] == 0)
                                {
                                    matrix[i][j] = step;
                                    found = true;
                                    break;
                                }
                                else
                                {
                                    GetNeighbors(ref queue, ii, jj, matrix);
                                }
                            }
                            step++;
                        }
                    }
                }
            }

            return matrix;
        }

        private static void GetNeighbors(ref Queue<string> queue, int i, int j, int[][] matrix)
        {
            var width = matrix.Length;
            var height = matrix[0].Length;

            if (i - 1 > -1)
            {
                queue.Enqueue((i - 1) + "_" + j);
            }
            if (i + 1 < width)
            {
                queue.Enqueue((i + 1) + "_" + j);
            }
            if (j - 1 > -1)
            {
                queue.Enqueue(i + "_" + (j - 1));
            }
            if (j + 1 < height)
            {
                queue.Enqueue(i + "_" + (j + 1));
            }
        }

        private static bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            if (rooms == null)
                return true;

            var keysHashSet = new HashSet<int> {0};
            var stack = new Stack<int>();

            var keys = rooms[0];
            foreach (var key in keys)
            {
                stack.Push(key);
            }

            while (stack.Count > 0)
            {
                var key = stack.Pop();
                keysHashSet.Add(key);
                var keys2 = rooms[key];
                foreach (var key2 in keys2)
                {
                    if (!keysHashSet.Contains(key2))
                        stack.Push(key2);
                }
            }
            return keysHashSet.Count == rooms.Count;
        }

        private static string DecodeString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            var stack = new Stack<string>();
            foreach (var ch in s)
            {
                if (ch.Equals(']'))
                {
                    var insideBracketchars = "";
                    var qty = "";
                    var getnumbers = false;
                    while (stack.Count > 0)
                    {
                        var chpop = stack.Pop();
                        if (!getnumbers && chpop.Equals("["))
                        {
                            getnumbers = true;
                        }
                        else if (!getnumbers)
                        {
                            insideBracketchars = chpop + insideBracketchars;
                        }
                        else
                        {
                            if (Regex.IsMatch(chpop.ToString(), "\\d+"))
                                qty = chpop + qty;
                            else
                            {
                                stack.Push(chpop);
                                break;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(qty))
                    {
                        var qtyint = Convert.ToInt32(qty);
                        var fullchars = "";
                        for (int i = 0; i < qtyint; i++)
                        {
                            fullchars += insideBracketchars;
                        }
                        if (!string.IsNullOrEmpty(fullchars))
                            stack.Push(fullchars);
                    }
                }
                else
                {
                    stack.Push(ch.ToString());
                }
            }

            var res = "";
            while (stack.Count > 0)
            {
                res = stack.Pop() + res;
            }

            return res;
        }

        private static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            var numofislands = 0;
            var width = grid.Length;
            var height = grid[0].Length;

            if (width == 0 || height == 0)
                return 0;
            var total = 0;
            var list = new List<int>();
            var hashSet = new HashSet<string>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (total != 0)
                        list.Add(total);
                    var queue = new Queue<String>();

                    if (grid[i][j] == '1')
                    {
                        if (!hashSet.Contains(i + "_" + j))
                        {
                            hashSet.Add(i + "_" + j);
                            queue.Enqueue(i + "_" + j);
                            numofislands++;
                        }
                    }

                    total = 0;
                    while (queue.Count != 0)
                    {
                        var size = queue.Count;
                        total += size;
                        for (int k = 0; k < size; k++)
                        {
                            var cell = queue.Dequeue().Split('_').Select(c => Convert.ToInt32(c)).ToArray();

                            int ii = cell[0], jj = cell[1];
                            grid[ii][jj] = '0';

                            if (ii - 1 > -1 && grid[ii - 1][jj] == '1')
                            {
                                if (!hashSet.Contains((ii - 1) + "_" + jj))
                                {
                                    hashSet.Add((ii - 1) + "_" + jj);
                                    queue.Enqueue((ii - 1) + "_" + jj);
                                }
                            }
                            if ((ii + 1 < width) && grid[ii + 1][jj] == '1')
                            {
                                if (!hashSet.Contains((ii + 1) + "_" + jj))
                                {
                                    hashSet.Add((ii + 1) + "_" + jj);
                                    queue.Enqueue((ii + 1) + "_" + jj);
                                }
                            }
                            if (jj - 1 > -1 && grid[ii][jj - 1] == '1')
                            {
                                if (!hashSet.Contains(ii + "_" + (jj - 1)))
                                {
                                    hashSet.Add(ii + "_" + (jj - 1));
                                    queue.Enqueue(ii + "_" + (jj - 1));
                                }
                            }
                            if ((jj + 1 < height) && grid[ii][jj + 1] == '1')
                            {
                                if (!hashSet.Contains(ii + "_" + (jj + 1)))
                                {
                                    hashSet.Add(ii + "_" + (jj + 1));
                                    queue.Enqueue(ii + "_" + (jj + 1));
                                }
                            }
                        }
                    }
                }
            }

            return numofislands;
        }

        private static int NumIslandsStack(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            var numofislands = 0;
            var width = grid.Length;
            var height = grid[0].Length;

            if (width == 0 || height == 0)
                return 0;
            var total = 0;
            var list = new List<int>();
            var hashSet = new HashSet<string>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (total != 0)
                        list.Add(total);
                    var stack = new Stack<String>();

                    if (grid[i][j] == '1')
                    {
                        if (!hashSet.Contains(i + "_" + j))
                        {
                            hashSet.Add(i + "_" + j);
                            stack.Push(i + "_" + j);
                            numofislands++;
                        }
                    }

                    total = 0;
                    while (stack.Count != 0)
                    {
                        var size = stack.Count;
                        total += size;
                        for (int k = 0; k < size; k++)
                        {
                            var cell = stack.Pop().Split('_').Select(c => Convert.ToInt32(c)).ToArray();

                            int ii = cell[0], jj = cell[1];
                            grid[ii][jj] = '0';

                            if (ii - 1 > -1 && grid[ii - 1][jj] == '1')
                            {
                                if (!hashSet.Contains((ii - 1) + "_" + jj))
                                {
                                    hashSet.Add((ii - 1) + "_" + jj);
                                    stack.Push((ii - 1) + "_" + jj);
                                }
                            }
                            if ((ii + 1 < width) && grid[ii + 1][jj] == '1')
                            {
                                if (!hashSet.Contains((ii + 1) + "_" + jj))
                                {
                                    hashSet.Add((ii + 1) + "_" + jj);
                                    stack.Push((ii + 1) + "_" + jj);
                                }
                            }
                            if (jj - 1 > -1 && grid[ii][jj - 1] == '1')
                            {
                                if (!hashSet.Contains(ii + "_" + (jj - 1)))
                                {
                                    hashSet.Add(ii + "_" + (jj - 1));
                                    stack.Push(ii + "_" + (jj - 1));
                                }
                            }
                            if ((jj + 1 < height) && grid[ii][jj + 1] == '1')
                            {
                                if (!hashSet.Contains(ii + "_" + (jj + 1)))
                                {
                                    hashSet.Add(ii + "_" + (jj + 1));
                                    stack.Push(ii + "_" + (jj + 1));
                                }
                            }
                        }
                    }
                }
            }

            return numofislands;
        }
    }

    //MyStack stack = new MyStack();
    //stack.Push(1);
    //stack.Push(2); 
    //var res1=stack.Top();   // returns 2
    //var res2=stack.Pop();   // returns 2
    //var bres=stack.Empty(); // returns false
    public class MyStack
    {
        private Queue<int> _firstQueue;
        private Queue<int> _secondQueue;
        private int _topElement;
        /** Initialize your data structure here. */

        public MyStack()
        {
            _firstQueue = new Queue<int>();
            _secondQueue = new Queue<int>();
        }

        /** Push element x onto stack. */

        public void Push(int x)
        {
            _topElement = x;
            _firstQueue.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */

        public int Pop()
        {
            _secondQueue = new Queue<int>();
            while (_firstQueue.Count > 1)
            {
                _secondQueue.Enqueue(_firstQueue.Dequeue());
            }
            var top = _firstQueue.Dequeue();

            while (_secondQueue.Count > 1)
            {
                _firstQueue.Enqueue(_secondQueue.Dequeue());
            }

            _topElement = _secondQueue.Dequeue();
            _firstQueue.Enqueue(_topElement);


            return top;
        }

        /** Get the top element. */

        public int Top()
        {
            return _topElement;
        }

        /** Returns whether the stack is empty. */

        public bool Empty()
        {
            return _firstQueue.Count == 0;
        }
    }

    //MyQueue queue = new MyQueue();
    //queue.Push(1);
    //queue.Push(2);
    //var res1=queue.Peek();  // returns 1
    //res1=queue.Pop();   // returns 1
    //var bres=queue.Empty(); // returns false
    public class MyQueue
    {
        private Stack<int> _firstStack, _secondStack;
        private int _frontElement;
        /** Initialize your data structure here. */

        public MyQueue()
        {
            _firstStack = new Stack<int>();
            _secondStack = new Stack<int>();
        }

        /** Push element x to the back of queue. */

        public void Push(int x)
        {
            if (_firstStack.Count == 0)
                _frontElement = x;
            _firstStack.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */

        public int Pop()
        {
            if (_secondStack.Count == 0)
            {
                while (_firstStack.Count > 0)
                {
                    _secondStack.Push(_firstStack.Pop());
                }
            }
            return _secondStack.Pop();
        }

        /** Get the front element. */

        public int Peek()
        {
            if (_secondStack.Count > 0)
                return _secondStack.Peek();
            return _frontElement;
        }

        /** Returns whether the queue is empty. */

        public bool Empty()
        {
            return _firstStack.Count == 0 && _secondStack.Count == 0;
        }
    }
}