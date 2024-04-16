using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly_MVC.Models;

[Table("MembershipTypes")]
public class MembershipType
{
    public byte Id { get; set; }
    public short SignupFee { get; set; }
    public byte DurationInMonths { get; set; }
    public byte DiscountRate { get; set; }
}