using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree avl = new Tree();
            avl.Insert(5);
            avl.Insert(2);
            avl.Insert(12);
            avl.Insert(1);
            avl.Insert(3);
            avl.Insert(9);
            avl.Insert(21);
            avl.Insert(19);
            avl.Insert(25);
            //avl.Remove(avl.root, 18);
            avl.Print(avl.root.right.right);
            //Console.WriteLine(avl.root.data);
        }
    }
}
