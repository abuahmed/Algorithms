using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        public static void MainGraph(string[] args)
        {
            //MinSpanTreeTest();
            DijkstraAlgorithmTest();
            BfsShortestReachInaGraph(new Vertex<int>(1));
            CheckVertices();
            WfiAlgorithTest();
        }

        private static void WfiAlgorithTest()
        {
            const int n = 6;
            var weights = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == j)
                        weights[i, j] = 0;
                    else
                        weights[i, j] = Int32.MaxValue;
                }
            }

            weights[0, 1] = 6;
            weights[1, 2] = 6;
            weights[2, 3] = 6;
            weights[0, 4] = 6;

            WfiAlgorithm(weights);

            //List of distances from start
            const int start = 1;
            IList<int> ilist = new List<int>();
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                var weight = weights[start - 1, i];
                if (weight == Int32.MaxValue)
                    weight = -1;
                if (weight != 0)
                    ilist.Add(weight);
            }
            var count = ilist.Count;

            ////For n=5
            //weights[0, 1] = 2;
            //weights[1, 2] = -2;
            //weights[1, 3] = 1;
            //weights[1, 4] = 3;
            //weights[2, 4] = 1;
            //weights[0, 3] = -4;
            //weights[3, 4] = 4;
        }

        private static int[,] WfiAlgorithm(int[,] weights)
        {
            int n = weights.GetLength(0);

            //var max = Int64.MaxValue;
            //var aa=Math.Pow(2, 63)-1;
            //var dif = aa - max;

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        if (weights[j, i] != Int32.MaxValue && weights[i, k] != Int32.MaxValue)
                            if (weights[j, k] > weights[j, i] + weights[i, k])
                                weights[j, k] = weights[j, i] + weights[i, k];
                    }
                }
            }

            return weights;
        }

        public static void BfsShortestReachInaGraph(Vertex<int> start)
        {
            var graph = new UndirectedGenericGraph<int>();

            var one = new Vertex<int>(1);
            var two = new Vertex<int>(2);
            var three = new Vertex<int>(3);
            var four = new Vertex<int>(4);
            var five = new Vertex<int>(5);
            var six = new Vertex<int>(6);

            graph.AddPair(one, two, 6);
            graph.AddPair(two, three, 6);
            graph.AddPair(three, four, 6);
            graph.AddPair(one, five, 6);
            graph.AddToList(six);

            var dict = graph.BreadthFirstSearchWeighted(graph.Vertices.FirstOrDefault(v => v.Value == start.Value));
            var res3 = graph.Result;

            //for (int i = 0; i < 6; i++)
            //{
            //    graph.BreadthFirstSearch(graph.Vertices[i]);
            //    var res3 = graph.Result;
            //}
        }

        public static void CheckVertices()
        {
            var la = new Vertex<string>("Los Angeles");
            var sf = new Vertex<string>("San Francisco");
            var lv = new Vertex<string>("Las Vegas");
            var se = new Vertex<string>("Seattle");
            var au = new Vertex<string>("Austin");
            var po = new Vertex<string>("Portland");

            var aa = new Vertex<string>("Addis Ababa");
            var ad = new Vertex<string>("Adama");

            var testGraph = new UndirectedGenericGraph<string>();

            // la <=> sf, lv, po
            testGraph.AddPair(la, sf);
            testGraph.AddPair(la, lv);
            testGraph.AddPair(la, po);

            // sf <=> se, po
            testGraph.AddPair(sf, se);
            testGraph.AddPair(sf, po);

            // lv <=> au
            testGraph.AddPair(lv, au);

            // se <=> po
            testGraph.AddPair(se, po);

            // aa <=> ad
            testGraph.AddToList(aa);
            testGraph.AddToList(ad);

            // Check to see that all neighbors are properly set up
            foreach (var vertex in testGraph.Vertices)
            {
                Console.WriteLine(vertex.ToString());
                //System.Diagnostics.Debug.WriteLine(vertex.ToString());
            }
            var resu = "";
            for (int i = 0; i < 8; i++)
            {
                //if (!testGraph.Vertices[i].IsVisited)
                //{
                //    testGraph.DepthFirstSearch(testGraph.Vertices[i]); //.FirstOrDefault(s=>s.Value=="Las Vegas"));
                //    var count = testGraph.Count;
                //    resu = testGraph.Result;
                //    testGraph.Result = "";
                //    testGraph.Count = 0;

                //}

                if (!testGraph.Vertices[i].IsVisited)
                {
                    testGraph.DepthFirstSearchStack(testGraph.Vertices[i]);
                    var res3 = testGraph.Result;
                }
            }
            testGraph.UnvisitAll();
            var resu2 = "";
            for (int i = 0; i < 8; i++)
            {
                if (!testGraph.Vertices[i].IsVisited)
                {
                    testGraph.BreadthFirstSearch(testGraph.Vertices[i]); //.FirstOrDefault(s=>s.Value=="Las Vegas"));
                    //var count = testGraph.Count;
                    resu2 = testGraph.Result;
                    testGraph.Result = "";
                    //testGraph.Count = 0;
                }
            }
        }

        public static void DijkstraAlgorithmTest() 
        {
            var graph = new UndirectedGenericGraph<int>();

            var one = new Vertex<int>(1);
            var two = new Vertex<int>(2);
            var three = new Vertex<int>(3);
            var four = new Vertex<int>(4);
            var five = new Vertex<int>(5);
            var six = new Vertex<int>(6);

//            graph.AddPair(one, two, 6);
//            graph.AddPair(two, three, 6);
//            graph.AddPair(three, four, 6);
//            graph.AddPair(one, five, 6);
//            graph.AddToList(six);
            
            //graph.AddPair(one, two, 5);
            //graph.AddPair(two, three, 6);
            //graph.AddPair(three, four, 2);
            //graph.AddPair(one, three, 15);
            //graph.AddToList(five);

            graph.AddPair(one, two, 24);
            graph.AddPair(three, one, 3);
            graph.AddPair(one, four, 20);
            graph.AddPair(four, three, 12);

            var start = one;
            var distances=DijkstraAlgorithm(graph, start);
        }

        public static List<int> DijkstraAlgorithm(UndirectedGenericGraph<int> graph, Vertex<int> start)
        {
            var vertices = graph.Vertices;
            var n = vertices.Count;
            var currDist = new Dictionary<Vertex<int>, int>(n);
            
            foreach (var v in vertices)
            {
                currDist.Add(v, Int32.MaxValue);
            }

            currDist[start] = 0;

            var toBeChecked = new List<Vertex<int>>(vertices);
            while (toBeChecked.Count > 0)
            {
                var v = GetMinCurrDist(currDist, toBeChecked);

                toBeChecked.Remove(v);

                foreach (var u in vertices[v.Value - 1].Neighbors)
                {
                    if (toBeChecked.Contains(u))
                    {
                        var edgevu =v.WeightedEdges.FirstOrDefault(w => (w.StartV == v && w.EndV == u) || (w.StartV == u && w.EndV == v));
                        
                            if (edgevu != null)
                            {
                                var weightuv = edgevu.Weight;
                                if (currDist[u] > currDist[v] + weightuv)
                                {
                                    currDist[u] = currDist[v] + weightuv;
                                }
                            }
                    }
                }
            }

            //var count = toBeChecked.Count;
            var currDict=currDist.OrderBy(s => s.Key.Value).ToList();
            return currDict.Select(s => s.Value).ToList();
            //return null;// currDict.Values.ToList().Skip(1).ToList();
        }

        private static Vertex<int> GetMinCurrDist(Dictionary<Vertex<int>, int> currDist, List<Vertex<int>> toBeChecked)
        {
            var dict = currDist.Where(f => toBeChecked.Contains(f.Key)).ToList();
            var minCurrDist = dict.FirstOrDefault(f => f.Value == dict.Min(g => g.Value));

            return minCurrDist.Key;
        }

        public static void MinSpanTreeTest()
        {
            var graph = new UndirectedGenericGraph<int>();

            var one = new Vertex<int>(1);
            var two = new Vertex<int>(2);
            var three = new Vertex<int>(3);
            var four = new Vertex<int>(4);
            var five = new Vertex<int>(5);
            
            graph.AddPair(one, two, 5);
            graph.AddPair(one, three, 3);
            graph.AddPair(four, one, 6);
            graph.AddPair(two, four, 7);
            graph.AddPair(three, two, 4);
            graph.AddPair(three, four, 5);

            //graph.AddPair(one, two, 20);
            //graph.AddPair(one, three, 50);
            //graph.AddPair(one, four, 70);
            //graph.AddPair(one, five, 90);
            //graph.AddPair(two, three, 30);
            //graph.AddPair(three, four, 40);
            //graph.AddPair(four, five, 60);

            var cost = KruskalAlgorithm(graph);
            var cost2 = PrimeAlgorithm(graph);
            var cost3 = DijkstraAlgorithmMinSpanTree(graph);//To be tested
        }

        public static int KruskalAlgorithm(UndirectedGenericGraph<int> graph)
        {
            var tree = new List<Vertex<int>>();
            var edges = graph.Vertices.SelectMany(s => s.WeightedEdges).Distinct().OrderBy(w=>w.Weight).ToList();
           
            tree.Add(edges[0].StartV);
            tree.Add(edges[0].EndV);
            var cost = edges[0].Weight;     
   
            foreach (var weightedEdge in edges.Skip(1))
            {
                bool isfound = false;
                if (!tree.Contains(weightedEdge.StartV))
                {
                    tree.Add(weightedEdge.StartV);
                    isfound = true;
                }
                if (!tree.Contains(weightedEdge.EndV))
                {
                    tree.Add(weightedEdge.EndV);
                    isfound = true;
                }
                if (isfound)
                    cost += weightedEdge.Weight;
            }

            return cost;
        }

        public static int PrimeAlgorithm(UndirectedGenericGraph<int> graph)
        {
            var tree = new List<Vertex<int>>();
            var edges = graph.Vertices.SelectMany(s => s.WeightedEdges).Distinct().OrderBy(w => w.Weight).ToList();

            tree.Add(edges[0].StartV);
            tree.Add(edges[0].EndV);
            var cost = edges[0].Weight;

            foreach (var weightedEdge in edges.Skip(1))
            {
                bool isfound = false;
                if (!tree.Contains(weightedEdge.StartV))
                {
                      if (VertextIsIncidentToaVertexInTheTree(tree, weightedEdge.StartV))
                      {
                        tree.Add(weightedEdge.StartV);
                        isfound = true;
                      }
                }
                    
                if (!tree.Contains(weightedEdge.EndV))
                {
                    if (VertextIsIncidentToaVertexInTheTree(tree, weightedEdge.EndV))
                    {
                        tree.Add(weightedEdge.EndV);
                        isfound = true;
                    }
                }

                if (isfound)
                    cost += weightedEdge.Weight;
            }

            return cost;
        }

        private static bool VertextIsIncidentToaVertexInTheTree(IEnumerable<Vertex<int>> tree, Vertex<int> startV)
        {
            return tree.Any(vertex => vertex.Neighbors.Contains(startV));
        }

        public static int DijkstraAlgorithmMinSpanTree(UndirectedGenericGraph<int> graph)
        {       
            var tree = new List<Vertex<int>>();
            var weightTree = new List<WeightedEdge<int>>();
            var edges = graph.Vertices.SelectMany(s => s.WeightedEdges).Distinct().ToList();//.OrderBy(w => w.Weight).ToList();

            weightTree.Add(edges[0]);
            weightTree.Add(edges[1]);

            foreach (var weightedEdge in edges.Skip(2))
            {
                weightTree.Add(weightedEdge);

                var wt = ThereIsCycleInTheTree(weightTree);
                if(wt!=null)
                weightTree.Remove(wt);
            }

            return weightTree.Sum(s=>s.Weight);
        }

        private static WeightedEdge<int> ThereIsCycleInTheTree(List<WeightedEdge<int>> weightTree)
        {
            //Check Existence of Cycles

            var startVertices = weightTree.Select(a => a.StartV).ToList();
            var endVertices = weightTree.Select(a => a.EndV).ToList();
            var intersects = startVertices.Intersect(endVertices).ToList();

            if (intersects.Count > 1)
            {
                var cyclevertices = intersects.Select(a => a.Value).ToList();
                var cycles =
                    weightTree.Where(w => cyclevertices.Contains(w.StartV.Value) && cyclevertices.Contains(w.EndV.Value)).ToList();
                if(cycles.Count>2)
                return RemoveTheLongestEdgeFromTheTree(cycles);
                
            }
            return null;
        }

        private static WeightedEdge<int> RemoveTheLongestEdgeFromTheTree(List<WeightedEdge<int>> weightTree)
        {
            return weightTree.OrderByDescending(w => w.Weight).ToList().FirstOrDefault();
        }
    }

    public class Vertex<T>
    {
        public Vertex(T value, IList<Vertex<T>> neighbors = null, IList<WeightedEdge<T>> wedges = null)
        {
            Value = value;
            IsVisited = false;
            Neighbors = neighbors ?? new List<Vertex<T>>();
            WeightedEdges = wedges ?? new List<WeightedEdge<T>>();
        }

        public T Value { get; set; }

        public bool IsVisited { get; set; }

        public IList<Vertex<T>> Neighbors { get; set; }

        public IList<WeightedEdge<T>> WeightedEdges { get; set; }

        public int CountNeighbors
        {
            get { return Neighbors.Count; }
        }

        public void AddEdge(WeightedEdge<T> edge)
        {
            WeightedEdges.Add(edge);
        }

        public void AddNeighbor(Vertex<T> vertex)
        {
            Neighbors.Add(vertex);
        }

        public void RemoveNeighbor(Vertex<T> vertex)
        {
            Neighbors.Remove(vertex);
        }

        public override string ToString()
        {
            var allNeighbors = new StringBuilder("");
            allNeighbors.Append(Value + ": ");

            foreach (Vertex<T> neighbor in Neighbors)
            {
                allNeighbors.Append(neighbor.Value + "  ");
            }

            return allNeighbors.ToString();

            //return Neighbors.Aggregate(new StringBuilder($"{Value}: "), (sb, n) => sb.Append($"{n.Value} ")).ToString();
            //return $"{Value}: {(string.Join(" ", Neighbors.Select(n => n.Value)))}";
        }
    }

    public class UndirectedGenericGraph<T>
    {
        public UndirectedGenericGraph(int initialsize)
        {
            Vertices = new List<Vertex<T>>(initialsize);
        }

        public UndirectedGenericGraph(IList<Vertex<T>> initialVertices = null)
        {
            Vertices = initialVertices ?? new List<Vertex<T>>();
        }

        public IList<Vertex<T>> Vertices { get; set; }

        public int Size
        {
            get { return Vertices.Count; }
        }

        public void AddPair(Vertex<T> first, Vertex<T> second)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbors(first, second);
        }

        public void AddPair(Vertex<T> first, Vertex<T> second, int weight)
        {
            var we = new WeightedEdge<T>(first, second, weight);
            first.AddEdge(we);
            second.AddEdge(we);

            AddToList(first);
            AddToList(second);
            AddNeighbors(first, second);
        }

        public void AddToList(Vertex<T> first)
        {
            if (!Vertices.Contains(first))
                Vertices.Add(first);
        }

        private void AddNeighbors(Vertex<T> first, Vertex<T> second)
        {
            AddNeighbor(first, second);
            AddNeighbor(second, first);//Commented for directed graph
        }

        private void AddNeighbor(Vertex<T> first, Vertex<T> second)
        {
            if (!first.Neighbors.Contains(second))
            {
                first.AddNeighbor(second);
            }
        }

        public void UnvisitAll()
        {
            foreach (var vertex in Vertices)
            {
                vertex.IsVisited = false;
            }
        }

        public string Result;
        public int Count;

        public void DepthFirstSearch(Vertex<T> root)
        {
            if (!root.IsVisited)
            {
                Result += "_" + root.Value;
                Count++;
                root.IsVisited = true;

                foreach (var neighbor in root.Neighbors)
                {
                    DepthFirstSearch(neighbor);
                }
            }
        }

        public void DepthFirstSearchStack(Vertex<T> root)
        {
            var stack = new Stack<Vertex<T>>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var v = stack.Pop();
                if (!v.IsVisited)
                {
                    v.IsVisited = true;
                    Result += "_" + v.Value;
                }

                foreach (var neighbor in v.Neighbors)
                {
                    if (!neighbor.IsVisited)
                        stack.Push(neighbor);
                }
            }
        }

        public void BreadthFirstSearch(Vertex<T> root)
        {
            var queue = new Queue<Vertex<T>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var v = queue.Dequeue();
                v.IsVisited = true;
                Result += "_" + v.Value;

                foreach (var neighbor in v.Neighbors)
                {
                    if (!neighbor.IsVisited)
                        queue.Enqueue(neighbor);
                }
            }
        }

        public Dictionary<int, int> BreadthFirstSearchWeighted(Vertex<T> root)
        {
            var queue = new Queue<Vertex<T>>();
            queue.Enqueue(root);

            var dict = new Dictionary<int, int>(6);
            for (int i = 0; i < 6; i++)
            {
//if(i+1!=Convert.ToInt32(root.Value))
                dict.Add(i + 1, -1);
            }

            while (queue.Count != 0)
            {
                var v = queue.Dequeue();
                v.IsVisited = true;
                Result += "_" + v.Value;

                foreach (var neighbor in v.Neighbors)
                {
                    if (!neighbor.IsVisited)
                    {
                        var key = Convert.ToInt32(neighbor.Value);
                        var vValue = Convert.ToInt32(v.Value);

                        var firstOrDefault = v.WeightedEdges.FirstOrDefault(w =>
                            Convert.ToInt32(w.StartV.Value.ToString()) == vValue
                            && Convert.ToInt32(w.EndV.Value.ToString()) == key);

                        if (firstOrDefault != null)
                        {
                            var weight = firstOrDefault.Weight;

                            queue.Enqueue(neighbor);

                            if (dict[vValue] != -1)
                                dict[key] = dict[vValue] + weight;
                            else
                                dict[key] = weight;
                        }
                    }
                }
            }

            var rem = Convert.ToInt32(root.Value);
            dict.Remove(rem);

            return dict;
        }
    }

    public class WeightedEdge<T>
    {
        public WeightedEdge(Vertex<T> startV, Vertex<T> endV, int weight)
        {
            StartV = startV;
            EndV = endV;
            Weight = weight;
        }

        public Vertex<T> StartV { get; set; }

        public Vertex<T> EndV { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return string.Format("{0}--{1}-->{2}", StartV.Value, Weight, EndV.Value);
        }
    }


    //private static int[,] DepthFirstSearch()//int[,] edges
    //{
    //    int[,] eges = { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 1, 5 } };
    //    var gcs = new GraphCs(eges);
    //    var edges = gcs.Edges;
    //    var vetices = gcs.Vertices;

    //    return null;
    //}
    //public class GraphCs
    //{
    //    private bool isDirectedGraph;
    //    private bool isWeighted;

    //    public GraphCs(IList<string> vertices)
    //    {
    //        //Vertices = vertices;
    //    }

    //    public GraphCs(int[,] edges)
    //    {
    //        Edges=new List<GraphEdge<int>>();
    //        Vertices=new HashSet<string>();

    //        var width = edges.GetLength(0);
    //        var height = 2;// edges.GetLength(1);

    //        for (int i = 0; i < width; i++)
    //        {
    //            var ge = new GraphEdge<int>(edges[i, 0], edges[i, 1]);
    //            Edges.Add(ge);
    //            Vertices.Add(edges[i, 0].ToString());
    //            Vertices.Add(edges[i, 1].ToString());

    //        }

    //    }

    //    //public GraphFromAdjacencyList(int[,] edges)
    //    //{   
    //    //}

    //    public IList<GraphEdge<int>> Edges { get; set; }

    //    public HashSet<string> Vertices { get; set; }
    //}

    //public class GraphEdge<T>
    //{
    //    public GraphEdge(T startVertex, T endVertex)
    //    {
    //        StartVertex = startVertex;
    //        EndVertex = endVertex;
    //    }

    //    public GraphEdge(T startVertex, T endVertex, int weight)
    //    {
    //        StartVertex = startVertex;
    //        EndVertex = endVertex;
    //        Weight = weight;
    //    }

    //    public T StartVertex { get; set; }

    //    public T EndVertex { get; set; }

    //    public int Weight { get; set; }
    //}
}