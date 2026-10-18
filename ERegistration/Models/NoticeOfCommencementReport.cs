namespace ERegistration.Models
{
    public class NoticeOfCommencementReport
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string ContractorName { get; set; }
        public string LicenseNumber { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractorState { get; set; }
        public string ContractorZipCode { get; set; }
        public string ContractorPhone { get; set; }
        public string ContractorEmail { get; set; }
        public string ContractorCellPhone { get; set; }
        public int ProjectId { get; set; }
        public string ProjectAddress { get; set; }
        public string ProjectState { get; set; }
        public string ProjectZipCode { get; set; }
        public string PinNumber { get; set; }
        public string County { get; set; }
        public string AdditionalDescription { get; set; }
        public string StartDate { get; set; }
        public string CompletionDate { get; set; }
        public int PropertyOwnerId { get; set; }
        public string PropertyOwnerName { get; set; }
        public string PropertyOwnerAddress { get; set; }

        public string PropertyOwnerState { get; set; }
        public string PropertyOwnerZipCode { get; set; }
        public string PropertyOwnerEmail { get; set; }
        public string PropertyOwnerPhone { get; set; }
        public string LenderBusinessName { get; set; }
        public string LenderName { get; set; }
        public string LenderAddress { get; set; }
        public string LenderState { get; set; }
        public string LenderZipCode { get; set; }
        public string LenderPhone { get; set; }
        public string LenderCellPhone { get; set; }
        public string LenderEmail { get; set; }
        public string TitleCompanyBusinessName { get; set; }
        public string TitleCompanyName { get; set; }
        public string TitleCompanyAddress { get; set; }
        public string TitleCompanyState { get; set; }
        public string TitleCompanyZipCode { get; set; }
        public string TitleCompanyPhone { get; set; }
        public string TitleCompanyCellPhone { get; set; }
        public string TitleCompanyEmail { get; set; }
    }
}