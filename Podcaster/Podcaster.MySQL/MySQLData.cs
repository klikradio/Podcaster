using System;
using System.Collections.Generic;
using System.Text;

using Podcaster.Core;
using System.Data;
using MySql.Data.MySqlClient;

namespace Podcaster.MySQL
{
    public class MySQLData : IDatabase
    {
        private MySqlConnection conn;
        private Dictionary<string, string> config;

        /// <summary>
        /// Create a data request.
        /// </summary>
        public MySQLData()
        {
            config = new Dictionary<string, string>();
        }

        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "UID=" + config["username"] +
                ";Password=" + config["password"] +
                ";Server=" + config["server"] +
                ";Database=" + config["database"];
            conn.Open();
        }

        /// <summary>
        /// Load currently active shows.
        /// </summary>
        /// <returns>A DataTable representing currently active shows.</returns>
        public void ListShows(IPodcasterComboBox ipcb)
        {
            Connect();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Shows` WHERE `Active`=1 ORDER BY `Title`", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.Close();

            ipcb.SetDataSource(dt, "Title", "ID");
        }

        /// <summary>
        /// Insert a podcast into the database.
        /// </summary>
        /// <param name="pi">Podcast to add</param>
        /// <param name="strFile">Finalized file name</param>
        public void InsertPodcast(PodcastInfo pi, string strFile)
        {
            Connect();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `Podcasts` (`ShowID`, `DateTime`, `Title`, `Description`, `File`) " + 
                "VALUES (@ShowID, @DateTime, @Title, @Description, @File)", conn);

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ShowID", pi.kShow.nID);
            cmd.Parameters.AddWithValue("@DateTime", pi.dEnded);
            cmd.Parameters.AddWithValue("@Title", pi.strTitle);
            cmd.Parameters.AddWithValue("@Description", pi.strDescription);
            cmd.Parameters.AddWithValue("@File", strFile);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void SetParameter(string key, string value)
        {
            config.Add(key, value);
        }

        public Object GetParameter(string key)
        {
            return config[key];
        }

        public ShowInfo GetShow(DataRowView drv)
        {
            ShowPermissions kSkill = ShowPermissions.Basic;
            switch (drv["Skill"].ToString())
            {
                case "Basic":
                    kSkill = ShowPermissions.Basic;
                    break;
                case "Intermediate":
                    kSkill = ShowPermissions.Intermediate;
                    break;
                case "Advanced":
                    kSkill = ShowPermissions.Advanced;
                    break;
            }

            return new ShowInfo(Convert.ToInt32(drv["ID"]), drv["Title"].ToString(), kSkill);
        }
    }
}
