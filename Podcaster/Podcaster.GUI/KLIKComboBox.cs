using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Podcaster.Core;

namespace Podcaster
{
    public partial class KLIKComboBox : ComboBox, IPodcasterComboBox
    {
        public void AddItem(object i)
        {
            this.Items.Add(i);
        }

        public void SetDataSource(object ds, string displayColumn, string valueColumn)
        {
            this.DataSource = ds;
            this.DisplayMember = displayColumn;
            this.ValueMember = valueColumn;
        }
    }
}
