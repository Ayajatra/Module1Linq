//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session1Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan LoginTime { get; set; }
        public Nullable<System.TimeSpan> LogoutTime { get; set; }
        public string FailReason { get; set; }
    
        public virtual User User { get; set; }
    }
}
