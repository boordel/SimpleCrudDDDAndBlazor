using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mc2.CrudTest.Presentation.Shared.ViewModels;
public class CustomerModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string FirstName { get; set; } = "";

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string LastName { get; set; } = "";

    [Display(Name = "Date of Birth")]
    [Required(ErrorMessage = "The {0} field is required.")]
    [DataType(DataType.Date)]
    [RegularExpression(@"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/((19|20)\d\d)$", ErrorMessage = "The {0} is not valid.")]
    public string DateOfBirth { get; set; } = "";

    [Display(Name = "Phone Number")]
    [Required(ErrorMessage = "The {0} field is required.")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^\+(?:[0-9] ?){6,14}[0-9]$", ErrorMessage = "The {0} is not valid.")]
    public string PhoneNumber { get; set; } = "";

    [Display(Name = "Email")]
    [Required(ErrorMessage = "The {0} field is required.")]
    [EmailAddress(ErrorMessage = "The {0} field is not a valid e-mail address.")]
    public string Email { get; set; } = "";

    [Display(Name = "Bank Account Number")]
    [Required(ErrorMessage = "The {0} field is required.")]
    [RegularExpression(@"^[0-9]{6,28}$", ErrorMessage = "The {0} is not valid.")]
    public string BankAccountNumber { get; set; } = "";
}
