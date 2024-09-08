using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.DTOs.Task
{
    public class UserTaskCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly TaskDay { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly EndTime { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
