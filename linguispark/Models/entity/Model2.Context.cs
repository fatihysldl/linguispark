﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class linguisparkEntities1 : DbContext
    {
        public linguisparkEntities1()
            : base("name=linguisparkEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAdmin> tblAdmin { get; set; }
        public virtual DbSet<tblCevirmen> tblCevirmen { get; set; }
        public virtual DbSet<tblHeader> tblHeader { get; set; }
        public virtual DbSet<tblMusteri> tblMusteri { get; set; }
        public virtual DbSet<tblSatis> tblSatis { get; set; }
        public virtual DbSet<tblWeather> tblWeather { get; set; }
        public virtual DbSet<tblProjeHakkinda> tblProjeHakkinda { get; set; }
        public virtual DbSet<tblKart> tblKart { get; set; }
        public virtual DbSet<tblHakkimda> tblHakkimda { get; set; }
    }
}
