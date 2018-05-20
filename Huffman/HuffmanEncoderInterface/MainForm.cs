using Huffman;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Huffman
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is the main method. Everything starts here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCompressDialog(object sender, EventArgs e)
        {
            string[] filePaths;
            string currentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OpenFileDialog openDialog = new OpenFileDialog() { CheckFileExists = true, CheckPathExists = true, Multiselect = true, Title = "Select the file to compress", InitialDirectory = currentDirectory };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths = openDialog.FileNames;
            }
            else
            {
                return;
            }


            if (filePaths.Length > 0)
            {
                //Store results to show on a chart later
                List<Tuple<string, float>> staticCompressionRatio = new List<Tuple<string, float>>();
                List<Tuple<string, float>> staticTime = new List<Tuple<string, float>>();

                List<Tuple<string, float>> adaptiveCompressionRatio = new List<Tuple<string, float>>();
                List<Tuple<string, float>> adaptiveTime = new List<Tuple<string, float>>();

                //Run static and adaptive huffman for all the selected files.
                foreach (var filePath in filePaths)
                {
                    //Get filename to generate compressed files name(text.txt -> text)
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    //Generate filename for static comressed file
                    string savePath = fileNameWithoutExtension + ".huffmanStatic";
                    //Compress file with static huffman
                    var staticResult = CompressFileStatic(filePath, savePath);
                    //Generate filename for adaptive compressed file
                    savePath = Path.GetFileNameWithoutExtension(filePath) + ".huffmanAdaptive";
                    //Compress file with adaptive huffman
                    var adaptiveResult = CompressFileAdaptive(filePath, savePath);

                    //Add results to lists to show them on a chart
                    staticCompressionRatio.Add(new Tuple<string, float>(fileNameWithoutExtension, staticResult.Item1));
                    staticTime.Add(new Tuple<string, float>(fileNameWithoutExtension, staticResult.Item2));

                    adaptiveCompressionRatio.Add(new Tuple<string, float>(fileNameWithoutExtension, adaptiveResult.Item1));
                    adaptiveTime.Add(new Tuple<string, float>(fileNameWithoutExtension, adaptiveResult.Item2));
                }

                //Update charts
                UpdateCharts(chartRatio, true, staticCompressionRatio);
                UpdateCharts(chartRatio, false, adaptiveCompressionRatio);

                UpdateCharts(chartTime, true, staticTime);
                UpdateCharts(chartTime, false, adaptiveTime);

                MessageBox.Show("Done.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Please select at least one file to compress", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Compresses given file with static huffman algorithm
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="savePath">Path to save compressed file</param>
        /// <returns>Compression ratio and runtime of compression algorithm</returns>
        private Tuple<float, float> CompressFileStatic(string filePath, string savePath)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            float compressionRatio = 0f;
            using (FileStream inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputFileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                {
                    StaticHuffmanEncoder encoder = new StaticHuffmanEncoder();
                    encoder.PreProcessCompression(inputFileStream);
                    encoder.SerializeHeader(outputFileStream);
                    int compressedFileSize = 0;
                    encoder.Compress(outputFileStream, ref compressedFileSize);
                    Console.WriteLine(compressedFileSize);
                    long originalFileSize = inputFileStream.Length;
                    //compressionRatio = 100f - (compressedFileSize / (float)originalFileSize * 100f);
                    compressionRatio = (float)originalFileSize / compressedFileSize * 100f;
                }
            }
            timer.Stop();
            return new Tuple<float, float>(compressionRatio, timer.ElapsedMilliseconds);
        }
        /// <summary>
        /// Compresses given file with adaptive huffman algorithm
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="savePath">Path to save compressed file</param>
        /// <returns>Compression ratio and runtime of compression algorithm</returns>
        private Tuple<float,float> CompressFileAdaptive(string filePath, string savePath)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            float compressionRatio = 0f;
            using (FileStream inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputFileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                {
                    AdaptiveHuffmanEncoder encoder = new AdaptiveHuffmanEncoder();

                    int compressedFileSize = encoder.Encode(inputFileStream, outputFileStream);
                    Console.WriteLine(compressedFileSize);
                    long originalFileSize = inputFileStream.Length;
                    //compressionRatio = 100f - (compressedFileSize / (float)originalFileSize * 100f);
                    compressionRatio = (float)originalFileSize / compressedFileSize * 100f;
                }
            }
            timer.Stop();
            return new Tuple<float, float>(compressionRatio, timer.ElapsedMilliseconds);

        }

        private void UpdateCharts(Chart chart,bool isStatic,  List<Tuple<string,float>> values)
        { 
            string seriesName = isStatic ? "Static" : "Adaptive";
            foreach(var item in values)
            {
                chart.Series[seriesName].Points.AddXY(item.Item1, item.Item2);

            }
            chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        }
        

    }
}
