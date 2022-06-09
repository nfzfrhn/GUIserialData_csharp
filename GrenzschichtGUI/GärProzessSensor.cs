using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrenzschichtGUI
{    
    public partial class txtConnect : Form
    {
        // Private memebers
        string mFilePath = string.Empty;                    // Download file path
        int mFileIndex;        
        private ClassCommunication mComm;
        UInt64 mTimestamp;
        static UInt16 N = 256;                                     // Length of FFT
        UInt16 n_fft = 0;                                   // index of N
        static UInt32 sampleTime = 26667;
        static UInt32 Fmax = 1/(sampleTime*2);


        Complex[] x_t_val = new Complex[N];
        Complex[] y_t_val = new Complex[N];
        Complex[] z_t_val = new Complex[N];


        public txtConnect()
        {
            InitializeComponent();
            mComm = new ClassCommunication();
            mComm.rspReceivedEventHandler += new ClassCommunication.ResponseReceivedEventHandler(RspReceivedHandler);

            // X_OFS_USR (73h) Y_OFS_USR (74h) Z_OFS_USR (75h)
            // Accelerometer n-axis user offset calibration expressed in 2’s complement, weight depends on
            // USR_OFF_W in CTRL6_C(15h).The value must be in the range[-127, +127].

            int count;
			for (count = -127; count <= 127; count++)
			{
				this.comboBoxXOffset.Items.Add(Convert.ToString(count));
                this.comboBoxYoffset.Items.Add(Convert.ToString(count));
                this.comboBoxZoffset.Items.Add(Convert.ToString(count));
            }
		}

        // Callback for Handling evnts from class Communication
        private void RspReceivedHandler(ClassCommunication.CmdId mCmd, string TS, string X, string Y, string Z)
        {
            switch (mCmd)
            {
                case ClassCommunication.CmdId.CNN:
                    {
                        if (labConnection.Text.Equals("Disconnected"))
						{
                            Invoke(new Action(() => labConnection.Text = "Connected"));
                            Invoke(new Action(() => buttonConnect.Text = "Disconnect"));
                            picStatusConnect.BackColor = System.Drawing.Color.Green;
                            Invoke(new Action(() => this.chartAccelerationTime.Visible = true));
                            mTimestamp = Convert.ToUInt64(TS);
                            CreateCsvFile();
                            /*mComm.SendGetReq("F");
                            
                            mComm.SendGetReq("X");
                            mComm.SendGetReq("Y");
                            mComm.SendGetReq("Z");*/
                        }
                    }
                    break;

                case ClassCommunication.CmdId.DCNN:                                         
                    {
                        if (labConnection.Text.Equals("Connected"))
                        {
                            mComm.ClosePort();
                            Invoke(new Action(() => labConnection.Text = "Disconnected"));
                            Invoke(new Action(() => buttonConnect.Text = "Connect"));
                            //clearTntensityTimeGraph();
                            picStatusConnect.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    break;

                case ClassCommunication.CmdId.STARTLIVE:                                         
                    {
                        //Invoke(new Action(() => labIntegTimeVerif.Text = "New Integration Time wíll be now used!"));
                        processPdu(TS, X, Y, Z);
                    }
                    break;

                case ClassCommunication.CmdId.SETRSP:
					{
                        ReceivedSetValue(TS, X);
                    }
                    break;

                case ClassCommunication.CmdId.GETRSP:
                    {
                        ReceivedGetValue(TS, X);
                    }
                    break;

            }
        }

        public void ReceivedSetValue(string id, string value)
        {
            bool result = false;

            switch (id)
            {
                // LPF2 Setting Selects accelerometer high-resolution.
                // 0: output from first stage digital filtering selected(default);
                // 1: output from LPF2 second filtering stage selected)
                case "F":
                    //Invoke(new Action(() => comboBoxLPF2.Text = value));
                    //if (comboBoxLPF2.Text == value)
                    if (comboBoxLPF2.SelectedIndex == Convert.ToInt16(value))
                    {
                        result = true;
                     }
                     break;

                case "X":
                    //Invoke(new Action(() => comboBoxXOffset.Text = value));
                    if (comboBoxXOffset.Text == value)
                    {
                        result = true;
                    }
                    break;

                case "Y":
                    //Invoke(new Action(() => comboBoxYoffset.Text = value));
                    if (comboBoxYoffset.Text == value)
                    {
                        result = true;
                    }
                    break;

                case "Z":
                    //Invoke(new Action(() => comboBoxZoffset.Text = value));
                    if (comboBoxZoffset.Text == value)
                    {
                        result = true;
                    }
                    break;                

                default:
                    break;
            }

            if(result)
                MessageBox.Show("Setting Successful!");
            else
                MessageBox.Show("Setting Failed!");       
        }

        public void ReceivedGetValue(string id, string value)
        {
            
                switch (id)
                {
                    case "F":
                    //Invoke(new Action(() => comboBoxLPF2.Text = value));
                    int index = Convert.ToInt16(value);
                    if(comboBoxLPF2.SelectedIndex != index)
                        comboBoxLPF2.SelectedIndex = index;
                    //Invoke(new Action(() => (comboBoxLPF2.SelectedIndex = index)));
                    break;

                    case "X":
                        if(comboBoxXOffset.Text != value)
                            Invoke(new Action(() => comboBoxXOffset.Text = value));
                        break;

                    case "Y":
                        if (comboBoxYoffset.Text != value)
                            Invoke(new Action(() => comboBoxYoffset.Text = value));
                        break;

                    case "Z":
                        if (comboBoxZoffset.Text != value)
                            Invoke(new Action(() => comboBoxZoffset.Text = value));
                        break;

                    default:
                        break;
                }

                //int count;

                //if (getParaIdFromLabel(out count))
                //{
                //    if (setting[count].precision == "bool")
                //    {
                //        if (value == "1")
                //            value = "Yes";
                //        else if (value == "0")
                //            value = "No";
                //    }
                //}

                //Invoke(new Action(() => labelCurrentValueDisplay.Text = value));            
        }

        private bool isValIdValid(string valId)
        {
            switch (valId)
            {
                case "F":
                case "X":
                case "Y":
                case "Z":
                    return true;

                default:
                    return false;
            }
        }

        private void txtConnect_FormClosing(object sender, EventArgs e)
        {
            if (labConnection.Text.Equals("Connected"))
            {
                mComm.SendDisconnectRequest();
                //mComm.ClosePort();
            }
        }
                     
        /********************** Serial Port Functions *******************************************/
        private void butConnect_Click(object sender, EventArgs e)
        {          
            string portName = Port_comboBox.Text;

            if ((labConnection.Text.Equals("Disconnected")) && (portName.Any()))
            { 
                mComm.SendConnectReq(portName);
                timerPeriode.Enabled = true;
                timerPeriode.Interval = 20;
            }
            else if(labConnection.Text.Equals("Connected"))
            {
                HandleDisconnect();
                Invoke(new Action(() => labConnection.Text = "Disconnected"));
                Invoke(new Action(() => buttonConnect.Text = "Connect"));
                Invoke(new Action(() => picStatusConnect.BackColor = System.Drawing.Color.Red));
            }          
        }

        private void HandleDisconnect()
        {            
            timerPeriode.Enabled = false;

            //clearTntensityTimeGraph();
            mComm.SendDisconnectRequest();
        }
       
        private void PortCombobox_Click(object sender, EventArgs e)
        {
            Port_comboBox.DataSource = mComm.GetPortNames();
        }


        private void processPdu(string TS, string X, string Y, string Z)
        {
            UpdateIntensityGraphValues((System.Convert.ToUInt64(TS)- mTimestamp), System.Convert.ToInt32(X), System.Convert.ToInt32(Y), System.Convert.ToInt32(Z));
            Complex x_val_complex = System.Convert.ToInt32(X);
            Complex y_val_complex = System.Convert.ToInt32(Y);
            Complex z_val_complex = System.Convert.ToInt32(Z);
            x_t_val[n_fft] = x_val_complex;
            y_t_val[n_fft] = y_val_complex;
            z_t_val[n_fft] = z_val_complex;
            n_fft++;                                                //todo
            if (n_fft == N)
            {
                UpdateFFT_GraphValue(x_t_val, y_t_val, z_t_val);
                n_fft = 0;
            }
            WriteToCsvFile(TS, X, Y, Z);                                                           
        }


        private void UpdateIntensityGraphValues(UInt64 TS, int X, int Y, int Z)
        {
            int i = 0;
            Invoke(new Action(() => chartAccelerationTime.Series["X"].Points.AddXY(
                             TS,                // X value is a date
                             X)));
            Invoke(new Action(() => chartAccelerationTime.Series["Y"].Points.AddXY(
                             TS,                // X value is a date
                             Y)));
            Invoke(new Action(() => chartAccelerationTime.Series["Z"].Points.AddXY(
                              TS,                // X value is a date
                              Z)));

            if (chartAccelerationTime.Series["X"].Points.Count > 500)
            {
                Invoke(new Action(() => chartAccelerationTime.Series["X"].Points.RemoveAt(0)));
            }

            if (chartAccelerationTime.Series["Y"].Points.Count > 500)
            {
                Invoke(new Action(() => chartAccelerationTime.Series["Y"].Points.RemoveAt(0)));
            }

            if (chartAccelerationTime.Series["Z"].Points.Count > 500)
            {
                Invoke(new Action(() => chartAccelerationTime.Series["Z"].Points.RemoveAt(0)));
            }
        }

        private void UpdateFFT_GraphValue(Complex[] xf, Complex[] yf, Complex[] zf) {

            Fourier.Forward(xf);
            Fourier.Forward(yf);
            Fourier.Forward(zf);            

            for (int i = 0; i < xf.Length; i++){
                Invoke(new Action(() => FFT_Visual.Series["X"].Points.AddXY((i * Fmax * 2 / N) + 1, xf[i].Magnitude)));
                Invoke(new Action(() => FFT_Visual.Series["Y"].Points.AddXY((i * Fmax * 2 / N) + 1, yf[i].Magnitude)));
                Invoke(new Action(() => FFT_Visual.Series["Z"].Points.AddXY((i * Fmax * 2 / N) + 1, zf[i].Magnitude)));
            }


        }
        /********************** Time Periode Functions *******************************************/


        //private void butConnect_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, buttonConnect.ClientRectangle,
        //    SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
        //    SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
        //    SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
        //    SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        //}
                
        /********************** CSV File Access Functions *******************************************/
        private void CreateCsvFile()
        {  
            var time = DateTime.Now;
            string formattedTime = time.ToString("yyyy,MM,dd_hh,mm,ss");
            //string fileName = "GUImessungen_" + formattedTime + ".csv";
            string fileName = "GUImessungen" + ".csv";

            mFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\" + fileName;
                            
            {         
                try
                {
                    // using (System.IO.StreamWriter mCsv = new System.IO.StreamWriter(mFilePath, false))
                    using (System.IO.StreamWriter mCsv = new System.IO.StreamWriter(mFilePath, true))
                    {
                        mCsv.Flush();
                        mFileIndex = 0;
                        var line = string.Empty;

                        line = string.Format("{0};{1}", Environment.NewLine, formattedTime);
                        mCsv.WriteLine(line);

                        if (!File.Exists(mFilePath))
                        {
                            line = string.Format("{0};{1};{2};{3};{4}",
                                                     //+";{29}",                                                
                                                     ////Environment.NewLine,
                                                     "Serial Nummer",
                                                     "Timestamp",
                                                     "X", "Y", "Z",                                                
                                                     Environment.NewLine);
                            mCsv.WriteLine(line);
                        }
                        
                    }
                }
                catch (System.IO.IOException)
                {
                    // log exception
                    MessageBox.Show("File Open Failed");
                }
            }
        }

        private void WriteToCsvFile(string TS, string X, string Y, string Z)
        {
            if (mFilePath == string.Empty)
                return;
            try
            {
                using (var w = new System.IO.StreamWriter(mFilePath, true))
                {
                    mFileIndex++;

                    var line = string.Format("{0};{1};{2};{3};{4}", mFileIndex, TS, X, Y, Z);
                    w.WriteLine(line);
                    w.Flush();
                }
            }
            catch
            {
                MessageBox.Show("Writing to .csv file failed!");
            }

        }

        private void clearTntensityTimeGraph()
        {
            chartAccelerationTime.Series["X"].Points.Clear(); //Removes all points like it should.
            chartAccelerationTime.Series["Y"].Points.Clear(); //Removes all points like it should.
            chartAccelerationTime.Series["Z"].Points.Clear(); //Removes all points like it should.          
        }

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
            clearTntensityTimeGraph();
        }

		private void timerPeriode_Tick(object sender, EventArgs e)
		{
            mComm.ReadSerialData();
        }


		private void comboBoxLPF2_SelectedIndexChanged(object sender, EventArgs e)
		{
            //mComm.SendSetReq("F", comboBoxLPF2.Text);
            mComm.SendSetReq("F", Convert.ToString(comboBoxLPF2.SelectedIndex));
            
        }

		private void comboBoxYoffset_SelectedIndexChanged(object sender, EventArgs e)
		{
            mComm.SendSetReq("Y", comboBoxYoffset.Text);
            
        }

        private void comboBoxXOffset_SelectedIndexChanged(object sender, EventArgs e)
		{
            mComm.SendSetReq("X", comboBoxXOffset.Text);
            
        }

		private void comboBoxZoffset_SelectedIndexChanged(object sender, EventArgs e)
		{
            mComm.SendSetReq("Z", comboBoxZoffset.Text);
            
        }

		private void checkBoxScan_CheckedChanged(object sender, EventArgs e)
		{
            //if (this.checkBoxScan.Checked)
            if(mComm.mIsLivestreamInProgress)
			{
                mComm.SendSensorScanStopRequest();
            }               
            else
			{
                mComm.SendSensorScanStartRequest();
            }               
        }

        private void buttonConnect_CheckedChanged(object sender, EventArgs e)
		{

		}


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chartAccelerationTime_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void picStatusConnect_Click(object sender, EventArgs e)
        {

        }
    }
}


