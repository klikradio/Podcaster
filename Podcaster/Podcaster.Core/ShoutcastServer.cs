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
    /// Represents a SHOUTcast server
    /// </summary>
    public class ShoutcastServer : StreamingServer
    {
        /// <summary>
        /// Updates a song on this server
        /// </summary>
        /// <param name="strArtist">Artist of the song</param>
        /// <param name="strTitle">Title of the song</param>
        public override void UpdateSong(string strArtist, string strTitle)
        {
            try
            {
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(strHostname, nPort);

                string strSend = "GET /admin.cgi?pass=" + strPassword + "&mode=updinfo&song=" +
                Uri.EscapeDataString(strArtist + " - " + strTitle) + " HTTP/1.0\r\n";
                strSend += "User-agent: Mozilla/4.0\r\n\r\n";

                server.Send(Encoding.ASCII.GetBytes(strSend));
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            catch (SocketException ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }
    }
}
