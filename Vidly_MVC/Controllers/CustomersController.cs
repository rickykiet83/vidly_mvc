using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Vidly_MVC.Data;
using Vidly_MVC.Models;
using Vidly_MVC.ViewModels;

namespace Vidly_MVC.Controllers;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _memoryCache;

    public CustomersController(ApplicationDbContext context, IMemoryCache memoryCache)
    {
        _context = context;
        _memoryCache = memoryCache;
    }

    public ViewResult Index()
    {
        if (_memoryCache.TryGetValue("Genres", out List<Genre>? genres)) return View();
        
        genres = _context.Genres.ToList();
        _memoryCache.Set("Genres", genres, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
        });

        return View();
    }

    public ActionResult New()
    {
        var membershipTypes = _context.MembershipTypes.ToList();
        var viewModel = new CustomerFormViewModel
        {
            Customer = new Customer(),
            MembershipTypes = membershipTypes
        };

        return View("CustomerForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        if (customer.Id == 0)
            _context.Customers.Add(customer);
        else
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
        }

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