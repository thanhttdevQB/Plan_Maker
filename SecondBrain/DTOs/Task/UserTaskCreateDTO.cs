using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.DTOs.Task
{
    public class UserTaskCreateDTO
    {
        [StringLength(50)]
        public string Name { get; set; }

        public Guid UserId { get; set; }

        [DataType(DataType.Date)]
        public DateOnly TaskDay { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly EndTime { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        public int Status { get; set; }
    }
}
