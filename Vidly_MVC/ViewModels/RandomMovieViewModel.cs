
using Vidly_MVC.Models;

namespace Vidly_MVC.ViewModels;

public class RandomMovieViewModel
{
    public Movie Movie { get; set; }
    public List<Customer> Customers { get; set; }
}