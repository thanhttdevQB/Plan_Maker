using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SecondBrain.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [AllowNull]
        public string Avatar {  get; set; }

        [AllowNull]
        public List<UserTask> Tasks { get; set; }

        [AllowNull]
        public List<Post> posts { get; set; }

        [AllowNull]
        public List<Message> messages { get; set; }

        [AllowNull]
        public List<AppUser> Friends { get; set; }
    }
}
