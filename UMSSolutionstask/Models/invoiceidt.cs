using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSSolutionstask.Models
{
    public partial class invoiceidt
    {
        public int ivid { get; set; }
        public int? Cusid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}