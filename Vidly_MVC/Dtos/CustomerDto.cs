using System.ComponentModel.DataAnnotations;

namespace Vidly_MVC.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public bool IsSubscribedToNewsletter { get; set; }

    public byte MembershipTypeId { get; set; }

    public MembershipTypeDto MembershipType { get; set; }

    // [Min18YearsIfAMember]
    public DateOnly? Birthdate { get; set; }
}