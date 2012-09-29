using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
namespace KLIK.AudioDevices
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (BASS_DEVICEINFO bi in Bass.BASS_RecordGetDeviceInfos())
            {
                Console.WriteLine(bi.ToString() + " - Default? " + bi.IsDefault.ToString());
            }
        }
    }
}
