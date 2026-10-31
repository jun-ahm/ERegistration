namespace ERegistration.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public int Id { get; set; }
        public string? LegalDescription { get; set; }
        public string? ProjectAddress { get; set; }
        public string? Address_Line1 { get; set; }
        public string? Address_Line2 { get; set; }
        public string? Address_Line3 { get; set; }
        public string? Address_City { get; set; }
        public int Address_StateId { get; set; }
        public string? Address_State { get; set; }
        public string? Address_ZipCode { get; set; }
        public string? County { get; set; }
        public string? TaxParcelId { get; set; }
        public string? StartDate { get; set; }
        public string? CompletionDate { get; set; }
    }
}