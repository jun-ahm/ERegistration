using System.ComponentModel.DataAnnotations;

namespace ERegistration.Models
{
    public class Lender
    {
        public int Id { get; set; }
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string? Phone { get; set; }

        public string? CellPhone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Address Line1")]
        public string Address_Line1 { get; set; }

        [Display(Name = "Address Line2")]
        public string? Address_Line2 { get; set; }
        
        [Display(Name = "City")]
        public string Address_City { get; set; }

        [Required]
        [Display(Name = "Address State")]
        public int? Address_StateId { get; set; }

        public LookupValue? Address_State { get; set; }
        
        [Display(Name = "Zip Code")]
        public string Address_ZipCode { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}