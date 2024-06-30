using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondBrain.Models
{
    public class Message
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required]
        public bool IsImage { get; set; }

        [Required]
        public bool IsSender { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string MessageContent { get; set; }
    }
}
