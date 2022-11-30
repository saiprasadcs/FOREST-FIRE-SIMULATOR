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
            for(int i = 0; i < Forest.lengthOfForest; i++)
            {
                for(int j = 0; j < Forest.breadthOfForest; j++)
                {
                    this.forest[i, j] = new Tree();
                }
            }
        }

        public void showForest()
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
                    Console.Write(this.forest[i, j].getTreeStateRepresentation() + ' ');
                }
                Console.Write("\n");
            }
        }

        public void setForestFire()
        {
            Random random = new Random();
            int xIndex = random.Next(0, 20);
            int yIndex = random.Next(0, 20);
            this.forest[xIndex, yIndex].treeState = TreeState.Burning;
            this.forest[xIndex, yIndex].firedStep = 1;
        }

        public void simulateForestFire()
        {
            int step = 0;
            setForestFire();
            showForest();
            Console.ReadLine();
            while (true)
            {
                spreadForestFire(step++);
                Console.ReadLine();
            }
        }

        public void spreadForestFire(int step)
        {
            for (int i = 0; i < lengthOfForest; i++)
            {
                for (int j = 0; j < breadthOfForest; j++)
                {
                    if (this.forest[i, j].isNeighBourTreeBurning(this.forest, i, j)
                       && isFireSpreads() && this.forest[i, j].treeState == TreeState.Tree)
                    {
                        this.forest[i, j].treeState = TreeState.Burning;
                        this.forest[i, j].firedStep = step;
                    } else if (this.forest[i, j].treeState == TreeState.Burning && this.forest[i, j].firedStep < step)
                    {
                        this.forest[i, j].treeState = TreeState.Empty;
                    }
                }
            }
            showForest();
        }

        public Boolean isFireSpreads()
        {
            Random random = new Random();
            int r = random.Next(0,100);
            if (r < 50)
                return true;
            return false;
        }
    }
}