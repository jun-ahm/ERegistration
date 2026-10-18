using System.ComponentModel.DataAnnotations;

namespace ERegistration.Models
{
    public class Contractor
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Display(Name = "Middle Name")] 
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Display(Name = "Business Name")]
        public string? BusinessName { get; set; }   

        public int? BusinessTypeId { get; set; } //Foreign key property

        [Display(Name = "Business Type")]
        public BusinessType? BusinessType { get; set; }

        [Display(Name = "Business Trade")]
        public string? BusinessTrade { get; set; }

        [Display(Name = "License Number")]
        public string? LicenseNumber { get; set; }

        public string FullName
        {
            get
            {
                return BusinessName + " - " + FirstName + " " + LastName;
            }
        }

        [Display(Name = "Business Id")]
        public string? BusinessId { get; set; }

        [Display(Name = "Contact Name")]
        public string? ContactName { get; set; }

        [Display(Name = "Contact Phone")]
        public string? ContactPhone { get; set; } 

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

        [Required]
        [Display(Name = "Zip Code")]
        public string Address_ZipCode { get; set; }

        [Display(Name = "Mailing Address Line1")]
        public string? MailingAddress_Line1 { get; set; }

        [Display(Name = "Mailing Address Line2")]
        public string? MailingAddress_Line2 { get; set; }

        [Display(Name = "Mailing Address City")]
        public string? MailingAddress_City { get; set; }

        [Display(Name = "Mailing Address State")]
        public int? MailingAddress_StateId { get; set; }

        [Display(Name = "Mailing Address Zip Code")]
        public string? MailingAddress_ZipCode { get; set; }

        [Display(Name = "Office Phone")]
        public string? OfficePhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string? CellPhone { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}