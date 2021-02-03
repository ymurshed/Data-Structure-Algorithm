using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*************** Actual tree **********************/
//                    9
//            4               15
//        2       6       12      17
//
/*************************************************/

namespace BST
{
    public class Tree
    {
        public int data;
        public Tree left, right;
    }

    class BST
    {
        public bool isFound = false;

        public void InsertChild(ref Tree tree, int val)
        {
            if (tree == null)
            {
                tree = new Tree();
                tree.data = val;
                tree.left = tree.right = null;
                return;
            }

            if (val < tree.data)
                InsertChild(ref tree.left, val);

            else if (val > tree.data)
                InsertChild(ref tree.right, val);
        }


        //Pre Order Display
        //9
        //4
        //2
        //6
        //15
        //12
        //17
        public void Print_Preorder(Tree tree)
        {
            if (tree != null)
            {
                Console.WriteLine(tree.data);
                Print_Preorder(tree.left);
                Print_Preorder(tree.right);
            }
        }

        //In Order Display
        //2
        //4
        //6
        //9
        //12
        //15
        //17
        public void Print_Inorder(Tree tree)
        {
            if (tree != null)
            {
                Print_Inorder(tree.left);
                Console.WriteLine(tree.data);
                Print_Inorder(tree.right);
            }
        }

        //Post Order Display
        //2
        //6
        //4
        //12
        //17
        //15
        //9
        public void Print_Postorder(Tree tree)
        {
            if (tree != null)
            {
                Print_Postorder(tree.left);
                Print_Postorder(tree.right);
                Console.WriteLine(tree.data);
            }
        }

        public void DeleteTree(ref Tree tree)
        {
            if (tree != null)
            {
                DeleteTree(ref tree.left);
                DeleteTree(ref tree.right);
                tree = null;
            }
        }

        public Tree Search(ref Tree tree, int val)
        {
            Tree temp = null;

            if (tree == null)
                return null;

            else
            {
                if (val < tree.data)
                {
                    Search(ref tree.left, val);
                    temp = tree.left;
                }
                else if (val > tree.data)
                {
                    Search(ref tree.right, val);
                    temp = tree.right;
                }
                else if (val == tree.data)
                    isFound = true;

                return temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree root, temp;
            root = temp = null;

            Console.WriteLine("Create Tree:");
            BST bst = new BST();

            #region create tree
            bst.InsertChild(ref root, 9);
            bst.InsertChild(ref root, 4);
            bst.InsertChild(ref root, 15);
            bst.InsertChild(ref root, 6);
            bst.InsertChild(ref root, 12);
            bst.InsertChild(ref root, 17);
            bst.InsertChild(ref root, 2);
            #endregion

            #region print
            Console.WriteLine("Pre Order Display"); // actual tree
            bst.Print_Preorder(root);

            Console.WriteLine("In Order Display");
            bst.Print_Inorder(root);

            Console.WriteLine("Post Order Display");
            bst.Print_Postorder(root);
            #endregion

            #region searching

            int val = 15;
            temp = bst.Search(ref root, val);
            if (temp != null && bst.isFound)
            {
                Console.WriteLine("Searched node = {0}", val);
            }
            else
            {
                Console.WriteLine("Data not found in tree.");
            }
            #endregion

            #region delete
            bst.DeleteTree(ref root);
            #endregion

            Console.ReadLine();
        }
    }
}
