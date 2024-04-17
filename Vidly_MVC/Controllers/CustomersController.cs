using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly_MVC.Data;
using Vidly_MVC.Models;
using Vidly_MVC.ViewModels;

namespace Vidly_MVC.Controllers;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ViewResult Index()
    {
        var customers = _context.Customers.Include(c => c.MembershipType)
            .ToList();

        return View(customers);
    }

    public ActionResult New()
    {
        var membershipTypes = _context.MembershipTypes.ToList();
        var viewModel = new CustomerFormViewModel
        {
            MembershipTypes = membershipTypes
        };

        return View("CustomerForm", viewModel);
    }

    [HttpPost]
    public ActionResult Create(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return RedirectToAction("Index", "Customers");
    }

    public ActionResult Details(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer == null)
            return NotFound();

        return View(customer);
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

    public ActionResult Edit(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        if (customer is null) return NotFound();

        var viewModel = new CustomerFormViewModel
        {
            Customer = customer,
            MembershipTypes = _context.MembershipTypes.ToList()
        };

        return View("CustomerForm", viewModel);
    }
}