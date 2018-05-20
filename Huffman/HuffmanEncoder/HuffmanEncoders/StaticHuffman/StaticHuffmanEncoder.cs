using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class StaticHuffmanEncoder
    {
        public StaticTree tree = new StaticTree();
        public MemoryStream data = new MemoryStream();
        public void Compress(Stream outStream, ref int outDataSize)
        {
            BitArray binaryData = tree.Encode(data.GetBuffer(), data.Length);

            outDataSize = (binaryData.Length / 8) + 1;
            byte[] outData = new byte[outDataSize];
            binaryData.CopyTo(outData, 0);

            outStream.Write(outData, 0, outDataSize);
        }

        public void PreProcessCompression(Stream InStream)
        {
            InStream.CopyTo(data);
            data.Capacity = (int)data.Length;
            tree.calculateFrequencies(data.GetBuffer(), data.Length);
            tree.BuildTree(data.GetBuffer(), data.Length);
            tree.BuildCodes();
        }

        public void SerializeHeader(Stream OutStream)
        {
            BinaryWriter writer = new BinaryWriter(OutStream);
            //writer.Write(header);
            tree.Serialize(OutStream);
        }

        //public void PreprocessDecompression(Stream InputStream)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Decompress(Stream OutputStream)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeserializeHeader(Stream InStream)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Decompress(Stream OutputStream, ref int outDataSize)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
