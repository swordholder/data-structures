using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class CareerTree
    {
        private CNode root;

        public void Insert(string parentName, string name)
        {
            if (string.IsNullOrEmpty(parentName))
            {
                root = new CNode(name);//root node
                root.Parent = null;
                return;
            }

            var parentNode = GetNodeByName(root, parentName);

            if (parentNode == null)
            {
                Console.WriteLine("Node with name {0} not found !", parentName);
                return;
            }

            if (parentNode.Left == null)
            {
                parentNode.Left = new CNode(name);
                parentNode.Left.Parent = parentNode;
                return;
            }

            if (parentNode.Right == null)
            {
                parentNode.Right = new CNode(name);
                parentNode.Right.Parent = parentNode;
                return;
            }

            Console.WriteLine("Parent node {0} is full. Left child: {1}, right child: {2}", parentName, parentNode.Left.Name, parentNode.Right.Name);
            return;
        }

        private CNode GetNodeByName(CNode node, string name)
        {
            if (string.IsNullOrEmpty(name) || node == null)
                return null;

            if (node.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return node;

            if (node.Left != null)
            {
                var leftNode = GetNodeByName(node.Left, name);
                if (leftNode != null)
                    if (leftNode.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        return leftNode;
            }

            if (node.Right != null)
            {
                var rightNode = GetNodeByName(node.Right, name);
                if (rightNode != null)
                    if (rightNode.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        return rightNode;
            }
            
            return null;
        }

        
        public CNode FindCommonManager(string emp1, string emp2)
        {
            var emp1Node = GetNodeByName(root,emp1);
            var emp2Node = GetNodeByName(root, emp2);

            if (emp1 == null || emp2 == null)
            {
                Console.WriteLine("Employee(s) not found");
                return null;
            }

            if (IsManager(emp1Node, emp2))
                return emp1Node;

            if (IsManager(emp2Node, emp1))
                return emp2Node;


            var list1 = GetManagersList(emp1Node);
            var list2 = GetManagersList(emp2Node);

            list1.Reverse();
            list2.Reverse();

            int i = -1;
            int minItemsCount = (list1.Count > list2.Count ? list2.Count : list1.Count)-1;

            while (minItemsCount > i && list1[i+1].Name.Equals(list2[i+1].Name))
                i++;
            
            return list1[i];
        }

        private List<CNode> GetManagersList(CNode emp1)
        {
            var list = new List<CNode>();

            while (emp1.Parent != null)
            {
                list.Add(emp1.Parent);
                emp1 = emp1.Parent;
            }

            return list;
        }

        private bool IsManager(CNode node, string child)
        {
            if (node.Left != null && node.Left.Name.Equals(child, StringComparison.OrdinalIgnoreCase))
                return true;

            if (node.Right != null && node.Right.Name.Equals(child, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
    }

    public class CNode
    {
        public CNode(string name)
        {
            Name = name;
        }

        public CNode Parent;
        public string Name;
        public CNode Left;
        public CNode Right;
    }
}
