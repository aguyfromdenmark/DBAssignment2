using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using DBAssignment2.Models;

namespace DBAssignment2.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerBLL _customerBll = new CustomerBLL();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCustomerByPhone(string phoneNumber)
        {
            var customer = _customerBll.GetCustomerByPhone(phoneNumber);
            if (customer != null)
            {
                return PartialView("Partials/_CustomerInfoPartialView", customer);
            }
            else
            {
                var errorModel = new ErrorViewModel() { StatusCode = 404, ErrorMessage = "No customer found" };
                return PartialView("Partials/_ErrorPartialView", errorModel);
            }

        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel customer)
        {

            #region Placeholder Data
            var order1 = new OrderModel() { DatePlaces = DateTime.Now };
            var order2 = new OrderModel() { DatePlaces = DateTime.Now };
            var order3 = new OrderModel() { DatePlaces = DateTime.Now };

            var ol1 = new OrderLineModel() { Name = "Mazda 2", Price = 115000, Quantity = 5 };
            var ol2 = new OrderLineModel() { Name = "Mazda 3", Price = 248000, Quantity = 2 };
            var ol3 = new OrderLineModel() { Name = "Mazda 6", Price = 380000, Quantity = 1 };
            var ol4 = new OrderLineModel() { Name = "Mazda 2", Price = 115000, Quantity = 2 };
            var ol5 = new OrderLineModel() { Name = "Mazda 3", Price = 248000, Quantity = 4 };
            var ol6 = new OrderLineModel() { Name = "Mazda 6", Price = 380000, Quantity = 3 };
            var ol7 = new OrderLineModel() { Name = "Mazda 2", Price = 115000, Quantity = 1 };
            var ol8 = new OrderLineModel() { Name = "Mazda 3", Price = 248000, Quantity = 6 };
            var ol9 = new OrderLineModel() { Name = "Mazda 6", Price = 380000, Quantity = 2 };

            order1.Lines.Add(ol1);
            order1.Lines.Add(ol2);
            order1.Lines.Add(ol3);

            order2.Lines.Add(ol4);
            order2.Lines.Add(ol5);
            order2.Lines.Add(ol6);

            order3.Lines.Add(ol7);
            order3.Lines.Add(ol8);
            order3.Lines.Add(ol9);

            customer.Orders.Add(order1);
            customer.Orders.Add(order2);
            customer.Orders.Add(order3);
            #endregion

            if (_customerBll.GetCustomerByPhone(customer.PhoneNumber.ToString()) == null)
            {
                _customerBll.CreateCustomer(customer);
                return PartialView("Partials/_CustomerInfoPartialView", customer);
            }
            else
            {
                var errorModel = new ErrorViewModel() { StatusCode = 409, ErrorMessage = "A customer with that phone number already exists" };
                return PartialView("Partials/_ErrorPartialView", errorModel);
            }
        }

        [HttpPost]
        public void UpdateCustomer(CustomerModel customer, string Id)
        {
            customer.CreateIdFromString(Id);
            _customerBll.UpdateCustomer(customer);

            //var returnCustomer = _customerBll.GetCustomerByPhone(customer.PhoneNumber.ToString());
            //return PartialView("Partials/_CustomerInfoPartialView", returnCustomer);
        }
    }
}