using System.ComponentModel.DataAnnotations;

namespace SecondBrain.DTOs
{
    public class Register
    {
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password not match")]
        public string? ConfirmPassword { get; set; }
    }
}
