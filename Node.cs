using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Node
    {
        public Node parent;
        public Node left;
        public Node right;
        public int data;
        public int height;

        public Node(int data)
        {
            this.data = data;
            parent = null;
            left = null;
            right = null;
        }
    }
}
