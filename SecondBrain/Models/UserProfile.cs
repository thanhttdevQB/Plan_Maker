using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.Models
{
    public class UserProfile
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string? Avatar { get; set; }

        public bool IsSuspend { get; set; } = false;

        public List<UserTask>? UserTasks { get; } = null;

        public AppUser UserAccount { get; set; }
    }
}
