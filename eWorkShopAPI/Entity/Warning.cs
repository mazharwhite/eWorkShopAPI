//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eWorkShopAPI.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warning
    {
        public long WarningID { get; set; }
        public long ProductID { get; set; }
        public long Quantity { get; set; }
        public long WarningLimit { get; set; }
        public bool IsSMS { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
