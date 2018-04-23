using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    class Start
    {
        private List<string> listDataString;
        private FileReader fileReader;
        private List<KeyValuePair<string, int[]>> kvpList;
        private TreeNode root;
        private int dimension;


        static void Main(string[] args)
        {
            Start prog = new Start();
        }

        public Start()
        {
            //Initializes
            listDataString = new List<string>();
            fileReader = new FileReader();
            kvpList = new List<KeyValuePair<string, int[]>>();

            Console.WriteLine("Press Enter to Begin...");
            Console.ReadLine();
            Console.Write("Enter File: ");
            string fileName = @"..\..\Data\Sample" + Console.ReadLine() +"D.txt";

            SetDataPoints(fileName);

            foreach (KeyValuePair<string, int[]> node in kvpList)
            {
                if (root == null)
                {
                    root = new TreeNode(0, kvpList[0].Value, kvpList[0].Key);
                }
                SetKDTree(node, root);
            }

            Console.WriteLine(root.ToString("root"));
            //DataPointsToString();

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
        
        /// <summary>
        /// Method reads the input file and converts the data into a key value pair list.
        /// </summary>
        /// <param name="fileName"></param>
        public void SetDataPoints(string fileName)
        {
            listDataString = fileReader.GetTxtFile(fileName);
            foreach (string line in listDataString)
            {
                string[] splitString = line.Split(';');
                string[] splitInt = splitString[1].Split(',');
                int[] values = Array.ConvertAll(splitInt, int.Parse);
                dimension = splitInt.Length;
                KeyValuePair<string, int[]> tempKvp = new KeyValuePair<string, int[]>(splitString[0], values);
                kvpList.Add(tempKvp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetKDTree(KeyValuePair<string,int[]> node, TreeNode currentNode)
        {
            int d = currentNode.GetLevel() % dimension;
            if(currentNode.GetValues()[d] > node.Value[d]) //Left
            {
                if(currentNode.left == null)
                {
                    currentNode.left = new TreeNode(currentNode.GetLevel()+1, node.Value, node.Key);
                }
                else
                {
                    SetKDTree(node, currentNode.left);
                }
            }
            else if (currentNode.GetValues()[d] < node.Value[d]) //Right
            {
                if (currentNode.right == null)
                {
                    currentNode.right = new TreeNode(currentNode.GetLevel() + 1, node.Value, node.Key);
                }
                else
                {
                    SetKDTree(node, currentNode.right);
                }
            }
            else
            {
                //Do nothing
            }
        }

        public void DataPointsToString()
        {
            foreach(string line in listDataString)
            {
                Console.WriteLine(line);
            }
        }
    }
}