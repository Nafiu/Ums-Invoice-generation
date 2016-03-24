using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSSolutionstask.Models
{
    public partial class Customer
    {
        public int Cusid { get; set; }
        public string Cusname { get; set; }

        public virtual ICollection<invoiceidt> invoiceidts { get; set; }
    }
}