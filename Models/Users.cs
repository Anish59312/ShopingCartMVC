using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShopingCartMVC.Models
{
    public class Users
    {
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        [Required(ErrorMessage = "EmailId is mandatory.")]
        [DisplayName("Email Id")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = " Password is mandatory")]
        [DisplayName("User Password")]
        [StringLength(maximumLength: 10, ErrorMessage = "Password should be less than 10 characters")]
        public string UserPassword { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<byte> RoleId { get; set; }
        [Required(ErrorMessage ="Gender is required")]
        [RegularExpression("M|F", ErrorMessage ="Gender should be F or M")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "DOB is mandatory.")]
        [DataType(DataType.Date)]
        [DisplayName("Date of birth")]

        public System.DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address is mandatory.")]
        public string Address { get; set; }
    }
}
