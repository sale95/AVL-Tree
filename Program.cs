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
            avl.Insert(1);
            avl.Insert(3);
            avl.Insert(2);
            Console.WriteLine(avl.root.data);
        }
    }
}
