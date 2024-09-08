using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondBrain.Models
{
    public class UserPost
    {
        [Required]
        public bool isGlobal { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Content { get; set; }

        [Required]
        [StringLength(100)]
        public List<UserImage> Images { get; set; }
    }
}
