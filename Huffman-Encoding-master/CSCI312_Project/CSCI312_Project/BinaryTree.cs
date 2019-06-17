using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI312_Project
{
    class BinaryTree<E>
    {
        private BinaryTreeNode<E> root;
        private BinaryTreeNode<E> current;
        private int size;

        private String encoding;

        public enum Relative : int
        {
            leftChild, rightChild, parent, root
        };

        public BinaryTree()
        {
            root = null;
            current = null;
            size = 0;
        }
        public BinaryTree(E data)
        {
            root = new BinaryTreeNode<E>(data);
            current = null;
            size = 0;
        }

        public void Destroy(BinaryTreeNode<E> node)
        {
            if (node != null)
            {
                Destroy(node.Left);
                Destroy(node.Right);
                node = null;
                size--;
            }
        }

        public Boolean isEmpty()
        {
            return root == null;
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public BinaryTreeNode<E> Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }

        public BinaryTreeNode<E> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }

        public void Encode(BinaryTreeNode<E> p, LinkedList<encoding> encode)
        {
            if (p != null)
            {
                encoding += "0";
                Encode(p.Right, encode);

                if(p.isLeaf())
                {
                    encoding encoder = new encoding(p.Data.ToString(), encoding);
                    encode.AddFirst(encoder);
                }
                encoding += "1";
                Encode(p.Left, encode);
                if (encoding.Length >= 1)
                    encoding = encoding.Remove(encoding.Length - 1);
            }
            else
            {
                //Should remove the last character from the encoding table if the traversal back tracks to a node it already visted
                encoding = encoding.Remove(encoding.Length - 1);
            }
        }

        private BinaryTreeNode<E> findParent(BinaryTreeNode<E> n)
        {
            Stack<BinaryTreeNode<E>> s = new Stack<BinaryTreeNode<E>>();
            n = root;
            while (n.Left != current && n.Right != current)
            {
                if (n.Right != null)
                    s.Push(n.Right);
                if (n.Left != null)
                    n = n.Left;
                else
                    n = s.Pop();
            }
            s.Clear();
            return n;
        }

        public Boolean Insert(BinaryTreeNode<E> node, Relative rel)
        {
            Boolean inserted = true;
            if ((rel == Relative.leftChild && current.Left != null)|| (rel == Relative.rightChild && current.Right != null))
            {
                inserted = false;
            }
            else
            {
                switch(rel)
                {
                    case Relative.leftChild:
                        current.Left = node;
                        break;
                    case Relative.rightChild:
                        current.Right = node;
                        break;
                    case Relative.root:
                        if (root == null)
                            root = node;
                        current = root;
                        break;
                }
                size++;
            }
            return inserted;
        }

        public Boolean Insert(E data, Relative rel)
        {
            Boolean inserted = true;

            BinaryTreeNode<E> node = new BinaryTreeNode<E>(data);

            if ((rel == Relative.leftChild && current.Left != null)
                    || (rel == Relative.rightChild && current.Right != null))
            {
                inserted = false;
            }
            else
            {
                switch (rel)
                {
                    case Relative.leftChild:
                        current.Left = node;
                        break;
                    case Relative.rightChild:
                        current.Right = node;
                        break;
                    case Relative.root:
                        if (root == null)
                            root = node;
                        current = root;
                        break;
                }
                size++;
            }

            return inserted;
        }

        public Boolean moveTo(Relative rel)
        {
            Boolean found = false;

            switch (rel)
            {
                case Relative.leftChild:
                    if (current.Left != null)
                    {
                        current = current.Left;
                        found = true;
                    }
                    break;
                case Relative.rightChild:
                    if (current.Right != null)
                    {
                        current = current.Right;
                        found = true;
                    }
                    break;
                case Relative.parent:
                    if (current != root)
                    {
                        current = findParent(current);
                        found = true;
                    }
                    break;
                case Relative.root:
                    if (root != null)
                    {
                        current = root;
                        found = true;
                    }
                    break;
            } // end Switch relative

            return found;
        }
    }
}
