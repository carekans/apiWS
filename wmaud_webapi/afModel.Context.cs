﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wmaud_webapi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SEIEntities : DbContext
    {
        public SEIEntities()
            : base("name=SEIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ACFI_almacen> ACFI_almacen { get; set; }
        public DbSet<ACFI_articulo> ACFI_articulo { get; set; }
        public DbSet<ACFI_categoria> ACFI_categoria { get; set; }
        public DbSet<ACFI_equipos> ACFI_equipos { get; set; }
    }
}
