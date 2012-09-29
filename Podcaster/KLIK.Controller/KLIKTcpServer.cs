using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Net;
using System.Web;

using Podcaster.Core;
using Podcaster.Utilities;

namespace Podcaster.Controller
{
    public class TcpServer : IController
    {
        private int nPortNumber = 0;
        private Socket serverSocket;
        private byte[] byteData = new byte[1024];

        public event ResumeRecording OnResume;
        public event PauseRecording OnPause;
        public event LogSong OnLogSong;

        public void Start()
        {
            try
            {
                //We are using TCP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                                          SocketType.Stream,
                                          ProtocolType.Tcp);

                //Assign the any IP of the machine and listen on port number 1000
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, nPortNumber);

                //Bind and listen on the given address
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(4);

                //Accept the incoming clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket;
                try
                {
                    clientSocket = serverSocket.EndAccept(ar);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }

                // Once the client connects then start receiving the commands from it
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                    new AsyncCallback(OnReceive), clientSocket);

                // Start listening for more clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (SocketException)
            {
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);

                ASCIIEncoding ascii = new ASCIIEncoding();

                string strCommand = ascii.GetString(byteData);
                strCommand = strCommand.Substring(0, strCommand.IndexOf('\r'));
                if (strCommand.Trim().Contains("GET /on"))
                {
                    if (OnResume != null)
                    {
                        OnResume();
                    }
                }
                else if (strCommand.Trim().Contains("GET /off"))
                {
                    if (OnPause != null)
                    {
                        OnPause();
                    }
                }
                else if (strCommand.Trim().Contains("GET /song?"))
                {
                    if (OnLogSong != null)
                    {
                        try
                        {
                            string strURL = strCommand.Trim().Substring(4);
                            strURL = strURL.Substring(0, strURL.IndexOf(' ')).Substring(6);
                            NameValueCollection nvc = HttpUtility.ParseQueryString(strURL);
                            SongInfo kte = new SongInfo(nvc["artist"], nvc["title"], nvc["source"]);
                            OnLogSong(kte);
                        }
                        catch (Exception ex)
                        {
                            PodcasterUtilities.KLIKException(ex);
                        }
                    }
                }
#if DEBUG
                Console.WriteLine(strCommand);
#endif

                clientSocket.Send(ascii.GetBytes("HTTP/1.1 200 OK\r\nDate: " +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    "\r\nContent-Length: 0\r\nContent-type: text/plain\r\n\r\n"));
                clientSocket.Close();

            }
            catch (SocketException)
            {
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);                
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
        }

        public void Close()
        {
            try
            {
                serverSocket.Close();
            }
            catch
            {
                // Don't report anything.  Chances are the application is exiting.
            }
        }

        public void SetParameter(string key, string value)
        {
            if (key.Equals("port"))
            {
                nPortNumber = Convert.ToInt32(value);
            }
        }
    }
}