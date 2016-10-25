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
            var array = new List<int> {20, 5, 50, 10, 0, 240, 33, 0, -100, 5};

            //var array = new List<int> { 2, 5, 50, 1 };

            BinarySearchTree bst = new BinarySearchTree();
            foreach(var a in array)
            {
                bst.BuildTree(null, a);
            }

            bst.InOrderTraversal(bst.RootNode);
            Console.WriteLine();
            bst.PreOrderTraversal(bst.RootNode);
            Console.WriteLine();
            bst.PostOrderTraversal(bst.RootNode);
            Console.WriteLine();
            bst.ReverseInOrderTraversal(bst.RootNode);
            Console.WriteLine();
            bst.FindMin(bst.RootNode);

            Console.Read();
        }
    }

    public class BinarySearchTree
    {
        public Node<int> RootNode { get; set; }
        public int MinRoot { get; set; }

        public void BuildTree(Node<int> node, int value)
        {
            if(RootNode == null)
            {
                RootNode = new Node<int>(value);
                MinRoot = value;
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
                    if (value < MinRoot) MinRoot = value;
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
                    if (value < MinRoot) MinRoot = value;
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

        public void PreOrderTraversal(Node<int> node)
        {
            if (node == null)
                return;

            Console.Write(node.Value + " ");

            PreOrderTraversal(node.LeftChild);

            PreOrderTraversal(node.RightChild);
        }

        public void PostOrderTraversal(Node<int> node)
        {
            if (node == null)
                return;           

            PreOrderTraversal(node.LeftChild);

            PreOrderTraversal(node.RightChild);

            Console.Write(node.Value + " ");
        }

        public void ReverseInOrderTraversal(Node<int> node)
        {
            if (node == null)
                return;

            ReverseInOrderTraversal(node.RightChild);

            Console.Write(node.Value + " ");

            ReverseInOrderTraversal(node.LeftChild);                       
        }

        public void FindMin(Node<int> node)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                Console.WriteLine(node.Value);
                Console.WriteLine(MinRoot);
                return;
            }

            FindMin(node.LeftChild);
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
