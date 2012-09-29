using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

using Podcaster.Business;
using Podcaster.Core;
using Podcaster.Utilities;

namespace Podcaster
{
    public static class Program
    {
        static Mutex mutex = new Mutex(true, "Podcaster");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    CoreInstances.Initialize();
                }
                catch (Exception ex)
                {
                    PodcasterUtilities.KLIKException(ex);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("The Podcaster is already running.");
            }
        }

        /// <summary>
        /// Application exiting routines
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                CoreInstances.OnExit();
            }
            catch (Exception)
            {
            }
        }
    }
}
