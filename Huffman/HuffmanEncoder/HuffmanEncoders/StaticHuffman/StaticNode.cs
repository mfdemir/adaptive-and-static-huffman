using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class StaticHuffmanNode
    {
        public char? name;
        public int frequency = 0;
        public List<bool> binaryCode = new List<bool>();

        public StaticHuffmanNode left, right, parent;

        public bool isLeaf {
            get
            {
                return left == null && right == null;
                    }
        }
    }
}
