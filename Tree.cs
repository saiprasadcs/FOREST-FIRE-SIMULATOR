using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOREST_FIRE_SIMULATOR
{
    public class Tree
    {
        public TreeState treeState;

        public Tree()
        {
            this.treeState = TreeState.Tree;
        }

        public String getTreeStateRepresentation()
        {
            if (this.treeState == TreeState.Tree)
                return "&";
            else if (this.treeState == TreeState.Burning)
                return "x";
            else
                return " ";
        }

        public Boolean isNeighBourTreeBurning(Tree[,] forest, int x, int y)
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
