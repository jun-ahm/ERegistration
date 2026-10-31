using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class ContractorDetailsViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? BusinessName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Address_Line1 { get; set; }
        public string? Address_Line2 { get; set; }
        public string? Address_City { get; set; }
        public int Address_StateId { get; set; }
        public string? Address_State { get; set; }
        public string? Address_ZipCode { get; set; }
        public string? OfficePhone { get; set; }
        public string? CellPhone { get; set; }
        public string? Email { get; set; }
    }
}