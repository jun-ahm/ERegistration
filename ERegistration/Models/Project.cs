using System.ComponentModel.DataAnnotations;

namespace ERegistration.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Display(Name = "Project Name")]
        public required string Name { get; set; }
        public required string Lot { get; set; }
        public required string Block { get; set; }

        [Display(Name = "Legal Description")]
        public required string AdditionalDescription { get; set; }
        
        [Display(Name = "Number")]
        public required string Address_Line1 { get; set; }
        [Display(Name = "Street Name")]
        public required string Address_Line2 { get; set; }
        [Display(Name = "Suite/Apt Number")]
        public required string Address_Line3 { get; set; }
        [Display(Name = "City")]
        public required string Address_City { get; set; }
        [Required]
        [Display(Name = "Address State")]
        public int? Address_StateId { get; set; }
        public LookupValue? Address_State { get; set; }
        [Display(Name = "Zip Code")]
        public required string Address_ZipCode { get; set; }
        public required string County { get; set; }

        [Display(Name = "Tax Parcell Number")]
        public required string PinNumber { get; set; }
        [Display(Name = "Project Type")]
        public LookupValue? ProjectType { get; set; }
        public int? ProjectTypeId { get; set; }
        public int? ProjectSubType1Id { get; set; }
        [Display(Name = "Project SubType1")]
        public LookupValue? ProjectSubType1 { get; set; }
        public int? ProjectSubType2Id { get; set; }
        [Display(Name = "Project SubType2")]
        public LookupValue? ProjectSubType2 { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Estimated Completion Date")]
        public DateTime? CompletionDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsApproved { get; set; }
        public bool Deleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}