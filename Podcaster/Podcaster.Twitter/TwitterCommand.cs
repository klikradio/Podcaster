using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Podcaster.Core;

using Twitterizer;

namespace Podcaster.Twitter
{
    public class TwitterCommand : ICommand
    {
        private Dictionary<string, string> config = new Dictionary<string,string>();
        private PodcastInfo pi;

        public TwitterCommand()
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
                this.pi = (PodcastInfo)args;
                Thread t = new Thread(new ThreadStart(UpdateTwitter));
                t.Start();
            }
        }

        private void UpdateTwitter()
        {
            try
            {
                if (config["Message"].Length > 0)
                {
                    OAuthTokens oauth = new OAuthTokens();
                    oauth.AccessToken = config["AccessToken"];
                    oauth.AccessTokenSecret = config["AccessTokenSecret"];
                    oauth.ConsumerKey = config["ConsumerKey"];
                    oauth.ConsumerSecret = config["ConsumerSecret"];

                    TwitterResponse<TwitterStatus> response = TwitterStatus.Update(oauth, pi.ParseVariables(config["Message"]));
                }
            }
            catch (Exception)
            {
                // Fail silently.  We don't really care about Twitter right now
            }
        }

        public void Dispose() { }
    }
}
