﻿//------------------------------------------------------------------------------
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
  using System.Data.Entity;
  using System.Data.Entity.Infrastructure;

  public partial class eWorkShop123Entities : DbContext
  {
    public eWorkShop123Entities()
        : base("name=eWorkShop123Entities")
    {
      this.Configuration.ProxyCreationEnabled = false;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductTicket> ProductTickets { get; set; }
    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    public virtual DbSet<TemplateType> TemplateTypes { get; set; }
    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<TicketTemplate> TicketTemplates { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserType> UserTypes { get; set; }
    public virtual DbSet<Warning> Warnings { get; set; }
  }
}
