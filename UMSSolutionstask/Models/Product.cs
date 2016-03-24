using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSSolutionstask.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public Nullable<double> Pdis { get; set; }
        public Nullable<double> Ptax { get; set; }
        public Nullable<decimal> PRate { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}