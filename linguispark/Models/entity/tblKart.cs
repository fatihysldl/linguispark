//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace linguispark.Models.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblKart
    {
        public int id { get; set; }
        public Nullable<int> kartBaslikCevirmenAdi { get; set; }
        public string kartAciklama { get; set; }
        public string kartFotograf { get; set; }
        public Nullable<bool> kartDurum { get; set; }
    
        public virtual tblCevirmen tblCevirmen { get; set; }
    }
}