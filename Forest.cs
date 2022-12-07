namespace FOREST_FIRE_SIMULATOR
{
    /// <summary>
    /// Represent the forest where the fire simulation is done
    /// </summary>
    public class Forest
    {
        public static int lengthOfForest = 21;
        public static int breadthOfForest = 21;
        public Tree[,] forest;
        public Weather weather;
        public Fuel fuel;
        public Topography topography;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="weather">Weather entity</param>
        /// <param name="fuel">Fuel entity</param>
        /// <param name="topography">Topography entity</param>
        public Forest(Weather weather, Fuel fuel, Topography topography)
        {
            this.weather = weather;
            this.fuel = fuel;
            this.topography = topography;
            this.forest = new Tree[lengthOfForest, breadthOfForest];
        }

        /// <summary>
        /// Display the forest map in console.
        /// </summary>
        public void showForest()
        {
            Console.Clear();
            Console.WriteLine("Entered Fire Impact due to various factors:\n");
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

        /// <summary>
        /// Sets fire in the 1st step in random position.
        /// </summary>
        public void setForestFire()
        {
            Random random = new Random();
            int xIndex = random.Next(0, 20);
            int yIndex = random.Next(0, 20);
            this.forest[xIndex, yIndex].treeState = TreeState.Burning;
            this.forest[xIndex, yIndex].firedStep = 1;
        }

        /// <summary>
        /// Elemental method called from main method to simulate forest fire.
        /// </summary>
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

        /// <summary>
        /// Iterates the 2D array of Tree(s) and 
        /// update the state based on its previous and neighbor tree's state.
        /// </summary>
        /// <param name="step"></param>
        public void spreadForestFire(int step)
        {
            for (int i = 0; i < lengthOfForest; i++)
            {
                for (int j = 0; j < breadthOfForest; j++)
                {
                    if (this.forest[i, j].isNeighborTreeBurning(this.forest, i, j)
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

        /// <summary>
        /// Computes probability for fire spread
        /// </summary>
        /// <returns></returns>
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