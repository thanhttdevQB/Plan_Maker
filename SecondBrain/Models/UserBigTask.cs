using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.Models
{
    public class UserBigTask
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public List<UserTask> Tasks { get; set; }

        [Required]
        [Range(0, 100)]

        public int PercentageDone { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
