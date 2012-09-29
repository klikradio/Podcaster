using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace Podcaster.Utilities
{
    public class PodcasterUtilities
    {
        /// <summary>
        /// Handle an exception.
        /// </summary>
        /// <param name="ex">The exception</param>
        public static void KLIKException(Exception ex)
        {
            string strMessage = "There was a problem with the KLIK Podcaster.\n\n" + ex.Message + "\n\n" + ex.StackTrace;
            MessageBox.Show(strMessage, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SendEmailMessage(strMessage);
            SendTwilioMessage();
        }
        /// <summary>
        /// Handle the exception.
        /// </summary>
        /// <param name="ex">A socket exception</param>
        public static void KLIKException(SocketException ex)
        {
            string strMessage = "There was a sockets problem.\n\n" + ex.Message + "\n\n" + ex.StackTrace; ;
            MessageBox.Show(strMessage, "Sockets Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            SendEmailMessage(strMessage);
        }
        /// <summary>
        /// Get the settings for sending e-mail
        /// </summary>
        /// <returns>A dictionary with the settings</returns>
        private static Dictionary<string, string> GetEmailSettings()
        {
            Dictionary<string, string> dReturn = new Dictionary<string, string>();

            StreamReader sr = new StreamReader("emailsettings.txt");
            while (!sr.EndOfStream)
            {
                string strLine = sr.ReadLine();
                dReturn.Add(strLine.Substring(0, strLine.IndexOf("=")), strLine.Substring(strLine.IndexOf("=") + 1));
            }

            return dReturn;
        }
        /// <summary>
        /// Send an e-mail to someone who can deal with exceptions.
        /// </summary>
        /// <param name="strMessage">Message to send.</param>
        private static void SendEmailMessage(string strMessage)
        {
            try
            {
                Dictionary<string, string> EmailSettings = GetEmailSettings();
                MailMessage mail = new MailMessage(EmailSettings["from"], EmailSettings["to"], EmailSettings["subject"], strMessage);
                NetworkCredential nc = new NetworkCredential(EmailSettings["smtpuser"], EmailSettings["smtppassword"]);
                SmtpClient smtp = new SmtpClient(EmailSettings["smtphost"]);
                smtp.Credentials = nc;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                // Fail silently
            }
        }

        /// <summary>
        /// Send an SMS message via Twilio
        /// </summary>
        public static void SendTwilioMessage()
        {
            try
            {
                Dictionary<string, string> dSettings = GetEmailSettings();

                if (dSettings["TwilioAccountSid"].Length > 0 &&
                    dSettings["TwilioAuthToken"].Length > 0 &&
                    dSettings["TwilioTo"].Length > 0 &&
                    dSettings["TwilioFrom"].Length > 0 &&
                    dSettings["TwilioBody"].Length > 0)
                {
                    Twilio twilio = new Twilio(dSettings["TwilioAccountSid"], dSettings["TwilioAuthToken"]); ;
                    Hashtable h = new Hashtable();
                    h.Add("From", dSettings["TwilioFrom"]);
                    h.Add("To", dSettings["TwilioTo"]);
                    h.Add("Body", dSettings["TwilioBody"]);

                    twilio.RequestAsync(String.Format("/2010-04-01/Accounts/{0}/SMS/Messages", dSettings["TwilioAccountSid"]), "POST", h);
                }
            }
            catch
            {
                // Fail silently...
            }
        }

        /// <summary>
        /// Sanitize a file name
        /// </summary>
        /// <param name="strFileName">A string to make safe for file name</param>
        /// <returns>A sanitized path or file name</returns>
        public static string MakeSafeFileName(string strString)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            return Regex.Replace(strString, invalidReStr, "_");
        }

        /// <summary>
        /// Verify the directory path exists
        /// </summary>
        /// <param name="strFileName">File name</param>
        public static void VerifyDirectoryExists(string strFileName)
        {
            string strPath = strFileName.Substring(0, strFileName.LastIndexOf('\\') + 1);
            strFileName = strFileName.Substring(strFileName.LastIndexOf('\\') + 1);
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                strFileName = strFileName.Replace(c, ' ');
            }
            foreach (char c in Path.GetInvalidPathChars())
            {
                strPath = strPath.Replace(c, ' ');
            }
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
        }
    }
}
