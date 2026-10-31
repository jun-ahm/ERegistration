namespace ERegistration.ViewModels
{
    public class NoticeOfCommencementDetailsViewModel
    {
        public int Id { get; set; }
        public ContractorDetailsViewModel Contractor { get; set; }
        public ProjectDetailsViewModel Project { get; set; }
        public LenderDetailsViewModel Lender { get; set; }
        public TitleCompanyDetailsViewModel TitleCompany { get; set; }
        public List<PropertyOwnerDetailsViewModel> PropertyOwners { get; set; }        
    }
}