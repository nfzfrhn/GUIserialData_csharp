namespace GrenzschichtGUI
{
    partial class txtConnect
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.picStatusConnect = new System.Windows.Forms.PictureBox();
            this.labIntegTimeVerif = new System.Windows.Forms.Label();
            this.timerPeriode = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.Port_comboBox = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.CheckBox();
            this.chartAccelerationTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FFT_Visual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxZoffset = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labConnection = new System.Windows.Forms.Label();
            this.comboBoxYoffset = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxXOffset = new System.Windows.Forms.ComboBox();
            this.comboBoxLPF2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxScan = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccelerationTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FFT_Visual)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picStatusConnect
            // 
            this.picStatusConnect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picStatusConnect.BackColor = System.Drawing.Color.Red;
            this.picStatusConnect.Location = new System.Drawing.Point(11, 16);
            this.picStatusConnect.Name = "picStatusConnect";
            this.picStatusConnect.Size = new System.Drawing.Size(22, 24);
            this.picStatusConnect.TabIndex = 3;
            this.picStatusConnect.TabStop = false;
            this.picStatusConnect.Click += new System.EventHandler(this.picStatusConnect_Click);
            // 
            // labIntegTimeVerif
            // 
            this.labIntegTimeVerif.AutoSize = true;
            this.labIntegTimeVerif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIntegTimeVerif.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labIntegTimeVerif.Location = new System.Drawing.Point(375, 69);
            this.labIntegTimeVerif.Name = "labIntegTimeVerif";
            this.labIntegTimeVerif.Size = new System.Drawing.Size(80, 18);
            this.labIntegTimeVerif.TabIndex = 89;
            this.labIntegTimeVerif.Text = "Message!";
            this.labIntegTimeVerif.Visible = false;
            // 
            // timerPeriode
            // 
            this.timerPeriode.Interval = 1000;
            this.timerPeriode.Tick += new System.EventHandler(this.timerPeriode_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Select Port Number";
            // 
            // Port_comboBox
            // 
            this.Port_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_comboBox.FormattingEnabled = true;
            this.Port_comboBox.Location = new System.Drawing.Point(112, 11);
            this.Port_comboBox.Name = "Port_comboBox";
            this.Port_comboBox.Size = new System.Drawing.Size(66, 23);
            this.Port_comboBox.TabIndex = 95;
            this.Port_comboBox.DropDown += new System.EventHandler(this.PortCombobox_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.FlatAppearance.BorderSize = 0;
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(204, 11);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(57, 23);
            this.buttonConnect.TabIndex = 97;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.CheckedChanged += new System.EventHandler(this.buttonConnect_CheckedChanged);
            this.buttonConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // chartAccelerationTime
            // 
            this.chartAccelerationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartAccelerationTime.BackColor = System.Drawing.SystemColors.Control;
            this.chartAccelerationTime.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.chartAccelerationTime.BorderSkin.BorderColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisX.Title = "Time (centiSeconds)";
            chartArea1.AxisY.Title = "Values (mg)";
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 77.68596F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            this.chartAccelerationTime.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chartAccelerationTime.Legends.Add(legend1);
            this.chartAccelerationTime.Location = new System.Drawing.Point(10, 19);
            this.chartAccelerationTime.Name = "chartAccelerationTime";
            this.chartAccelerationTime.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartAccelerationTime.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Lime,
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "X";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Y";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Z";
            this.chartAccelerationTime.Series.Add(series1);
            this.chartAccelerationTime.Series.Add(series2);
            this.chartAccelerationTime.Series.Add(series3);
            this.chartAccelerationTime.Size = new System.Drawing.Size(573, 236);
            this.chartAccelerationTime.TabIndex = 99;
            this.chartAccelerationTime.Text = "chart1";
            this.chartAccelerationTime.Click += new System.EventHandler(this.chartAccelerationTime_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FFT_Visual);
            this.groupBox1.Controls.Add(this.chartAccelerationTime);
            this.groupBox1.Location = new System.Drawing.Point(5, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 511);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphical View";
            // 
            // FFT_Visual
            // 
            this.FFT_Visual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FFT_Visual.BackColor = System.Drawing.SystemColors.Control;
            this.FFT_Visual.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.FFT_Visual.BorderSkin.BorderColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.Minimum = 1D;
            chartArea2.AxisX.Title = "Time (centiSeconds)";
            chartArea2.AxisY.Title = "Values (mg)";
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 77.68596F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 3F;
            this.FFT_Visual.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            this.FFT_Visual.Legends.Add(legend2);
            this.FFT_Visual.Location = new System.Drawing.Point(5, 261);
            this.FFT_Visual.Name = "FFT_Visual";
            this.FFT_Visual.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.FFT_Visual.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Lime,
        System.Drawing.Color.Blue};
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "X";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.Name = "Y";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsXValueIndexed = true;
            series6.Legend = "Legend1";
            series6.Name = "Z";
            this.FFT_Visual.Series.Add(series4);
            this.FFT_Visual.Series.Add(series5);
            this.FFT_Visual.Series.Add(series6);
            this.FFT_Visual.Size = new System.Drawing.Size(573, 236);
            this.FFT_Visual.TabIndex = 100;
            this.FFT_Visual.Text = "chart2";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.comboBoxZoffset);
            this.groupBox5.Controls.Add(this.labIntegTimeVerif);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.buttonConnect);
            this.groupBox5.Controls.Add(this.comboBoxYoffset);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.Port_comboBox);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.comboBoxXOffset);
            this.groupBox5.Controls.Add(this.comboBoxLPF2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.checkBoxScan);
            this.groupBox5.Location = new System.Drawing.Point(5, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(589, 104);
            this.groupBox5.TabIndex = 105;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connection";
            // 
            // comboBoxZoffset
            // 
            this.comboBoxZoffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxZoffset.FormattingEnabled = true;
            this.comboBoxZoffset.Location = new System.Drawing.Point(284, 69);
            this.comboBoxZoffset.Name = "comboBoxZoffset";
            this.comboBoxZoffset.Size = new System.Drawing.Size(66, 23);
            this.comboBoxZoffset.TabIndex = 113;
            this.comboBoxZoffset.SelectedIndexChanged += new System.EventHandler(this.comboBoxZoffset_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Select Z Offset";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.picStatusConnect);
            this.groupBox2.Controls.Add(this.labConnection);
            this.groupBox2.Location = new System.Drawing.Point(460, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(116, 50);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // labConnection
            // 
            this.labConnection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labConnection.AutoSize = true;
            this.labConnection.BackColor = System.Drawing.SystemColors.Control;
            this.labConnection.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConnection.Location = new System.Drawing.Point(38, 21);
            this.labConnection.Name = "labConnection";
            this.labConnection.Size = new System.Drawing.Size(73, 13);
            this.labConnection.TabIndex = 64;
            this.labConnection.Text = "Disconnected";
            this.labConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxYoffset
            // 
            this.comboBoxYoffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYoffset.FormattingEnabled = true;
            this.comboBoxYoffset.Location = new System.Drawing.Point(112, 69);
            this.comboBoxYoffset.Name = "comboBoxYoffset";
            this.comboBoxYoffset.Size = new System.Drawing.Size(66, 23);
            this.comboBoxYoffset.TabIndex = 111;
            this.comboBoxYoffset.SelectedIndexChanged += new System.EventHandler(this.comboBoxYoffset_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Select Y Offset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Select X Offset";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxXOffset
            // 
            this.comboBoxXOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxXOffset.FormattingEnabled = true;
            this.comboBoxXOffset.Location = new System.Drawing.Point(284, 40);
            this.comboBoxXOffset.Name = "comboBoxXOffset";
            this.comboBoxXOffset.Size = new System.Drawing.Size(66, 23);
            this.comboBoxXOffset.TabIndex = 108;
            this.comboBoxXOffset.SelectedIndexChanged += new System.EventHandler(this.comboBoxXOffset_SelectedIndexChanged);
            // 
            // comboBoxLPF2
            // 
            this.comboBoxLPF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLPF2.FormattingEnabled = true;
            this.comboBoxLPF2.Items.AddRange(new object[] {
            "Disabled",
            "ODR/4",
            "ODR/10",
            "ODR/20",
            "ODR/45",
            "ODR/100",
            "ODR/200",
            "ODR/400",
            "ODR/800"});
            this.comboBoxLPF2.Location = new System.Drawing.Point(112, 40);
            this.comboBoxLPF2.Name = "comboBoxLPF2";
            this.comboBoxLPF2.Size = new System.Drawing.Size(66, 23);
            this.comboBoxLPF2.TabIndex = 107;
            this.comboBoxLPF2.SelectedIndexChanged += new System.EventHandler(this.comboBoxLPF2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "Select LPF2 Setting";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBoxScan
            // 
            this.checkBoxScan.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxScan.AutoSize = true;
            this.checkBoxScan.FlatAppearance.BorderSize = 0;
            this.checkBoxScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxScan.Location = new System.Drawing.Point(281, 11);
            this.checkBoxScan.Name = "checkBoxScan";
            this.checkBoxScan.Size = new System.Drawing.Size(42, 23);
            this.checkBoxScan.TabIndex = 106;
            this.checkBoxScan.Text = "Scan";
            this.checkBoxScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxScan.UseVisualStyleBackColor = true;
            this.checkBoxScan.CheckedChanged += new System.EventHandler(this.checkBoxScan_CheckedChanged);
            // 
            // txtConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(604, 629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "txtConnect";
            this.Text = "GärProzessSensor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.txtConnect_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picStatusConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccelerationTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FFT_Visual)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picStatusConnect;
        //private System.IO.Ports.SerialPort Data_Port;
        private System.Windows.Forms.Label labIntegTimeVerif;
        private System.Windows.Forms.Timer timerPeriode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Port_comboBox;
        private System.Windows.Forms.CheckBox buttonConnect;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAccelerationTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labConnection;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxXOffset;
		private System.Windows.Forms.ComboBox comboBoxLPF2;
		private System.Windows.Forms.CheckBox checkBoxScan;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxZoffset;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxYoffset;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart FFT_Visual;
    }
}

