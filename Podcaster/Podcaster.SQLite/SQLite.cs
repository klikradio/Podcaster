using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.SQLite;
using Podcaster.Core;

namespace Podcaster.SQLite
{
    public class SQLite : IDatabase
    {
        private Dictionary<string, object> dbParameters = new Dictionary<string,object>();
        private SQLiteConnection conn;

        /// <summary>
        /// Connect to the database
        /// </summary>
        private void Connect()
        {
            conn = new SQLiteConnection("Data Source=\"" + dbParameters["datasource"] + "\"");
            conn.Open();
        }

        /// <summary>
        /// Get a parameter for this database
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetParameter(string key)
        {
            return dbParameters[key];
        }

        /// <summary>
        /// Set a parameter for this database
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetParameter(string key, string value)
        {
            dbParameters.Add(key, value);
        }

        /// <summary>
        /// Insert a podcast into the database
        /// </summary>
        /// <param name="pi">Podcast information to add</param>
        /// <param name="strFileName">File name of the podcast</param>
        public void InsertPodcast(PodcastInfo pi, string strFileName)
        {
            Connect();

            SQLiteCommand sql = new SQLiteCommand("INSERT INTO Episodes (ShowID, Title, Description, FileName, Release) VALUES (@ShowID, @Title, @Description, @FileName, @Release)", conn);
            sql.Prepare();
            sql.Parameters.AddWithValue("@ShowID", pi.kShow.nID);
            sql.Parameters.AddWithValue("@Title", pi.strTitle);
            sql.Parameters.AddWithValue("@Description", pi.strDescription);
            sql.Parameters.AddWithValue("@FileName", strFileName);
            sql.Parameters.AddWithValue("@Release", pi.dEnded);

            sql.ExecuteNonQuery();

            conn.Close();
        }

        /// <summary>
        /// List the shows in the database into an IPodcasterComboBox
        /// </summary>
        /// <param name="ipcb">Combo box to populate</param>
        public void ListShows(IPodcasterComboBox ipcb)
        {
            Connect();

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT ROWID, * FROM Shows", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            ipcb.SetDataSource(dt, "Name", "ROWID");
        }

        /// <summary>
        /// Convert a DataRowView to ShowInfo given this database schema
        /// </summary>
        /// <param name="drv">DRV to translate</param>
        /// <returns>A ShowInfo object</returns>
        public ShowInfo GetShow(DataRowView drv)
        {
            ShowPermissions kSkill = ShowPermissions.Basic;

            switch (Convert.ToInt32(drv["SkillLevel"]))
            {
                case 1:
                    kSkill = ShowPermissions.Basic;
                    break;
                case 2:
                    kSkill = ShowPermissions.Intermediate;
                    break;
                case 3:
                    kSkill = ShowPermissions.Advanced;
                    break;
            }

            return new ShowInfo(Convert.ToInt32(drv["ROWID"]), drv["Name"].ToString(), kSkill);
        }
    }
}
