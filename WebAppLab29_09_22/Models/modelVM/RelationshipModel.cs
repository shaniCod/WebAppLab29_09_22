using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab29_09_22.Models
{
    public class RelationshipModel
    {
        public int RID { get; set; }
        public int? SID { get; set; }
        public int? TID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}