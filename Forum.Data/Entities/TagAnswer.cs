namespace Forum.Data.Entities
{
    public class TagAnswer
    {
        public int TagId { get; set; }
        public int AnswerId { get; set; }

        public Tag Tag { get; set; }
        public Answer Answer { get; set; }
    }
}
