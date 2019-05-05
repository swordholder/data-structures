using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Tree
    {
        private List<int> path1 = new List<int>();
        private List<int> path2 = new List<int>();

        public Node Root { get; set; }

        public void Insert(ref Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                Root = root;
                return;
            }
            if (root.Data > value)
            {
                Insert(ref root.Left, value);
                return;
            }
            else
            {
                Insert(ref root.Right, value);
                return;
            }
        }

        public bool IsLeaf(Node node)
        {
            if (node.Left == null && node.Right == null)
                return true;

            return false;
        }

        public void Print(Node node)
        {
            if (node == null)
                return;

            Print(node.Left);
            Console.Write("{0} ",node.Data);
            Print(node.Right);
        }

        public bool Search(Node root, int value)
        {
            if (root == null)
                return false;

            if (root.Data == value)
                return true;

            if (root.Data > value)
                return Search(root.Left, value);
            else
                return Search(root.Right,value);
        }

        public int FindLCA(int n1, int n2)
        {
            path1.Clear();
            path2.Clear();
            return FindLCAInternal(Root, n1, n2);
        }

        private int FindLCAInternal(Node root, int n1, int n2)
        {

            if (!FindPath(root, n1, path1) || !FindPath(root, n2, path2))
            {
                Console.WriteLine((path1.Count > 0) ? "n1 is present" : "n1 is missing");
                Console.WriteLine((path2.Count > 0) ? "n2 is present" : "n2 is missing");
                return -1;
            }

            int i;
            for (i = 0; i < path1.Count && i < path2.Count; i++)
            {
                if (!path1[i].Equals(path2[i]))
                    break;
            }

            return path1[i - 1];
        }

        private bool FindPath(Node root, int n, List<int> path)
        {
            if (root == null)
            {
                return false;
            }

            path.Add(root.Data);

            if (root.Data == n)
            {
                return true;
            }

            if(n<root.Data)
                if (root.Left != null && FindPath(root.Left, n, path))
                {
                    return true;
                }

            if(n>root.Data)
                if (root.Right != null && FindPath(root.Right, n, path))
                {
                    return true;
                }

            path.Remove(path.Count - 1);

            return false;
        }
    }    

    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Data = value;
            Left = null;
            Right = null;
        }
    }
}
