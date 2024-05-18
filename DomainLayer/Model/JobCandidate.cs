using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class JobCandidate
    {
        [Key]
        [Required(ErrorMessage ="Email is required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage ="Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name ="First name")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        public string LName { get; set; }
        [MaxLength(15,ErrorMessage ="PhoneNumber Must be less than 15 digits")]
        public string? PhoneNumber { get; set; }
        public string? TimeInterval { get; set; }
        public string? LinkedInURL { get; set; }
        public string? GitHubURL { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
    }
}
