using System.ComponentModel.DataAnnotations;

namespace Vidly_MVC.Models;

public class Customer
{
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public DateOnly? Birthdate { get; set; }
    public bool IsSubscribedToNewsLetter { get; set; }
    public MembershipType MembershipType { get; set; }
    public byte MembershipTypeId { get; set; }
}