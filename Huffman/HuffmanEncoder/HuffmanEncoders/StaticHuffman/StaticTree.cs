using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class StaticTree
    {
        public List<StaticHuffmanNode> huffmanTreeList = new List<StaticHuffmanNode>();
        public Dictionary<char, List<bool>> huffmanCodes = new Dictionary<char, List<bool>>();
        public List<StaticHuffmanNode> frequencyTable = new List<StaticHuffmanNode>();

        public void Serialize(Stream outStream)
        {
            BinaryWriter writer = new BinaryWriter(outStream);
            writer.Write(frequencyTable.Count);
            foreach (var entry in frequencyTable)
            {
                writer.Write(entry.name.Value);
                writer.Write(entry.frequency);
            }
            writer.Flush();
        }
        public void BuildTree(byte[] data, long dataSize)
        {
            huffmanTreeList.Clear();
            foreach (var entry in frequencyTable)
            {
                huffmanTreeList.Add(entry);
            }
            while (huffmanTreeList.Count > 1)
            {
                huffmanTreeList = huffmanTreeList.OrderBy(Node => Node.frequency).ToList();

                var Node1 = huffmanTreeList.ElementAt(0);
                var Node2 = huffmanTreeList.ElementAt(1);
                var parent = new StaticHuffmanNode { name = null, frequency = Node1.frequency + Node2.frequency, left = Node1, right = Node2 };
                Node1.parent = parent;
                Node2.parent = parent;
                huffmanTreeList.RemoveRange(0, 2);
                huffmanTreeList.Insert(0, parent);
            }
        }
        public void calculateFrequencies(byte[] data, long dataSize)
        {
            for (long i = 0; i < dataSize; i++)
            {
                char nodeName = (char)data[i];

                var treeNode = frequencyTable.Find(node => node.name == nodeName);
                if (treeNode != null)
                {
                    treeNode.frequency++;
                }
                else
                {
                    frequencyTable.Add(new StaticHuffmanNode { name = nodeName, frequency = 1 });
                }
            }
        }
        public void BuildCodes(StaticHuffmanNode thisNode = null)
        {
            if (thisNode == null)
            {
                thisNode = huffmanTreeList.ElementAt(0);
            }
            StaticHuffmanNode leftNode = thisNode.left;
            StaticHuffmanNode rightNode = thisNode.right;

            if (leftNode == null && rightNode == null)
            {
                thisNode.binaryCode = new List<bool>() { true };
                huffmanCodes[(char)thisNode.name] = new List<bool>() { true };
            }
            if (thisNode.parent == null)//Root ise
            {
                if (leftNode != null)
                {
                    leftNode.binaryCode = new List<bool>() { false };
                }

                if (rightNode != null)
                {
                    rightNode.binaryCode = new List<bool>() { true };
                }
            }
            else
            {
                if (leftNode != null)
                {
                    leftNode.binaryCode = new List<bool>();
                    leftNode.binaryCode.AddRange(thisNode.binaryCode);
                    leftNode.binaryCode.Add(false);
                }

                if (rightNode != null)
                {
                    rightNode.binaryCode = new List<bool>();
                    rightNode.binaryCode.AddRange(thisNode.binaryCode);
                    rightNode.binaryCode.Add(true);
                }
            }

            if (leftNode != null)
            {
                if (!leftNode.isLeaf)
                {
                    BuildCodes(leftNode);
                }
                else
                {
                    huffmanCodes.Add((char)leftNode.name, leftNode.binaryCode);
                }
            }

            if (rightNode != null)
            {
                if (!rightNode.isLeaf)
                {
                    BuildCodes(rightNode);
                }
                else
                {
                    huffmanCodes.Add((char)rightNode.name, rightNode.binaryCode);
                }
            }
        }
        public BitArray Encode(byte[] data, long dataSize)
        {
            if (dataSize != 0 && data != null)
            {
                List<bool> encoded = new List<bool>();
                encoded.AddRange(data.SelectMany(character => huffmanCodes[(char)character]));
                return new BitArray(encoded.ToArray());
            }
            else
            {
                return null;
            }
        }
    }
}
