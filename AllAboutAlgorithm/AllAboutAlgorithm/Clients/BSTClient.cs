using AllAboutAlgorithm.Algorithm;
using System;

namespace AllAboutAlgorithm.Clients
{
    public class BstClient
    {
        public static void Client()
        {
            Tree temp;
            var root = temp = null;

            Console.WriteLine("Create Tree:");
            var bst = new Bst();

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

            var val = 15;
            temp = bst.Search(ref root, val);
            if (temp != null && bst.IsFound)
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
        }
    }
}
