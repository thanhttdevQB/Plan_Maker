using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SecondBrain.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
