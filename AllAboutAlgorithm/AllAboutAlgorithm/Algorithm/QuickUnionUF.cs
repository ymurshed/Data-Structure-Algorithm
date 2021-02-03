namespace AllAboutAlgorithm.Algorithm
{
    // Algorithm used for Dynamic Connectivity
    // index contains the item and value contains the index item's root

    public class QuickUnionUf
    {
        private readonly int[] _id;

        public QuickUnionUf(int n)
        {
            _id = new int[n];
            
            for (int i = 0; i < n; i++) 
                _id[i] = i;
        }

        public QuickUnionUf(int[] items)
        {
            _id = items;
        }

        private int Root(int i)
        {
            while (i != _id[i])
                i = _id[i];
            
            return i;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            var i = Root(p);
            var j = Root(q);
            _id[i] = j;
        }
    }
}
