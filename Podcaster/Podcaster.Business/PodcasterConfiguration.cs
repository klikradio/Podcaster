using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Podcaster.Core;

namespace Podcaster.Business
{
    /// <summary>
    /// Configuration class contains all the info needed to configure the Podcaster
    /// </summary>
    [Serializable]
    public class PodcasterConfiguration
    {
        public const string TMP_PATH = "\\podcaster.tmp";
        public const string DEFAULT_PATH = "caster.xml";

        #region Public Variables
        /// <summary>
        /// The file that contains the full show (including music)
        /// </summary>
        public readonly string FullShow;
        /// <summary>
        /// The file that contains the edited show (no music)
        /// </summary>
        public readonly string EditedShow;
        /// <summary>
        /// The file that contains the XML data of the songs played during the show.
        /// </summary>
        public readonly string TitleStream;
        /// <summary>
        /// Name of the soundcard to use
        /// </summary>
        public readonly string Soundcard;
        /// <summary>
        /// The host name of the FTP server edited files are hosted on
        /// </summary>
        public readonly string PodcastFTPHost;
        /// <summary>
        /// The username of the FTP server edited files are hosted on
        /// </summary>
        public readonly string PodcastFTPUsername;
        /// <summary>
        /// The password of the FTP server edited files are hosted on
        /// </summary>
        public readonly string PodcastFTPPassword;
        /// <summary>
        /// The directory of the FTP server edited files are hosted on
        /// </summary>
        public readonly string PodcastFTPDirectory;
        /// <summary>
        /// Number of seconds of mouse activity before app reminds user to start a show.
        /// </summary>
        public readonly int ActivityTimer;
        /// <summary>
        /// Number of seconds of mouse inactivity before app reminds user to stop a show.
        /// </summary>
        public readonly int InactivityTimer;
        /// <summary>
        /// List of servers
        /// </summary>
        public readonly List<StreamingServer> Servers;
        /// <summary>
        /// Show names to ignore (i.e. standard temporary/test show names, or reserved time slots)
        /// </summary>
        public readonly List<string> IgnoredShows;
        /// <summary>
        /// Returns the host name of the database we connect to
        /// </summary>
        public readonly string DatabaseHost;
        /// <summary>
        /// Returns the username used to login to the database
        /// </summary>
        public readonly string DatabaseUser;
        /// <summary>
        /// Returns the password used to login to the database
        /// </summary>
        public readonly string DatabasePassword;
        /// <summary>
        /// Returns the database used to store podcast data
        /// </summary>
        public readonly string DatabaseDatabase;
        /// <summary>
        /// Podcaster database
        /// </summary>
        public readonly IDatabase ipd;
        /// <summary>
        /// Loaded commands
        /// </summary>
        public readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        /// <summary>
        /// Loaded controllers
        /// </summary>
        public readonly List<IController> Controllers = new List<IController>();
        #endregion

        #region Constructors
        /// <summary>
        /// Load a simplified configuration file from the default path
        /// </summary>
        public PodcasterConfiguration() : this(DEFAULT_PATH) { }

