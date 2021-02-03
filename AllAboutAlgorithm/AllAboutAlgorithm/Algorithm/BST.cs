using System;

namespace AllAboutAlgorithm.Algorithm
{

    /*************** Actual tree **********************/
    //                    9
    //            4               15
    //        2       6       12      17
    //
    /*************************************************/

    public class Tree
    {
        public int Data;
        public Tree Left, Right;
    }

    public class Bst
    {
        public bool IsFound;

        public void InsertChild(ref Tree tree, int val)
        {
            if (tree == null)
            {
                tree = new Tree {Data = val};
                tree.Left = tree.Right = null;
                return;
            }

            if (val < tree.Data)
                InsertChild(ref tree.Left, val);

            else if (val > tree.Data)
                InsertChild(ref tree.Right, val);
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
                Console.WriteLine(tree.Data);
                Print_Preorder(tree.Left);
                Print_Preorder(tree.Right);
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
                Print_Inorder(tree.Left);
                Console.WriteLine(tree.Data);
                Print_Inorder(tree.Right);
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
                Print_Postorder(tree.Left);
                Print_Postorder(tree.Right);
                Console.WriteLine(tree.Data);
            }
        }

        public void DeleteTree(ref Tree tree)
        {
            if (tree != null)
            {
                DeleteTree(ref tree.Left);
                DeleteTree(ref tree.Right);
                tree = null;
            }
        }

        public Tree Search(ref Tree tree, int val)
        {
            Tree temp = null;

            if (tree == null)
                return null;

            if (val < tree.Data)
            {
                Search(ref tree.Left, val);
                temp = tree.Left;
            }
            else if (val > tree.Data)
            {
                Search(ref tree.Right, val);
                temp = tree.Right;
            }
            else if (val == tree.Data)
                IsFound = true;

            return temp;
        }
    }
}
