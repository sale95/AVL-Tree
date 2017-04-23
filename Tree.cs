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

        public void Remove(Node node, int value)
        {
            if(node == null)
            {
                return;
            }

            if(value > node.data)
            {
                Remove(node.right, value);
            }
            else if(value < node.data)
            {
                Remove(node.left, value);
            }
            else
            {
                Node parent = node.parent;

                if(node.left == null && node.right == null)
                {
                    if(parent.left == node)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }
                else if(node.left != null && node.right != null)
                {

                }
                else
                {
                    
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
            //Check balance up to root.
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
            //LeftRight Rotation
            if(bf == 2 && BalanceFactor(1 + Height(node.left.left), 1 + Height(node.left.right)) == -1)
            {
                LeftRotation(node.left);
                RightRotation(node);
            }
            //RightLeft Rotation
            else if(bf == -2 && BalanceFactor(1 + Height(node.right.left), 1 + Height(node.right.right)) == 1)
            {
                RightRotation(node.right);
                LeftRotation(node);
            }
            //Left Rotation
            else if(bf == -2 && BalanceFactor(1 + Height(node.right.left), 1 + Height(node.right.right)) == -1)
            {
                LeftRotation(node);
            }
            //Right Rotation
            else if(bf == 2 && BalanceFactor(1 + Height(node.left.left), 1 + Height(node.left.right)) == 1)
            {
                RightRotation(node);
            }
        }

		/**
         * This function does left rotation on a node.
         * */
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
                
                //If nodes right node has left node, attach that node to current node.
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

                //If current node is left child, temp will be left child too (LR case)
                if (node == node.parent.left)
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
		
		/**
         * This function does right rotation on a node.
         **/
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

                //If nodes left node has right node, attach it to current node.
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

                //If current node is right child, temp will be right child (RL case)
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
