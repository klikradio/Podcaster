using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Podcaster.Core;
using Podcaster.Utilities;
using Facebook;

namespace Podcaster.Facebook
{
    public class Facebook : ICommand
    {
        private Dictionary<string, string> config = new Dictionary<string, string>();
        private PodcastInfo pi;

        public Facebook()
        {
        }

        public object GetParameter(string key)
        {
            return config[key];
        }

        public void SetParameter(string key, string value)
        {
            config.Add(key, value);
        }

        public void RunCommand(object args, ActionCalled ac)
        {
            if (ac == ActionCalled.ShowStart)
            {
                pi = (PodcastInfo)args;
                Thread t = new Thread(new ThreadStart(UpdateFacebook));
                t.Start();
            }
        }

        public void Dispose()
        {
        }

        private void UpdateFacebook()
        {
            FacebookClient fb = new FacebookClient(config["access_token"]);

            Dictionary<string, object> fbParams = new Dictionary<string, object>();

            foreach (KeyValuePair<string, string> configElement in config)
            {
                fbParams.Add(configElement.Key, pi.ParseVariables(configElement.Value));
                Console.WriteLine(configElement.Key + " = " + pi.ParseVariables(configElement.Value));
            }

            try
            {
                Console.WriteLine(fb.Post("/me/feed", fbParams));
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }
    }
}
