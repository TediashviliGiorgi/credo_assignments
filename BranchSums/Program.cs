namespace BranchSums
{
    using System;
using System.Collections.Generic;


public class BinaryTreeNode
{
    public int Data { get; set; }
    public BinaryTreeNode Left { get; set; }
    public BinaryTreeNode Right { get; set; }

    public BinaryTreeNode(int data)
    {
        Data = data;
    }

}

public class TreeOperations
{
    public static List<int> GetBranchSums(BinaryTreeNode root)
    {
        var sums = new List<int>();
        GetBranchSums(root, 0, sums);
        return sums;
    }

    private static void GetBranchSums(BinaryTreeNode node, int runningSum, List<int> sums)
    {
        if (node == null)
        {
            return;
        }

        var newRunningSum = runningSum + node.Data;
        if (node.Left == null && node.Right == null)
        {
            sums.Add(newRunningSum);
            return;
        }

        GetBranchSums(node.Left, newRunningSum, sums);
        GetBranchSums(node.Right, newRunningSum, sums);
    }

}
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = new BinaryTreeNode(1);
            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);
            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(5);
            root.Right.Left = new BinaryTreeNode(6);
            root.Right.Right = new BinaryTreeNode(7);
            root.Left.Left.Left = new BinaryTreeNode(8);
            root.Left.Left.Right = new BinaryTreeNode(9);
            root.Left.Right.Left = new BinaryTreeNode(10);



            var sums = TreeOperations.GetBranchSums(root);
            for(int i = 0; i < sums.Count; i++)
            {
                Console.WriteLine(sums[i]);
            }
            
          
        }
    }
}