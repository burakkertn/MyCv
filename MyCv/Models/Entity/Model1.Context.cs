﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCv.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbCvEntities : DbContext
    {
        public DbCvEntities()
            : base("name=DbCvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Deneyimler> Deneyimlers { get; set; }
        public virtual DbSet<Egitimler> Egitimlers { get; set; }
        public virtual DbSet<Hobiler> Hobilers { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<pdf> pdfs { get; set; }
        public virtual DbSet<Projeler> Projelers { get; set; }
        public virtual DbSet<Ref> Refs { get; set; }
        public virtual DbSet<Sertifikalar> Sertifikalars { get; set; }
        public virtual DbSet<SosyalMedya> SosyalMedyas { get; set; }
        public virtual DbSet<Yetenekler> Yeteneklers { get; set; }
    }
}
