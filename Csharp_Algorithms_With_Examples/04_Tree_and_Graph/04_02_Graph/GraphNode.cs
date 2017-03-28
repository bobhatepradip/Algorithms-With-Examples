namespace TWL_Algorithms_Samples.Graph
{
    public class GraphNode : Node
    {
        public GraphNode(int val) : base(val)
        {
        }
    }

    public class Node
    {
        public Node[] Childrens;
        public string Name;
        public int Value;

        public Node(int val)
        {
            this.Value = val;
        }
    }
}