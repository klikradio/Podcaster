using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Podcaster.Audio;
using Podcaster.Core;
using Podcaster.Controller;

namespace Podcaster.Business
{
    public static class CoreInstances
    {
        public static PodcasterConfiguration Cnfg;
        public static IDatabase Database;
        public static List<IController> Controllers;
        public static Dictionary<string, ICommand> Commands;

        public static void Initialize()
        {
            Cnfg = new PodcasterConfiguration();
            Database = Cnfg.ipd;
            Commands = Cnfg.commands;
            Controllers = Cnfg.Controllers;

            // Initialize the BASS recording library...
            if (!PodcasterRecording.RecordInit(Cnfg.Soundcard))
            {
                throw new Exception("Couldn't initialize recording");
            }
        }

        public static void OnExit()
        {
            // Turn off controllers...
            foreach (IController ic in Controllers)
            {
                ic.Close();
            }

            // Dispose of all commands...
            foreach (string cmdKey in Commands.Keys)
            {
                Commands[cmdKey].Dispose();
            }

            // Disable all audio stuff...
            PodcasterRecording.Free();
        }
    }
}
