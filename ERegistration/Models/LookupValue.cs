namespace ERegistration.Models
{
    public class LookupValue
    {
        public int Id { get; set; }

        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Entity { get; set; }
        public bool IsActive { get; set; }
     }
}
