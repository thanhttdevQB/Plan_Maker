using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondBrain.Models
{
    public class UserImage
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }
    }
}
