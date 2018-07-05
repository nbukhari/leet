using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class UndirectedGraphNode {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    public class GraphOperations
    {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
                return node;

            Dictionary<UndirectedGraphNode, UndirectedGraphNode> graphMap = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();
            UndirectedGraphNode startNode = CloneNode(node, graphMap);

            return startNode;
        }

        private UndirectedGraphNode CloneNode(UndirectedGraphNode node, Dictionary<UndirectedGraphNode, UndirectedGraphNode> graphMap)
        {
            if (node == null)
                return null;

            UndirectedGraphNode clonedNode = new UndirectedGraphNode(node.label);
            graphMap.Add(node, clonedNode);

            UndirectedGraphNode neighborNode = null;
            for (int i = 0; i < node.neighbors.Count; i++)
            {
                if (node.neighbors[i] == null)
                {
                    clonedNode.neighbors.Add(node.neighbors[i]);
                    continue;
                }

                if (graphMap.ContainsKey(node.neighbors[i]))
                {
                    neighborNode = graphMap[node.neighbors[i]];
                }
                else
                {
                    neighborNode = CloneNode(node.neighbors[i], graphMap);
                }
                clonedNode.neighbors.Add(neighborNode);
            }

            return clonedNode;
        }
        public int NumIslands(char[,] grid)
        {
            int rows = grid.GetUpperBound(0) + 1;
            int cols = grid.GetUpperBound(1) + 1;
            int islands = 0;

            if (rows < 1 || cols < 1)
                return 0;

            bool[,] visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visited[i, j] && !(grid[i, j] == '0'))
                    {
                        VisitNeighbours(grid, visited, i, j);
                        islands++;
                    }
                }
            }

            return islands;
        }

        private void VisitNeighbours(char[,] grid, bool[,] visited, int i, int j)
        {
            if (!IsLand(grid, i, j) || visited[i, j] || grid[i, j] == '0')
                return;

            visited[i, j] = true;

            VisitNeighbours(grid, visited, i, j - 1);
            VisitNeighbours(grid, visited, i - 1, j);
            VisitNeighbours(grid, visited, i, j + 1);
            VisitNeighbours(grid, visited, i + 1, j);
        }

        private bool IsLand(char[,] grid, int i, int j)
        {
            return i >= 0 && j >= 0 && i <= grid.GetUpperBound(0) && j <= grid.GetUpperBound(1);
        }

    }
}
