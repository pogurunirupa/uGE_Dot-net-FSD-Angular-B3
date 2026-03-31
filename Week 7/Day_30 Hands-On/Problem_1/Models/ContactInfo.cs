using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Contact Id is required")]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 15 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 15 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Company Name is required")]

        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [Range(1000000000, 9999999999, ErrorMessage = "Enter valid 10-digit mobile number")]
        public long MobileNo { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
    }
}