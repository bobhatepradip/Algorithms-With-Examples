using System.Collections.Generic;

namespace TWL_Algorithms_Samples.Graph
{
    public class GraphUtility
    {
        public void Run()
        {
        }

        public void IsRouteExistInDirectedGrapht_Run()
        {
        }

        public void GreateDirectedGraph()
        {
        }

        public void IsRouteExistInDirectedGrapht(Graph graph, GraphNode startNode, GraphNode endNode)
        {
        }

        //Search element with integer data
        private GraphNode SearchBFS(GraphNode node, int valueToCheck)
        {
            //validate node
            if (node == null)
            {
                return node;
            }

            Queue<GraphNode> nodesToProcess = new Queue<GraphNode>();
            //mark as visited
            node.MarkAsVisited = true;
            //Add first node/root to queue
            nodesToProcess.Enqueue(node);

            while (nodesToProcess.Count > 0)
            {
                GraphNode currentNode = nodesToProcess.Dequeue();

                //visit node
                if (currentNode.Value == valueToCheck)
                {
                    return currentNode;
                }

                foreach (GraphNode adjecentNode in currentNode.Childrens)
                {
                    if (!adjecentNode.MarkAsVisited)
                    {
                        adjecentNode.MarkAsVisited = true;
                        nodesToProcess.Enqueue(adjecentNode);
                    }
                }
                currentNode = nodesToProcess.Dequeue();
            }

            //Element/Node not found
            return null;
        }

        //Search element with integer data
        //Pre-Order traversal
        private GraphNode SearchDFS(GraphNode node, int valueToCheck)
        {
            //validate node
            if (node == null)
            {
                return node;
            }

            //visit node
            if (node.Value == valueToCheck)
            {
                return node;
            }

            //mark as visited
            node.MarkAsVisited = true;

            //Check for adjecent node
            foreach (GraphNode adjecentNode in node.Childrens)
            {
                if (!adjecentNode.MarkAsVisited)
                {
                    //Search reccursively starting with first adjucent node
                    return SearchDFS(adjecentNode, valueToCheck);
                }
            }

            //Element/Node not found
            return null;
        }
    }
}