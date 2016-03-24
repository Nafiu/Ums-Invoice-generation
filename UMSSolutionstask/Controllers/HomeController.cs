using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMSSolutionstask.Models;

namespace UMSSolutionstask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            List<Product> pro = new List<Product>();
            using (InvoiceGenerateEntities db = new InvoiceGenerateEntities())
            {
                pro = db.Products.ToList();
            }
            return new JsonResult { Data = pro, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetSingleProduct(int Pid)
        {
            Product pro = new Product();
            using (InvoiceGenerateEntities db = new InvoiceGenerateEntities())
            {
                pro = db.Products.Where(a => a.Pid == Pid).FirstOrDefault();
            }
            return new JsonResult { Data = pro, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GenerateInvoiceId(int ivid)
        {
            invoiceidt i = new invoiceidt();
            i.Cusid = ivid;
            using (InvoiceGenerateEntities db = new InvoiceGenerateEntities())
            {
                db.invoiceidts.Add(i);
                db.SaveChanges();
                i = db.invoiceidts.Where(a => a.Cusid == ivid).ToList().LastOrDefault();
                return new JsonResult { Data = i, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveDb(List<Invoice> ar)
        {
            using (InvoiceGenerateEntities db = new InvoiceGenerateEntities())
            {
                foreach (Invoice i in ar)
                {
                    db.Invoices.Add(i); db.SaveChanges();
                }

            }
            return new JsonResult { Data = "hi", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}