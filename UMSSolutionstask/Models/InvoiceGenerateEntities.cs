using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Entity.Infrastructure;

namespace UMSSolutionstask.Models
{
    public partial class InvoiceGenerateEntities : DbContext
    {
        public InvoiceGenerateEntities()
           : base("name=InvoiceGenerateEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<invoiceidt> invoiceidts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}