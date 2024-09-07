using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondBrain.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the UserManager class
    public class AppUser : IdentityUser
    {
        public int Avatar { get; set; }

        [MaxLength(50)]
        [Required]
        public int UserName { get; set; }
    }
}