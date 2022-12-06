namespace FOREST_FIRE_SIMULATOR
{
    public class Forest
    {
        public static int lengthOfForest = 21;
        public static int breadthOfForest = 21;
        public Tree[,] forest;
        public Weather weather;
        public Fuel fuel;
        public Topography topography;

        public Forest(Weather weather, Fuel fuel, Topography topography)
        {
            this.weather = weather;
            this.fuel = fuel;
            this.topography = topography;
            this.forest = new Tree[lengthOfForest, breadthOfForest];
        }

        public void showForest()
        {
            Console.Clear();
            Console.WriteLine("Entered Fire Impact due to various factors: ");
            Console.WriteLine("Weather: " + this.weather.GetFireImpact());
            Console.WriteLine("Fuel: " + this.fuel.GetFireImpact());
            Console.WriteLine("Topography: " + this.topography.GetFireImpact());
            double probability = (this.weather.getProbability() +
                this.fuel.getProbability() + this.topography.getProbability()) * 100;
            Console.WriteLine("Probability of fire spread: " + probability.ToString("0.00") + "%");
            Console.WriteLine("");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -");
            for (int i = 0; i < lengthOfForest; i++)
            {
                Console.Write("- ");
                for (int j = 0; j < breadthOfForest; j++)
                {
                    if (this.forest[i, j] == null)
                    {
                        this.forest[i, j] = new Tree();
                    }
                    Console.Write(this.forest[i, j].getTreeStateRepresentation() + ' ');
                }
                Console.Write("- \n");
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -");
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
            double fireSpreadingProbability = this.weather.getProbability() +
                this.fuel.getProbability() +
                this.topography.getProbability();
            Random random = new Random();
            double r = random.NextDouble() * (1);
            if (r <= fireSpreadingProbability)
                return true;
            return false;
        }
    }
}