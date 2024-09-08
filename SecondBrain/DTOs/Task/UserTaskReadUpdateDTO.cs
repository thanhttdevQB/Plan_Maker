using SecondBrain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.DTOs.Task
{
    public class UserTaskReadUpdateDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly TaskDay { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly EndTime { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
