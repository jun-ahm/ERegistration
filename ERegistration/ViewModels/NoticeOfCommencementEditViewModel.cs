namespace ERegistration.ViewModels
{
    public class NoticeOfCommencementEditViewModel
    {
        public int Id { get; set; }
        public ContractorEditViewModel Contractor { get; set; }
        public ProjectEditViewModel Project { get; set; }
        public LenderEditViewModel Lender { get; set; }       
        public IList<PropertyOwnerEditViewModel> PropertyOwners { get; set; }
    }
}