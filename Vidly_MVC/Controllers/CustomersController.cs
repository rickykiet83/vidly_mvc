using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly_MVC.Data;
using Vidly_MVC.Models;

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
}