using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinarySearchTree.DataAccess.Implementations
{
    public class BinarySearchTreeClass : IBinarySearchTree
    {
        public INode Root { get; set; }
        public string InOrderTraverse()
        {
            BSTTraversalEngine.InOrderEngine(Root);
            var result = BSTTraversalEngine.Infix;
            BSTTraversalEngine.Infix.Clear();
            return string.Join(" ", result); 
        }
        public string PostOrderTraverse()
        {
            BSTTraversalEngine.PostOrderEngine(Root);
            var result = BSTTraversalEngine.Postfix;
            BSTTraversalEngine.Postfix.Clear();
            return string.Join(" ", result);
        }
        public string PreOrderTraverse()
        {
            BSTTraversalEngine.PreOrderEngine(Root);
            var result = BSTTraversalEngine.Prefix;
            BSTTraversalEngine.Prefix.Clear();
            return string.Join(" ", result); 
        }
        public void Delete(INode root,int key)
        {
            INode nodeToDelete = root;
            INode parent=null;
            while (nodeToDelete.Value != key)
            {
                if (nodeToDelete.Value > key)
                {
                    parent = nodeToDelete;
                    nodeToDelete = nodeToDelete.Left;
                }
                else if (nodeToDelete.Value < key)
                {
                    parent = nodeToDelete;
                    nodeToDelete = nodeToDelete.Right;
                }
            }
            if (nodeToDelete.HasNoChild)
            {
                if (nodeToDelete==parent.Left)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (nodeToDelete.HasLeftChild || nodeToDelete.HasRightChild)
            {
                var child = nodeToDelete.HasRightChild?nodeToDelete.Right:nodeToDelete.Left;
                nodeToDelete = child; 
            } 
            else if (!nodeToDelete.HasNoChild)
            {
                var min = GetMin(nodeToDelete.Right);
                nodeToDelete.Value=min.Value;
                Delete(nodeToDelete.Right, min.Value);
            }

        }
        public INode Insert(int entity)
        {
            INode node = new Node(entity);
            if (Root == null)
            {
                Root = new Node(entity);
            }
            INode previos = null;
            INode current = Root;
            while (current != null)
            {
                if (current.Value > entity)
                {
                    previos = current;
                    current = current.Left;
                }
                else if (current.Value < entity)
                {
                    previos = current;
                    current = current.Right;
                }
            }
            if (previos.Value > entity)
            {
                previos.Left = node;
            }
            else
            {
                previos.Right = node;
            }
            return node;
        }
        public INode GetMax(INode current)
        {
            INode currentNode=current;
            while (currentNode.HasRightChild)
            {
                currentNode = currentNode.Right;
            }
            return current;
        }
        public INode GetMin(INode current)
        {
            INode currentNode = Root;
            while (current.HasLeftChild)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }
        public INode Search(int entity)
        {
            INode current = Root;
            while (current != null && current.Value != entity)
            {
                if (entity < current.Value)
                {
                    current = current.Left;
                }
                else if (entity > current.Value)
                {
                    current = current.Right;
                }
            }
            return current;
        }
    }
}
