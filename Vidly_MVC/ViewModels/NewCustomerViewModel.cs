using Vidly_MVC.Models;

namespace Vidly_MVC.ViewModels;

public class CustomerFormViewModel
{
    public IEnumerable<MembershipType> MembershipTypes { get; set; }
    public Customer Customer { get; set; }
}