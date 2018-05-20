using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class AdaptiveHuffmanEncoder
    {
        private AdaptiveHuffmanNode NYT = null;
        private AdaptiveHuffmanNode root = null;
        private List<AdaptiveHuffmanNode> nodes;
        private List<AdaptiveHuffmanNode> seen;

        public AdaptiveHuffmanEncoder()
        {
            NYT = new AdaptiveHuffmanNode() { symbol = char.MaxValue };
            root = NYT;
            nodes = new List<AdaptiveHuffmanNode>();
            seen = new List<AdaptiveHuffmanNode>();
            for (int i = 0; i < 256; i++)
            {
                seen.Add(null);
            }
        }
        public int Encode(Stream inputStream, Stream outputStream)
        {
            MemoryStream data = new MemoryStream();
            inputStream.CopyTo(data);
            
            string text = System.Text.Encoding.ASCII.GetString(data.GetBuffer(),0,(int)data.Length);


            List<bool> result = new List<bool>();


            foreach (char c in text)
            {
                if (seen[(int)c] != null)
                {
                    var res = GetCode(c, root);
                    result.AddRange(res);
                }
                else
                {
                    result.AddRange(GetCode(char.MaxValue, root));
                    int c_decimal = (int)c;
                    var c_binary = Convert.ToString(c_decimal, 2).Select(s => s.Equals('1')).ToList();
                    int c_binary_count = c_binary.Count;
                    for (int i = 0; i < 8 - c_binary_count; i++)
                    {
                        c_binary.Insert(0, false);
                    }
                    result.AddRange(c_binary);
                }

                Insert(c);
            }

            BitArray binaryData = new BitArray(result.ToArray());

            var outDataSize = (binaryData.Length / 8) + 1;
            byte[] outData = new byte[outDataSize];
            binaryData.CopyTo(outData, 0);

            outputStream.Write(outData, 0, outDataSize);
            return outDataSize;
        }

        private List<bool> GetCode(char s, AdaptiveHuffmanNode node, List<bool> code = null)
        {
            if (code == null)
                code = new List<bool>();

            if (node.left == null && node.right == null)
                return node.symbol == s ? code : new List<bool>();
            else
            {
                List<bool> temp = new List<bool>();
                if (node.left != null)
                {
                    var l = new List<bool>();
                    l.AddRange(code);
                    l.Add(false);
                    temp = GetCode(s, node.left, l);
                }
                if (temp.Count == 0 && node.right != null)
                {
                    var l = new List<bool>();
                    l.AddRange(code);
                    l.Add(true);
                    temp = GetCode(s, node.right, l);
                }
                return temp;
            }
        }

        private void Insert(char s)
        {
            AdaptiveHuffmanNode node = seen[s];

            if (node == null)
            {
                AdaptiveHuffmanNode spawn = new AdaptiveHuffmanNode() { symbol = s, weight = 1 };
                AdaptiveHuffmanNode internalNode = new AdaptiveHuffmanNode() { symbol = null, weight = 1, parent = NYT.parent, left = NYT, right = spawn };
                spawn.parent = internalNode;
                NYT.parent = internalNode;

                if (internalNode.parent != null)
                {
                    internalNode.parent.left = internalNode;
                }
                else
                {
                    root = internalNode;
                }

                nodes.Insert(0, internalNode);
                nodes.Insert(0, spawn);

                seen[s] = spawn;
                node = internalNode.parent;
            }
            while (node != null)
            {
                AdaptiveHuffmanNode largest = FindLargestNode(node.weight);

                if (node != largest && node != largest.parent && largest != node.parent)
                {
                    SwapNode(node, largest);
                }

                node.weight++;
                node = node.parent;

            }
        }

        private void SwapNode(AdaptiveHuffmanNode n1, AdaptiveHuffmanNode n2)
        {
            var i1 = nodes.IndexOf(n1);
            var i2 = nodes.IndexOf(n2);
            var temp = nodes[i1];
            nodes[i1] = nodes[i2];
            nodes[i2] = temp;

            var tmp_parent = n1.parent;
            n1.parent = n2.parent;
            n2.parent = tmp_parent;

            if (n1.parent.left == n2)
                n1.parent.left = n1;
            else
                n1.parent.right = n1;

            if (n2.parent.left == n1)
                n2.parent.left = n2;
            else
                n2.parent.right = n2;
        }

        private AdaptiveHuffmanNode FindLargestNode(int weight)
        {
            foreach (var item in nodes.Reverse<AdaptiveHuffmanNode>())
            {
                if (item.weight == weight)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
