using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

using Podcaster.Utilities;

namespace Podcaster.Core
{
    /// <summary>
    /// Icecast server
    /// </summary>
    public class IcecastServer : StreamingServer
    {
        /// <summary>
        /// Mount point - for Icecast servers only
        /// </summary>
        public string strMount;

        public override void UpdateSong(string strArtist, string strTitle)
        {
            try
            {
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(strHostname, nPort);

                string strSend = "GET /admin/metadata.xsl?song=" + Uri.EscapeDataString(strArtist + " - " + strTitle) +
                    "&mount=" + strMount + "&mode=updinfo HTTP/1.0\r\n";
                strSend += "Authorization: Basic " +
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(strUsername + ":" + strPassword)) + "\r\n";
                strSend += "User-Agent: IcecastDSP (Mozilla Compatible)\r\n\r\n";

                server.Send(Encoding.ASCII.GetBytes(strSend));
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }
    }
}
