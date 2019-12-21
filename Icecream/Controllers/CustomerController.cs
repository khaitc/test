using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Icecream.Models;

namespace Icecream.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer obj)
        {
            if (ModelState.IsValid)
            {
                CustomerBLL bll = new CustomerBLL();
                Customer cus = new Customer();
                cus = bll.Login(obj.customername, obj.password);

                if (cus != null)
                {
                    Session["username"] = cus.customername;
                    Session["customertype"] = cus.customer_type;
                    return RedirectToAction("");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
            }

            return View();
        }

        public ActionResult ListCustomer()
        {
            CustomerBLL bll = new CustomerBLL();
            List<Customer> obj = new List<Customer>();
            obj = bll.AllCustomerToList();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(Customer obj)
        {
            if (ModelState.IsValid)
            {
                CustomerBLL bll = new CustomerBLL();
                if (bll.Add(obj) == 0)
                {
                    return RedirectToAction("ListCustomer", "Customer");
                }

            }
            return View();
        }
    }
}