namespace ERegistration.Models
{
    public class NoticeOfCommencement
    {
        public int Id { get; set; }

        public int ContractorId { get; set; } 
        public Contractor Contractor { get; set; }

        public int LenderId { get; set; }
        public Lender Lender { get; set; }
        public int TitleCompanyId { get; set; }
        public TitleCompany TitleCompany { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public IList<NoticeOfCommencementPropertyOwner> PropertyOwners { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}