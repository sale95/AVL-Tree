using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Tree
    {
        public Node root = null;
        public Node current = null;

        /**
         * This function inserts elemnt with BST order.
         * int value - Value that will be inserted.
         **/
        public void Insert(int value)
        {
            Node node = new Node(value);

            //If tree is empty insert element as a root.
            if (root == null)
            {
                root = node;
                current = root;
            }
            else
            {
                //If value is less than current data go left.
                if (value <= current.data)
                {
                    //If left is empty, insert and set parent to be current node.
                    if (current.left == null)
                    {
                        current.left = node;
                        node.parent = current;
                        Balance(node);
                        current = root;
                    }
					//If left is not empty, go to that node and call insert again.
                    else
                    {
                        current = current.left;
                        Insert(value);
                    }
                }
				//If value is bigger than current data, go right.
                else
                {
					//If right is empty, insert.
                    if (current.right == null)
                    {
                        current.right = node;
                        node.parent = current;
                        Balance(node);
                        current = root;
                    }
					//If it is not empty, go to that node and call insert again.
                    else
                    {
                        current = current.right;
                        Insert(value);
                    }
                }
            }
        }

        /**
         * This function prints tree inOrder.
         * */
        public void Print(Node node)
        {
            if (node == null)
            {
                return;
            }

            Print(node.left);
            Console.WriteLine(node.data);
            Print(node.right);
        }

        /**
         * This function checks balance and call appropriate rotation.
         * */      
        public void Balance(Node node)
        {
            //Balance factor
            int bf = 0;

            if (node == root)
            {
                bf = BalanceFactor(1 + Height(node.left), 1 + Height(node.right));
                if (bf == 2 || bf == -2)
                {
                    ChooseRotation(node, bf);
                }
                    
                return;
            }

            //Calculate balance factor and call rotation.
            bf = BalanceFactor(1 + Height(node.left), 1 + Height(node.right));
            if(bf == 2 || bf == -2)
            {
                ChooseRotation(node, bf);
                Balance(node.parent);
            }
            else
            {
                Balance(node.parent);
            }  
        }

        /**
         * This function selects rotation based on balance factor and nodes right or left child.
         **/
        public void ChooseRotation(Node node, int bf)
        {
            if(bf == 2 && BalanceFactor(1 + Height(node.left.left), 1 + Height(node.left.right)) == -1)
            {
                Console.WriteLine("node.left RotateLeft, RotateRight on {0}", node.data);
                LeftRotation(node.left);
                RightRotation(node);
            }
            else if(bf == -2 && BalanceFactor(1 + Height(node.right.left), 1 + Height(node.right.right)) == 1)
            {
                Console.WriteLine("node.right RotateRight, RotateLeft on {0}", node.data);
                RightRotation(node.right);
                LeftRotation(node);
            }
            else if(bf == -2 && BalanceFactor(1 + Height(node.right.left), 1 + Height(node.right.right)) == -1)
            {
                Console.WriteLine("Rotate Left on {0}", node.data);
                LeftRotation(node);
            }
            else if(bf == 2 && BalanceFactor(1 + Height(node.left.left), 1 + Height(node.left.right)) == 1)
            {
                Console.WriteLine("Rotate Right on {0}", node.data);
                RightRotation(node);
            }
        }

		//Done
        public void LeftRotation(Node node)
        {
            if(node == root)
            {
                Node temp = node.right;

                node.right = temp.left;
                temp.left = node;
                node.parent = temp;
                root = temp;
                root.parent = null;
            }
            else
            {
                Node temp = node.right;
                
                if(temp.left != null) 
                {
                    node.right = temp.left;
                    node.right.parent = node;
                }
                else
                {
                    node.right = null;
                }

                temp.left = node;
                temp.parent = node.parent;

                if(node == node.parent.left)
                {
                    temp.parent.left = temp;
                }
                else
                {
                    temp.parent.right = temp;
                }

                node.parent = temp;
            }
        }
		
		//In development.
        public void RightRotation(Node node)
        {
            if (node == root)
            {
                Node temp = node.left;

                node.left = temp.right;
                temp.right = node;
                node.parent = temp;
                root = temp;
                root.parent = null;
            }
            else
            {
                Node temp = node.left;

                if (temp.right != null)
                {
                    node.left = temp.right;
                    node.left.parent = node;
                }
                else
                {
                    node.left = null;
                }

                temp.right = node;
                temp.parent = node.parent;

                if (node == node.parent.right)
                {
                    temp.parent.right = temp;
                }
                else
                {
                    temp.parent.left = temp;
                }

                node.parent = temp;
            }
        }
		
		/**
		* This function calculates height of left subtree.
		* Node node - On this node calculation will be performed.
		**/
        public int Height(Node node)
        {
            if(node == null)
            {
                return -1;
            }
            else if(node.left == null && node.right == null)
            {
                return 0;
            }
            else if(node.left != null || node.right != null)
            {
                return 1 + Math.Max(Height(node.left), Height(node.right));
            }
         
            return 0;
        }

        public int BalanceFactor(int left, int right)
        {
            return left - right;
        }

    }
}
