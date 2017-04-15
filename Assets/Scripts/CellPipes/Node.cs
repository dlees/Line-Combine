using System.Collections.Generic;

public class Node {

    public Node(CellPipes block) 
    {
        this.block = block; 
        nodes = new List<Node>();
    }

    public CellPipes block;
    public List<Node> nodes;

    public bool isConnected(Node node)
    {
        return getConnected().Contains(node);
    }

    public HashSet<Node> getConnected()
    {
        Queue<Node> toSearch = new Queue<Node>();
        HashSet<Node> searched = new HashSet<Node>();

        toSearch.Enqueue(this);

        while (toSearch.Count > 0)
        {
            Node toCheck = toSearch.Dequeue();
            searched.Add(toCheck);

            foreach (Node child in toCheck.nodes)
            {
                if (!searched.Contains(child))
                {
                    toSearch.Enqueue(child);
                }
            }
        }

        return searched;
    }
}
