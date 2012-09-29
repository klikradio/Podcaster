using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Core
{
    public interface IPodcasterComboBox
    {
        void AddItem(object i);
        void SetDataSource(object ds, string displayMember, string valueColumn);
    }
}
