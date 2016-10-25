using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new List<int> {2, 5, 50, 1 , 0, 240, 33, 0, -100, -1000, 4, 35 };

            BinarySearchTree bst = new BinarySearchTree();
            foreach(var a in array)
            {
                bst.BuildTree(null, a);
            }

            bst.InOrderTraversal(bst.RootNode);

            Console.Read();
        }
    }

    public class BinarySearchTree
    {
        public Node<int> RootNode { get; set; }

        public void BuildTree(Node<int> node, int value)
        {
            if(RootNode == null)
            {
                RootNode = new Node<int>(value);
            }
            else
            {
                AddNode(RootNode, value);
            }
        }

        public void AddNode(Node<int> node, int value)
        {
            if (value <= node.Value)
            {
                if (node.LeftChild != null)
                {
                    AddNode(node.LeftChild, value);
                }
                else
                {
                    node.LeftChild = new Node<int>(value);
                }
            }

            if (value > node.Value)
            {
                if (node.RightChild != null)
                {
                    AddNode(node.RightChild, value);
                }
                else
                {
                    node.RightChild = new Node<int>(value);
                }
            }
        }

        public void InOrderTraversal(Node<int> node)
        {
            if (node == null)
                return;

            InOrderTraversal(node.LeftChild);

            Console.Write(node.Value + " ");

            InOrderTraversal(node.RightChild);
        }
    }    

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}
