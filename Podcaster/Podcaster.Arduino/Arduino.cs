using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

using Podcaster.Core;

namespace Podcaster.ArduinoController
{
    public class Arduino : IController
    {
        private SerialPort sp;
        private string COMPort;
        private int BaudRate;
        private string PartialString = "";

        public event PauseRecording OnPause;
        public event ResumeRecording OnResume;
        public event LogSong OnLogSong;

        public void Start()
        {
            sp = new SerialPort(COMPort, BaudRate);
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);

            sp.Open();
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            PartialString += sp.ReadExisting();
            if (PartialString.Length > 1)
            {
                PartialString = PartialString.Substring(PartialString.Length - 1);
            }

            if (PartialString == "1")
            {
                if (OnResume != null)
                {
                    OnResume();
                }
                PartialString = "";
            }
            else if (PartialString == "0")
            {
                if (OnPause != null)
                {
                    OnPause();
                }
                PartialString = "";
            }
        }

        public void SetParameter(string key, string value)
        {
            if (key.Equals("comport"))
            {
                COMPort = value;
            }
            else if (key.Equals("baudrate"))
            {
                BaudRate = Convert.ToInt32(value);
            }
        }

        public void Close()
        {
            sp.Close();
        }
    }
}
