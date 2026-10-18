namespace ERegistration.Models
{
    public class NoticeOfCommencementPropertyOwner
    {
        public int Id { get; set; }
        public NoticeOfCommencement NoticeOfCommencement { get; set; }
        public int PropertyOwnerId { get; set; }
        public PropertyOwner PropertyOwner { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}