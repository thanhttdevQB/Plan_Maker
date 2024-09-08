﻿using System.ComponentModel.DataAnnotations;

namespace SecondBrain.DTOs
{
    public class SignIn
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
