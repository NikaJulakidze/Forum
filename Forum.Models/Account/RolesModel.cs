using System.ComponentModel.DataAnnotations;

namespace Forum.Models.Account
{
    public class RolesModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
