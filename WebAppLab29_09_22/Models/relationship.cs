//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppLab29_09_22.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class relationship
    {
        public int RID { get; set; }
        public Nullable<int> SID { get; set; }
        public Nullable<int> TID { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
