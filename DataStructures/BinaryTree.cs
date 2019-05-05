using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class BinaryTree
    {
        public int bstDistance(int[] values, int n, int node1, int node2)
        {
            if (!values.Contains(node1) || values.Contains(node2))
                return -1;

            //build the tree
            Node root = null;
            Node tree = null;

            int i = 0;
            foreach (var item in values)
            {
                if (i == 0)
                {
                    tree = new Node(item);
                    root = tree;
                }
                else
                {
                    tree.insertData(ref root, item);
                }
                i++;
            }

            //find distance
            int x = Pathlength(root, node1) - 1;
            int y = Pathlength(root, node2) - 1;
            int lcaData = findLowestCommonAncestor(root, node1, node2).data;
            int lcaDistance = Pathlength(root, lcaData) - 1;
            return (x + y) - 2 * lcaDistance;
        }

        public int Pathlength(Node root, int n1)
        {
            if (root != null)
            {
                int x = 0;
                if ((root.data == n1) || (x = Pathlength(root.left, n1)) > 0
                        || (x = Pathlength(root.right, n1)) > 0)
                {
                    // System.out.println(root.data);
                    return x + 1;
                }
                return 0;
            }
            return 0;
        }

        public Node findLowestCommonAncestor(Node root, int n1, int n2)
        {
            if (root != null)
            {
                if (root.data == n1 || root.data == n2)
                {
                    return root;
                }
                Node left = findLowestCommonAncestor(root.left, n1, n2);
                Node right = findLowestCommonAncestor(root.right, n1, n2);

                if (left != null && right != null)
                {
                    return root;
                }
                if (left != null)
                {
                    return left;
                }
                if (right != null)
                {
                    return right;
                }
            }
            return null;
        }

        public class Node
        {
            public int data;
            public Node right;
            public Node left;

            public Node(int value)
            {
                data = value;
                right = null;
                left = null;
            }

            public void insertData(ref Node node, int dt)
            {
                if (node == null)
                {
                    node = new Node(dt);

                }
                else if (node.data < dt)
                {
                    insertData(ref node.right, dt);
                }

                else if (node.data > dt)
                {
                    insertData(ref node.left, dt);
                }
            }
        }
    }
}
