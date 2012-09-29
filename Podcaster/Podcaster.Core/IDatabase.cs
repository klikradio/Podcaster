using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Podcaster.Core
{
    public interface IDatabase
    {
        void ListShows(IPodcasterComboBox ipcb);
        void InsertPodcast(PodcastInfo pi, string strFile);
        ShowInfo GetShow(DataRowView drv);

        void SetParameter(string key, string value);
        object GetParameter(string key);
    }
}
