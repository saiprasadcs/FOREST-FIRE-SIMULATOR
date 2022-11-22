namespace FOREST_FIRE_SIMULATOR
{
    public class Forest
    {
        public static int lengthOfForest = 21;
        public static int breadthOfForest = 21;
        public Tree[,] forest;

        public Forest()
        {
            this.forest = new Tree[Forest.lengthOfForest, Forest.breadthOfForest];
        }

        public void displayForest()
        {
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("FOREST-FIRE-SIMULATOR\n");
                for (int i = 0; i < Forest.lengthOfForest; i++)
                {
                    for (int j = 0; j < Forest.breadthOfForest; j++)
                    {
                        if (this.forest[i, j] == null)
                        {
                            this.forest[i, j] = new Tree();
                        }
                        Console.Write(this.forest[i, j].getTreeStateSymbol() + ' ');
                    }
                    Console.Write("\n");
                }
                Console.ReadLine();
            }
        }
    }

    public class Tree
    {
        public TreeState treeState;

        public Tree()
        {
            this.treeState = TreeState.Tree;
        }

        public String getTreeStateSymbol()
        {
            if (this.treeState == TreeState.Tree)
                return "&";
            else if (this.treeState == TreeState.Burning)
                return "x";
            else
                return " ";
        }

    }
}