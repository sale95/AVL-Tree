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
            avl.Insert(10);
            avl.Insert(5);
            avl.Insert(15);
            avl.Insert(4);

            avl.Remove(avl.root, 15);
            Console.WriteLine(avl.min.data);
            //avl.Remove(avl.root, 18);
        }
    }
}
