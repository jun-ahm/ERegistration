namespace ERegistration.Models
{
    public class BusinessType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public ICollection<Contractor> Contractors { get; set; }
    }
}