using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using System.Configuration;

using Podcaster.Core;

namespace Podcaster.Business
{
    /// <summary>
    /// Represents a show
    /// </summary>
    public class KLIKShow : ShowInfo
    {
        /// <summary>
        /// Create a new KLIKShow object.
        /// </summary>
        public KLIKShow(int nID, string strName) : base(nID, strName)
        {
        }

        #region Static Methods
        /// <summary>
        /// Populate a combo box with active shows.
        /// </summary>
        /// <param name="kcb">A combo box that implements IKLIKComboBox</param>
        public static void ListShows(IPodcasterComboBox kcb)
        {
            CoreInstances.Database.ListShows(kcb);
        }

        #endregion
    }
}
