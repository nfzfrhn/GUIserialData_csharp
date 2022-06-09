using System;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace GrenzschichtGUI
{
    class ClassCommunication
    {
    	public bool test = false;       // When true, can be tested without U-Boot
        private System.IO.Ports.SerialPort Data_Port;
        private byte[] mByteFrame = new byte[80];			// Buffer to save data read from serial port
        private int mByteFrameIndex = 0;					// End position till where data is saved

        public bool mIsLivestreamInProgress = false;                    // End position till where data is saved


        // Für Communication mit Applcation
        public delegate void ResponseReceivedEventHandler(CmdId rspId, string TS, string X, string Y, string Z);
        public event ResponseReceivedEventHandler rspReceivedEventHandler;

		// Types of commands from GUI to U-Boot and U-Boot to GUI
        public enum CmdId
        {
            NONE,
            CNN,                // Connect
            DCNN,               // Disconnect
            RST,                // Clear Measurements stored in memory
            SETRSP,             // Set Parameter value
            GETRSP,             // Get Parameter value
            STARTLIVE,          // Start Livestream
            STOPLIVE,           // Stop Livestream
            DATA,               // Data packet from U-Boot containing values of Temp, Druck, Farbe, Licht
            END,                // Last packet after transfer of all measurement data
            MON,                // Monitoring packet used for test purpose
            CLR                 // Clear the settings values
        }

        private void SendData(string data)
        {
            SendPdu(string.Format("{0}\r\n", data));
        }
        
        /// <summary>
        /// Send request messages
        /// </summary>
        /// <param name="info"></param>
        // Function um Serial Port zu Schreiben
        private void SendPdu(string pdu)
        {
            if (!Data_Port.IsOpen)
            {
                return;
            }

            try
            {
                Data_Port.DiscardInBuffer();
            }
            catch (InvalidOperationException)
            {
                // Do nothing
            }
            catch (System.IO.IOException)
            {
                // Do nothing
            }

            try
            {
                Data_Port.Write(pdu);                   //Schickt connect-signal an microkontroller
            }
            catch (InvalidOperationException)
            {
                // Do nothing
            }
            catch (ArgumentNullException)
            {
                // Do nothing
            }
            catch (TimeoutException)
            {
                // Do nothing
            }
            catch(System.IO.IOException)
            {
                // Do nothing
            }
        }

        /// <summary>
        /// Connect to COM port.
        /// </summary>
        /// <param name="port_value">Com Port Nummer.</param>
        public void SendConnectReq(string port_value)
        {
            {
                Data_Port.PortName = port_value;              // Step 3
                //serialPort1.BaudRate = 9600;
                Data_Port.BaudRate = 256000;
                Data_Port.Parity = System.IO.Ports.Parity.None;
                Data_Port.DataBits = 8;
                Data_Port.StopBits = System.IO.Ports.StopBits.One;
                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceivedHandler);  // Incoming Data 

                try
                {
                    Data_Port.Open();                       //Port öffen         // Step 4         
                    //string command = "CNN";
                    //SendPdu(string.Format("{0}\r\n", command));
                    SendData("CNN");
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Cannot open COM port!");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("COM port Busy!");
                }

            }
        }

        // <summary>
        /// Disonnect COM port.
        /// </summary>
        /// <param name="port_value">Com Port Nummer.</param>
        public void SendDisconnectRequest()
        {
            if(mIsLivestreamInProgress)
			{
                SendData("STOPLIVE");
            }                

            if (Data_Port.IsOpen)
            {
                try
                {
                    Data_Port.Close();                       //Port Close
                }
                catch (System.IO.IOException)
                {
                    //MessageBox.Show("Cannot close COM port!");
                    //return;
                }
                catch (InvalidOperationException)
                {
                    //MessageBox.Show("COM port Busy!");
                }
            }
        }

      /// <summary>
        /// Reset the UBoot Measurements.
        /// </summary>
        public void SendResetReq()
        {
            if (test)
            {
                byte[] byteBuffer = Encoding.ASCII.GetBytes("RST_0\r\n");                               
                processReceivedData(byteBuffer.Length, byteBuffer);
            }
            else
            {
                SendData("RST");
            }
        }

        /// <summary>
        /// Reset the UBoot Setings.
        /// </summary>
        public void SendResetSettingsReq()
        {
            if (test)
            {
                byte[] byteBuffer = Encoding.ASCII.GetBytes("CLR_0\r\n");
                processReceivedData(byteBuffer.Length, byteBuffer);
            }
            else
            {
                SendData("CLR");
            }
        }
        /// <summary>
        /// Get Parameter/Settings from the UBoot.
        /// </summary>
        public void SendGetReq(string paraId)
        {
            string command = "GET";
            string pdu = string.Format("{0}_{1}\r\n", command, paraId);
            SendPdu(pdu);
        }

        /// <summary>
        /// Set Parameter/Settings to the UBoot.
        /// </summary>
        public void SendSetReq(string paraId, string val)
        {
            {
                string command = "SET";
                string pdu = string.Format("{0}_{1}{2}\r\n", command, paraId, val);
                SendPdu(pdu);
            }
        }


        /// <summary>
        /// Send StartLivestreamReq to the UBoot.
        /// </summary>
        public void SendSensorScanStartRequest()
        {
            mIsLivestreamInProgress = true;
            SendData("STARTLIVE");
        }

       /// <summary>
        /// Send StopLivestreamReq to the UBoot.
        /// </summary>
        public void SendSensorScanStopRequest()
        {
            SendData("STOPLIVE");
        }
       

        public void ReadSerialData()
        {
            if (Data_Port.IsOpen)
            {
                int intBuffer = Data_Port.BytesToRead;
                byte[] byteBuffer = new byte[intBuffer];

                Data_Port.Read(byteBuffer, 0, intBuffer);
                processReceivedData(intBuffer, byteBuffer);
            }
        }


        /// Process Port Data and seperate PDUs
        private void processReceivedData(int intBuffer, byte[] byteBuffer)
        {
            int i = 0;

            while (i < intBuffer)
            {
                if (byteBuffer[i] == '\n')                 // Wartet auf "\r\n"
                {
                    if ((i > 0) && (byteBuffer[i - 1] == '\r'))
                    {
                        string str1 = System.Text.Encoding.ASCII.GetString(mByteFrame);
                        string str2 = str1.Substring(0, mByteFrameIndex - 1);
                        processPdu(str2);
                    }
                    mByteFrameIndex = 0;
                }
                else
                {
                    if (mByteFrameIndex >= mByteFrame.Length)
                    {
                        mByteFrameIndex = 0;
                    }
                    mByteFrame[mByteFrameIndex++] = byteBuffer[i];
                }
                i++;
            }
        }

        private void processPdu(string pdu)
        {
            int indexUnterstrich;
            string header = string.Empty;
            string info = string.Empty;

            // Is PDU valid
            if ((indexUnterstrich = pdu.IndexOf('_')) != -1)
            {
                // Extract Header Part
                try
                {
                    header = pdu.Substring(0, indexUnterstrich);
                }
                catch (System.IO.IOException)
                {
                    return;
                }

                // Extract Info Part
                try
                {
                    info = pdu.Substring(indexUnterstrich + 1, pdu.Length - (indexUnterstrich + 1));
                }
                catch (System.IO.IOException)
                {
                    return;
                }
            }
            else
            {
                header = pdu;   // PDU END 
            }

            switch (header)
			{
                case "CNN":
                    processCNN(info);
                    break;

                case "RST":
                    processRST(info);
                    break;

                case "STAT":
                    processSTAT(info);
                    break;

                case "STOPLIVE":
                    processSTOPLIV(info);
                    break;

                //case 'T':
                default:
                    processSensorInfoPdu(pdu);              // Livestream
                    break;

			}            
        }


        private void processCNN(string info)
        {
            int errNo;
            bool res = int.TryParse(info, out errNo);

            if (res && (0 == errNo))
            {
                rspReceivedEventHandler(CmdId.CNN, null, null, null, null);
            }
            else
            {
                MessageBox.Show("CONNECTION Failed!");
            }
        }

        private void processRST(string info)
        {
            int errNo;
            bool res = int.TryParse(info, out errNo);

            if (res && (0 == errNo))
            {
                //MessageBox.Show("RESET Successful!");
                rspReceivedEventHandler(CmdId.RST, null, null, null, null);
            }
            else
            {
                MessageBox.Show("RESET Failed!");
            }
        }

        private void processCLR(string info)
        {
            int errNo;
            bool res = int.TryParse(info, out errNo);

            if (res && (0 == errNo))
            {
                MessageBox.Show("RESET Settings Successful!");
            }
            else
            {
                MessageBox.Show("RESET Settings Failed!");
            }
        }

        private void processSTAT(string info)
        {
            int indexUnterstrich;
            string paraId = string.Empty;
            string val = string.Empty;
            CmdId cmd;
            string rspVal = string.Empty;

            // Is PDU valid paraId 1 bytes + min 1 byte value
            if (info.Length < 2)
            {
                return;
            }

            if ((indexUnterstrich = info.IndexOf('_')) == -1)
            {
                cmd = CmdId.GETRSP;
            }
            else
            {
                cmd = CmdId.SETRSP;
                // Extract rspVal Part
                try
                {
                    rspVal = info.Substring(indexUnterstrich + 1, info.Length - (indexUnterstrich + 1));
                    info = info.Substring(0, indexUnterstrich);
                }
                catch (System.IO.IOException)
                {
                    // log exception
                }
            }

            // Extract paraId and val Part
            try
            {
                paraId = info.Substring(0, 1);
                val = info.Substring(1, info.Length - 1);
            }
            catch (System.IO.IOException)
            {
                // log exception
            }

            // Is GET/SET rsp 
            if (CmdId.GETRSP == cmd)
            {
                processGetRsp(paraId, val);
            }
            else
            {
                processSetRsp(paraId, val, rspVal);
            }
        }

        private void processSetRsp(string paraId, string val, string rsp)
        {
            // Is rsp value received is number?
            int rspValue;
            bool result;
            if ((result = int.TryParse(rsp, out rspValue)) == false)
                return;

            if (rspValue != 0)
            {
                MessageBox.Show("Setting Failed!");
            }

            rspReceivedEventHandler(CmdId.SETRSP, paraId, val, null, null);
        }

        private void processGetRsp(string paraId, string val)
        {            
            rspReceivedEventHandler(CmdId.GETRSP, paraId, val, null, null);
        }


        
        private void processSensorInfoPdu(string pdu)
        {
            int indexSpace;
            string timestamp = string.Empty;
            string info = string.Empty;

            if ((indexSpace = pdu.IndexOf(' ')) != -1)
            {
                // Extract Timestamp Part
                try
                {
                    timestamp = pdu.Substring(1, indexSpace - 1);
                }
                catch (System.IO.IOException)
                {
                    return;
                }

                // Extract Info Part
                try
                {
                    info = pdu.Substring(indexSpace + 1, pdu.Length - indexSpace - 1);
                    processInfo(timestamp, info);
                }
                catch (System.IO.IOException)
                {
                    return;
                }
            }

        }

       
        private void processKeyValuePair(string rest, string[] vallist, int count)
        {
            int indexSpaceID;
            //string valId = string.Empty;
            string val = string.Empty;
            int i = 0;
            int startIndex = 0;

            while ((i < count) && (rest.Length > 0))
            {        
                // Extract valID Part
                if ((indexSpaceID = rest.IndexOf(' ')) == -1)
                {
                    val = rest.Substring(0, rest.Length);
                }
				else
				{
					try
					{
						val = rest.Substring(0, indexSpaceID);
					}
					catch (System.IO.IOException)
					{
						// log exception
					}
				}
                
				float valN;
                bool res1 = float.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out valN);
                if (!res1)
                    return;
                vallist[i] = val;

                if (indexSpaceID == -1)
                    break;

                startIndex = indexSpaceID + 1;

                // Extract rest Part
                try
                {
                    rest = rest.Substring(startIndex, rest.Length - startIndex);
                }
                catch (System.IO.IOException)
                {
                    // log exception
                }

                i++;
            }
        }


        ////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        // Here starts the public functions         ////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        public ClassCommunication()
        {
            this.Data_Port = new System.IO.Ports.SerialPort();
        }

        public string[] GetPortNames()
        {
            string[] portList;

            try
            {
                portList = System.IO.Ports.SerialPort.GetPortNames();
                return portList;
            }
            catch(Win32Exception)
            {
                // Do Nothing
            }
            catch (System.IO.IOException)
            {
                // Do nothing
            }
            return null;
        }

        public void ClosePort()
        {
            if (!Data_Port.IsOpen)
            {
                return;
            }

            try
            {
                Data_Port.Close();
            }
            catch(IOException)
            {
                // Do nothing
            }
        }


        private void processSTOPLIV(string info)
        {
            int errNo;
            bool res = int.TryParse(info, out errNo);

            if (res && (0 == errNo))
            {
                //MessageBox.Show("Scan Stopped Successfully!");
                mIsLivestreamInProgress = false;
                // Send to UI
                rspReceivedEventHandler(CmdId.STOPLIVE, null, null, null, null);
            }
            else
            {
                MessageBox.Show("Scan Stop Failed!");
            }            
        }

        private void processInfo(string timestamp, string info)
        {
            string[] vallist = new string[3];

            processKeyValuePair(info, vallist, 3);

            // Send to UI
            rspReceivedEventHandler(CmdId.STARTLIVE, timestamp, vallist[0], vallist[1], vallist[2]);
        }

    }
}
