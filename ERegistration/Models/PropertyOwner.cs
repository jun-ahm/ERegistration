using System.ComponentModel.DataAnnotations;

namespace ERegistration.Models
{
    public class PropertyOwner
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

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
        public string? County { get; set; }

        [Display(Name = "Mailing Address Line1")]
        public string? MailingAddress_Line1 { get; set; }

        [Display(Name = "Mailing Address Line2")]
        public string? MailingAddress_Line2 { get; set; }

        [Display(Name = "Mailing Address City")]
        public string? MailingAddress_City { get; set; }
        public int? MailingAddress_StateId { get; set; }
        public LookupValue? MailingAddress_State { get; set; }

        [Display(Name = "Mailing Address Zip Code")]
        public string? MailingAddress_ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}