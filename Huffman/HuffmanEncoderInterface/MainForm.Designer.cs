namespace Huffman
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chartRatio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTime)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(886, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Files and Compress";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowCompressDialog);
            // 
            // chartRatio
            // 
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.Title = "asd";
            chartArea3.AxisX2.LineColor = System.Drawing.Color.Gold;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.Blue;
            chartArea3.BorderColor = System.Drawing.Color.DarkGray;
            chartArea3.Name = "ChartArea1";
            this.chartRatio.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartRatio.Legends.Add(legend3);
            this.chartRatio.Location = new System.Drawing.Point(12, 80);
            this.chartRatio.Name = "chartRatio";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Static";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Adaptive";
            this.chartRatio.Series.Add(series5);
            this.chartRatio.Series.Add(series6);
            this.chartRatio.Size = new System.Drawing.Size(886, 203);
            this.chartRatio.TabIndex = 1;
            this.chartRatio.Text = "asdsadasd";
            title2.DockedToChartArea = "ChartArea1";
            title2.Name = "Title1";
            this.chartRatio.Titles.Add(title2);
            // 
            // chartTime
            // 
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisX2.LineColor = System.Drawing.Color.Gold;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisY2.LineColor = System.Drawing.Color.Blue;
            chartArea4.BorderColor = System.Drawing.Color.DarkGray;
            chartArea4.Name = "ChartArea1";
            this.chartTime.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartTime.Legends.Add(legend4);
            this.chartTime.Location = new System.Drawing.Point(12, 318);
            this.chartTime.Name = "chartTime";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Static";
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Adaptive";
            this.chartTime.Series.Add(series7);
            this.chartTime.Series.Add(series8);
            this.chartTime.Size = new System.Drawing.Size(886, 203);
            this.chartTime.TabIndex = 1;
            this.chartTime.Text = "ASDASD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(333, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Compression Ratio (%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(375, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Runtime (ms)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 531);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartTime);
            this.Controls.Add(this.chartRatio);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Huffman Encoder";
            ((System.ComponentModel.ISupportInitialize)(this.chartRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRatio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

