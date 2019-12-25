﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zorgcirckel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ZorgCirkelEntities : DbContext
    {
        public ZorgCirkelEntities()
            : base("name=ZorgCirkelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<antwoord> antwoord { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Contacten> Contacten { get; set; }
        public virtual DbSet<Incidenten> Incidenten { get; set; }
        public virtual DbSet<Lijsten> Lijsten { get; set; }
        public virtual DbSet<Rapportages> Rapportages { get; set; }
        public virtual DbSet<VraagType> VraagType { get; set; }
        public virtual DbSet<Vragen> Vragen { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
    
        public virtual ObjectResult<LijstenBekijken_Result> LijstenBekijken(Nullable<int> lijstID)
        {
            var lijstIDParameter = lijstID.HasValue ?
                new ObjectParameter("LijstID", lijstID) :
                new ObjectParameter("LijstID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LijstenBekijken_Result>("LijstenBekijken", lijstIDParameter);
        }
    
        public virtual int SPVerwijderContactpersoonRij(string cONTACTPERSOONID, string pATIENTID)
        {
            var cONTACTPERSOONIDParameter = cONTACTPERSOONID != null ?
                new ObjectParameter("CONTACTPERSOONID", cONTACTPERSOONID) :
                new ObjectParameter("CONTACTPERSOONID", typeof(string));
    
            var pATIENTIDParameter = pATIENTID != null ?
                new ObjectParameter("PATIENTID", pATIENTID) :
                new ObjectParameter("PATIENTID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPVerwijderContactpersoonRij", cONTACTPERSOONIDParameter, pATIENTIDParameter);
        }
    }
}