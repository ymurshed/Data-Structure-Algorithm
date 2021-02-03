using AllAboutAlgorithm.Algorithm;
using System;

namespace AllAboutAlgorithm.Clients
{
    public class QuickUnionUfClient
    {
        public static void Client()
        {
            int[] items = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var uf = new QuickUnionUf(items);
            uf.Union(1, 2);
            uf.Union(1, 3);
            uf.Union(1, 6);
            //uf.Union(2, 5);
            //uf.Union(2, 7);
            //uf.Union(3, 4);
            //uf.Union(6, 8);
            //uf.Union(8, 9);

            var connected = uf.Connected(3, 6) ? "Connected" : "Not Connected";
            Console.WriteLine(connected);

            connected = uf.Connected(3, 5) ? "Connected" : "Not Connected";
            Console.WriteLine(connected);
        }
    }
}
