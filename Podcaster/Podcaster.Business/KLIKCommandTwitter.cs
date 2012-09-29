using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitterizer;


namespace KLIK.Business
{
    class KLIKCommandTwitter : IKLIKCommand
    {
        public string AccessToken;
        public string AccessTokenSecret;
        public string ConsumerKey;
        public string ConsumerSecret;
        public string strMessage;

        public KLIKCommandTwitter() { }

        public KLIKCommandTwitter(string AccessToken,
                                    string AccessTokenSecret,
                                    string ConsumerKey,
                                    string ConsumerSecret,
                                    string strMessage)
        {
            this.AccessToken = AccessToken;
            this.AccessTokenSecret = AccessTokenSecret;
            this.ConsumerKey = ConsumerKey;
            this.ConsumerSecret = ConsumerSecret;
            this.strMessage = strMessage;
        }

        public void RunCommand()
        {
            OAuthTokens oauth = new OAuthTokens();
            oauth.AccessToken = AccessToken;
            oauth.AccessTokenSecret = AccessTokenSecret;
            oauth.ConsumerKey = ConsumerKey;
            oauth.ConsumerSecret = ConsumerSecret;

            TwitterResponse<TwitterStatus> response = TwitterStatus.Update(oauth, strMessage);
        }
    }
}
