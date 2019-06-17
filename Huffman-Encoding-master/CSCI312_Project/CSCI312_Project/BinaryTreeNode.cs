using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI312_Project
{
    class BinaryTreeNode<E>
    {
        private E m_data;
        private BinaryTreeNode<E> m_left;
        private BinaryTreeNode<E> m_right;

        public BinaryTreeNode(E data)
        {
            m_data = data;
            m_left = null;
            m_right = null;
        }

        public E Data
        {
            get
            {
                return m_data;
            }
            
            set
            {
                m_data = value;
            }
        }

        public BinaryTreeNode<E> Left
        {
            get
            {
                return m_left;
            }
            set
            {
                m_left = value;
            }
        }

        public BinaryTreeNode<E> Right
        {
            get
            {
                return m_right;
            }
            set
            {
                m_right = value;
            }
        }

        public Boolean isLeaf()
        {
            return (m_left == null && m_right == null);
        }
    }
}
