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
            avl.Insert(10);
            avl.Insert(4);
            avl.Insert(2);
            avl.Insert(9);
            avl.Insert(12);
            avl.Insert(15);
            avl.Remove(avl.root, 15);
            avl.Print(avl.root);
            //Console.WriteLine(avl.root.data);
        }
    }
}
