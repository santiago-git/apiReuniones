﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReunionesBack.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReunionesDBEntities : DbContext
    {
        public ReunionesDBEntities()
            : base("name=ReunionesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estados_reunion> Estados_reunion { get; set; }
        public virtual DbSet<Estados_reunion_usuario> Estados_reunion_usuario { get; set; }
        public virtual DbSet<Reunion> Reunion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}