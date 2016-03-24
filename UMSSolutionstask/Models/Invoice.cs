using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSSolutionstask.Models
{
    public partial class Invoice
    {
        public int id { get; set; }
        public int? Invoiceid { get; set; }
        public int? Pid { get; set; }
        public string Pname { get; set; }
        public Nullable<double> Pdis { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<double> Ptax { get; set; }
        public Nullable<decimal> Net { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }

        public virtual invoiceidt invoiceidt { get; set; }
        public virtual Product Product { get; set; }
    }
}