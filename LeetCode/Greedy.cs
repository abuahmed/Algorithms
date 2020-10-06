using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void MainGreedy(string[] args)
        {
            var gas = new[] {5,1,4,1,4};
            var cost = new[] {4,4,1,5,1};
            var res = CanCompleteCircuit(gas, cost);

            var result = PredictPartyVictory("RDD");
        }
        static string PredictPartyVictory(string senate)
        {
            if (senate.Length == 0)
                return senate;

            while (senate.Contains('R') && senate.Contains('D'))
            {
                int i = 0;
                while (i < senate.Length)
                {
                    if (i < senate.Length - 1)
                    {
                        if (senate[i] != senate[i + 1])
                        {
                            senate = senate.Remove(i + 1, 1);
                        }

                        i++;
                    }
                    else
                    {
                        senate = senate.Substring(1);
                        break;
                    }
                }
            }

            return senate.Contains('R') ? "Radiant" : "Dire";
        }
        static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            for (int i = 0; i < gas.Length; i++)
                {
                    if (gas[i] >= cost[i])
                    {
                        var startIndex = i;
                        var currentcost = gas[i];
                        int countstations = 1;
                        var nextstation = startIndex;
                        while (countstations<=gas.Length)
                        {
                            var currentstation = nextstation;
                            nextstation = nextstation != gas.Length - 1 ? nextstation + 1 : 0;
                            if (nextstation == startIndex)
                            {
                                if (currentcost >= cost[currentstation])
                                    return startIndex;
                                break;
                            }

                            if (currentcost < cost[currentstation] || currentcost < 0)
                                break;

                            currentcost += gas[nextstation] - cost[currentstation];

                            countstations++;
                        }

                    }
                }

            return -1;
        }
    }
}
