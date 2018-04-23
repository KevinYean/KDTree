using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KDTree;

namespace KDTreeTests
{
    [TestClass]
    public class TreeNodeTest
    {
        int[] values = new int[] { 1, 2 };
        int[] values1 = new int[] { 2, 3 };
        int[] values2 = new int[] { 4, 5 };
        int[] values3 = new int[] { 0, 3 };
        int[] values4 = new int[] { 10, 5 };

        [TestMethod]
        public void LevelInitialization()
        {
            TreeNode tree = new TreeNode(0,values,"A");
            Assert.AreEqual(tree.GetLevel(), 0);
        }

        [TestMethod]
        public void LengthInitialization()
        {
            TreeNode tree = new TreeNode(0, values,"A");
            Assert.AreEqual(tree.GetValues().Length, 2);
        }

        [TestMethod]
        public void ValueInitialization()
        {
            TreeNode tree = new TreeNode(0, values,"A");
            Assert.AreEqual(tree.GetValues()[0], 1);
            Assert.AreEqual(tree.GetValues()[1], 2);
        }

        [TestMethod]
        public void NodeInsertion()
        {
            TreeNode root = new TreeNode(0, values,"A");
            TreeNode node1 = new TreeNode(1, values1,"B");
            TreeNode node2 = new TreeNode(1, values2,"C");
            TreeNode node3 = new TreeNode(1, values3,"D");
            TreeNode node4 = new TreeNode(1, values4,"E");

            root.AddLeft(node1);
            node1.AddLeft(node2);
            node1.AddRight(node3);
            root.AddRight(node4);

            Assert.AreEqual(root.left.GetValues()[0], 2);
            Assert.AreEqual(root.left.left.GetValues()[0], 4);
            Assert.AreEqual(root.right.GetValues()[1], 5);
            Assert.AreEqual(root.left.right.GetValues()[0], 0);
        }
    }
}
