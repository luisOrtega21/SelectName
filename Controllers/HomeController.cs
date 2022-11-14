using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SelectExample.Data;
using SelectExample.Models;
using SelectExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SelectExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SelectListContext _context;

        public HomeController(SelectListContext context ,ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult List()
        {
            List<Customer> customers = _context.Customers
                .Include(c=> c.Country)
                .Include(c=> c.City)
                .ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            CustomerCreateModel customerCreateModel = new CustomerCreateModel();
            customerCreateModel.Customer = new Customer();
            List<SelectListItem> countries = _context.Countries
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Code,
                    Text = n.Name
                }).ToList();

            customerCreateModel.Countries = countries;
            customerCreateModel.Cities = new List<SelectListItem>();
            return View(customerCreateModel);
        }

        public ActionResult GetCities(string CountryCode)
        {
            if(!string.IsNullOrWhiteSpace(CountryCode)&& CountryCode.Length == 3)
            {
                List<SelectListItem> citiesSel = _context.Cities
                    .Where(C => C.CountryCode == CountryCode)
                    .OrderBy(n => n.Name)
                    .Select(n => new SelectListItem
                    {
                        Value = n.Code,
                        Text = n.Name
                    }).ToList();
                return Json(citiesSel);
            }
            return null;
        }

        public IActionResult SaveCustomer(CustomerCreateModel cust)
        {
            _context.Add(cust.Customer);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
