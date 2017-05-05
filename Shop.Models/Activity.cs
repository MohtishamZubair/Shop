namespace Shop.Models
{
    public class Activity : BaseEntity
    {
        public int ActivityId { get; set; }
        public int RefernceId { get; set; }
        public string ReferenceName { get; set; }
        public string ActivtyAction { get; set; }
        public string Note { get; set; }
    }
}