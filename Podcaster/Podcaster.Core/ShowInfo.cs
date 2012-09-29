using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Core
{
    public class ShowInfo
    {
        /// <summary>
        /// ID of show
        /// </summary>
        public readonly int nID;
        /// <summary>
        /// Name of show
        /// </summary>
        public readonly string strName;
        /// <summary>
        /// Skill level of this show.
        /// </summary>
        public readonly ShowPermissions kSkill;

        public ShowInfo(int nID, string strName)
        {
            this.nID = nID;
            this.strName = strName;
        }

        public ShowInfo(int nID, string strName, ShowPermissions kSkill)
        {
            this.nID = nID;
            this.strName = strName;
            this.kSkill = kSkill;
        }
    }
}
