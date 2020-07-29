using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class TagAnswer
    {
        [Key]
        public int Id { get; set; }
        public int TagId { get; set; }
        public int AnswerId { get; set; }

        public Tag Tag { get; set; }
        public Answer Answer { get; set; }
    }
}