        /// <summary>
        /// Load a simplified configuration file
        /// </summary>
        /// <param name="strFileName">File path to load</param>
        public PodcasterConfiguration(string strFileName)
        {
            Servers = new List<StreamingServer>();
            IgnoredShows = new List<string>();

            XmlTextReader xml = new XmlTextReader(strFileName);
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    if (xml.Name == "Podcast")
                    {
                        EditedShow = xml.ReadElementContentAsString();
                    }
                    else if (xml.Name == "FullShow")
                    {
                        FullShow = xml.ReadElementContentAsString();
                    }
                    else if (xml.Name == "TitleStream")
                    {
                        TitleStream = xml.ReadElementContentAsString();
                    }
                    else if (xml.Name == "Soundcard")
                    {
                        Soundcard = xml.ReadElementContentAsString();
                    }
                    else if (xml.Name == "InactivityTimeout")
                    {
                        InactivityTimer = xml.ReadElementContentAsInt();
                    }
                    else if (xml.Name == "ActivityTimeout")
                    {
                        ActivityTimer = xml.ReadElementContentAsInt();
                    }
                    else if (xml.Name == "IgnoreShow")
                    {
                        IgnoredShows.Add(xml.ReadElementContentAsString());
                    }
                    else if (xml.Name == "Database")
                    {
                        Dictionary<string, string> values = new Dictionary<string,string>();
                        while (xml.MoveToNextAttribute())
                        {
                            values.Add(xml.Name.ToLower(), xml.Value);
                        }

                        this.ipd = (IDatabase)PluginLoader.LoadPlugin(values["engine"], "IDatabase");

                        if (ipd != null)
                        {
                            foreach (string key in values.Keys)
                            {
                                ipd.SetParameter(key, values[key]);
                            }
                        }
                    }
                    else if (xml.Name == "Controller")
                    {
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        while (xml.MoveToNextAttribute())
                        {
                            values.Add(xml.Name.ToLower(), xml.Value);
                        }

                        IController icd = (IController)PluginLoader.LoadPlugin(values["engine"], "IController");

                        if (icd != null)
                        {
                            foreach (string key in values.Keys)
                            {
                                icd.SetParameter(key, values[key]);
                            }
                        }

                        icd.Start();

                        this.Controllers.Add(icd);
                    }
                    else if (xml.Name == "Server")
                    {
                        StreamingServer kServer = null;
                        while (xml.MoveToNextAttribute())
                        {
                            if (xml.Name == "Type")
                            {
                                if (xml.Value == "Icecast")
                                {
                                    kServer = new IcecastServer();
                                }
                                else
                                {
                                    kServer = new ShoutcastServer();
                                }
                                // TODO Make additional server types available via plug-in
                            }
                            else if (xml.Name == "Host")
                            {
                                kServer.strHostname = xml.Value;
                            }
                            else if (xml.Name == "Port")
                            {
                                kServer.nPort = Int32.Parse(xml.Value);
                            }
                            else if (xml.Name == "Mount")
                            {
                                try
                                {
                                    ((IcecastServer)kServer).strMount = xml.Value;
                                }
                                catch (Exception)
                                {
                                    // Likely a cast exception caused by someone trying to assign
                                    // a mount point to a SHOUTcast server.  Ignore it.
                                }
                            }
                            else if (xml.Name == "Username")
                            {
                                kServer.strUsername = xml.Value;
                            }
                            else if (xml.Name == "Password")
                            {
                                kServer.strPassword = xml.Value;
                            }
                        }

                        if (kServer != null)
                        {
                            Servers.Add(kServer);
                        }
                    }
                    else if (xml.Name == "PodcastFTP")
                    {
                        while (xml.MoveToNextAttribute())
                        {
                            if (xml.Name == "Host")
                            {
                                PodcastFTPHost = xml.Value;
                            }
                            else if (xml.Name == "Username")
                            {
                                PodcastFTPUsername = xml.Value;
                            }
                            else if (xml.Name == "Password")
                            {
                                PodcastFTPPassword = xml.Value;
                            }
                            else if (xml.Name == "Directory")
                            {
                                PodcastFTPDirectory = xml.Value;
                            }
                        }
                    }
                    else if (xml.Name != "Podcaster")
                    {
                        // Possibly the base configuration for a plug-in.  Read all its attributes.
                        string pluginName = xml.Name;

                        ICommand plugin = (ICommand)PluginLoader.LoadPlugin(pluginName, "ICommand");

                        if (plugin != null)
                        {
                            while (xml.MoveToNextAttribute())
                            {
                                plugin.SetParameter(xml.Name, xml.Value);
                            }

                            commands.Add(pluginName, plugin);
                        }
                    }
                }
            }
            xml.Close();
        }
        #endregion

        #region Helper Functions

        /// <summary>
        /// Capitalize a string such that only the first letter is capitalized
        /// </summary>
        /// <param name="str">The input string</param>
        /// <returns>A formatted string</returns>
        private string Capitalize(string str)
        {
            str = str.ToLower();
            str = str.Substring(0, 1).ToUpper() + str.Substring(1);
            return str;
        }
        #endregion

        #region Store Configuration
        /// <summary>
        /// Stores this configuration in a file
        /// </summary>
        public void StoreConfiguration()
        {
            if (!Directory.Exists(Environment.SpecialFolder.ApplicationData.ToString()))
            {
                Directory.CreateDirectory(Environment.SpecialFolder.ApplicationData.ToString());
            }
            StoreConfiguration(Environment.SpecialFolder.ApplicationData.ToString() + TMP_PATH);
        }
        /// <summary>
        /// Stores this configuration in a file
        /// </summary>
        /// <param name="strFileName">File name</param>
        public void StoreConfiguration(string strFileName)
        {
            StoreConfiguration(strFileName, new BinaryFormatter());
        }
        /// <summary>
        /// Stores this configuration in a file with a given format
        /// </summary>
        /// <param name="strFileName">File path</param>
        /// <param name="format">File format</param>
        public void StoreConfiguration(string strFileName, IFormatter format)
        {
            Stream s = File.Open(strFileName, FileMode.Create);
            format.Serialize(s, this);
            s.Close();
        }
        #endregion

        #region Load Configuration
        /// <summary>
        /// Loads the configuration from a serialized file.
        /// </summary>
        /// <returns>A configuration object.</returns>
        public static PodcasterConfiguration LoadConfiguration()
        {
            return LoadConfiguration(Environment.SpecialFolder.ApplicationData.ToString() + TMP_PATH);
        }
        /// <summary>
        /// Loads the configuration from a serialized file.
        /// </summary>
        /// <param name="strFileName">Serialized file to load from.</param>
        /// <returns>A configuration object.</returns>
        public static PodcasterConfiguration LoadConfiguration(string strFileName)
        {
            return LoadConfiguration(strFileName, new BinaryFormatter());
        }
        /// <summary>
        /// Loads the configuration with a given formatter.
        /// </summary>
        /// <param name="strFileName">File name with the config</param>
        /// <param name="format">Format config is stored in</param>
        /// <returns>KLIKConfiguration object</returns>
        public static PodcasterConfiguration LoadConfiguration(string strFileName, IFormatter format)
        {
            Stream s = new FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.None);
            PodcasterConfiguration ks = (PodcasterConfiguration)format.Deserialize(s);
            s.Close();
            return ks;
        }
        #endregion
    }
}
