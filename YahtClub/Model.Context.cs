﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YahtClub
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accessory_id> Accessory_id { get; set; }
        public virtual DbSet<AccToBoats> AccToBoats { get; set; }
        public virtual DbSet<Boat> Boat { get; set; }
        public virtual DbSet<BoatType> BoatType { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Organisations> Organisations { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<Pasports> Pasports { get; set; }
        public virtual DbSet<SalesPersons> SalesPersons { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypesOfPassports> TypesOfPassports { get; set; }
        public virtual DbSet<Wood> Wood { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
