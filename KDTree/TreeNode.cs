using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class TreeNode
    {
        private int level;
        private int[] values;
        private string label;

        public TreeNode left;
        public TreeNode right;

        public TreeNode(int newLevel, int[] newValues, string newLabel)
        {
            level = newLevel;
            values = newValues;
            label = newLabel;
        }

        public void AddLeft(TreeNode newLeft)
        {
            left = newLeft;
        }

        public void AddRight(TreeNode newLeft)
        {
            right = newLeft;
        }

        public int GetLevel()
        {
            return level;
        }

        public int[] GetValues()
        {
            return values;
        }

        public string ToString(string branch)
        {
            string line = "";
            if (level > 0)
            {
                for(int i = 0; i < level-1; i++)
                {
                    line += "    ";
                }
                line+="└── ";
            }
            line += label + " (" + branch + ")";
            line += "\n";
            
            //Checks both branches
            if(left != null)
            {
                line += left.ToString("L");
            }
            if(right != null)
            {
                line += right.ToString("R");
            }
            //Console.WriteLine(line);
            return line;
        }
    }
}
