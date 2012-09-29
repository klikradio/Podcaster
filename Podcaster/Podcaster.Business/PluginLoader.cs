using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Podcaster.Business
{
    public class PluginLoader
    {
        /// <summary>
        /// Load a plug-in
        /// </summary>
        /// <param name="pluginName">Name of the plug-in to load</param>
        /// <param name="pcInterface">Interface to look for in the plug-in</param>
        /// <returns>An object of the initiated plug-in.  Null if the plug-in could not be found or correctly loaded.</returns>
        public static object LoadPlugin(string pluginName, string pcInterface)
        {
            Assembly asm = null;

            asm = Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, "Podcaster." + pluginName + ".dll"));

            Type[] typesInPlugin = asm.GetTypes();
            Type interfaceToCheck = null;

            Assembly[] core = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly c in core)
            {
                if (c.FullName.Contains("Podcaster.Core"))
                {
                    foreach (Type t in c.GetTypes())
                    {
                        if (t.Name.Equals(pcInterface))
                        {
                            interfaceToCheck = t;
                            break;
                        }
                    }
                }
            }

            if (interfaceToCheck != null)
            {
                foreach (Type t in typesInPlugin)
                {
                    if (interfaceToCheck.IsAssignableFrom(t))
                    {
                        return Activator.CreateInstance(t);
                    }
                }
            }

            return null;
        }

        public static List<string> ListPlugins(string pcInterface)
        {
            List<string> retList = new List<string>();
            Type interfaceToCheck = null;

            Assembly[] core = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly c in core)
            {
                if (c.FullName.Contains("Podcaster.Core"))
                {
                    foreach (Type t in c.GetTypes())
                    {
                        if (t.Name.Equals(pcInterface))
                        {
                            interfaceToCheck = t;
                            break;
                        }
                    }
                }
            }

            if (interfaceToCheck != null)
            {
                string[] pluginFiles = Directory.GetFiles(Environment.CurrentDirectory, "Podcaster.*.dll");
                foreach (string pluginFile in pluginFiles)
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFrom(pluginFile);
                        Type[] typesInPlugin = asm.GetTypes();
                        foreach (Type t in typesInPlugin)
                        {
                            if (interfaceToCheck.IsAssignableFrom(t))
                            {
                                if (!t.Name.Equals(pcInterface))
                                {
                                    string FileToLoad = pluginFile.Substring(pluginFile.LastIndexOf("\\") + 1);
                                    FileToLoad = FileToLoad.Substring(10);
                                    FileToLoad = FileToLoad.Substring(0, FileToLoad.Length - 4);
                                    retList.Add(FileToLoad);
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            return retList;
        }
    }
}
