namespace FOREST_FIRE_SIMULATOR
{
    /// <summary>
    /// Represents 'Tree' in the forest
    /// </summary>
    public class Tree
    {
        public TreeState treeState;
        public int firedStep = -1;

        /// <summary>
        /// Constructor
        /// </summary>
        public Tree()
        {
            this.treeState = TreeState.Tree;
        }

        /// <summary>
        /// Prints ASCII value corrponding to the state of the tree.
        /// </summary>
        /// <returns></returns>
        public String getTreeStateRepresentation()
        {
            if (this.treeState == TreeState.Tree)
                return "&";
            else if (this.treeState == TreeState.Burning)
                return "x";
            else
                return " ";
        }

        /// <summary>
        /// Checks if any of the neighboring tree is burning.
        /// </summary>
        /// <param name="forest">2D Tree array</param>
        /// <param name="x">x - position</param>
        /// <param name="y">y - position</param>
        /// <returns></returns>
        public Boolean isNeighborTreeBurning(Tree[,] forest, int x, int y)
        {
            if ((x - 1 >= 0 && forest[x - 1, y].treeState == TreeState.Burning) ||
                (x + 1 < Forest.lengthOfForest && forest[x + 1, y].treeState == TreeState.Burning) ||
                (y - 1 >= 0 && forest[x, y - 1].treeState == TreeState.Burning) ||
                (y + 1 < Forest.breadthOfForest && forest[x, y + 1].treeState == TreeState.Burning))
                return true;
            return false;
        }
    }
}
