using System.ComponentModel.DataAnnotations;

namespace TalentGoWebAPI.Models
{
    public class Talents
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage ="The email is required")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string EmailAddress { get; set; } = string.Empty;

        public string Talent { get; set; } = string.Empty;
    }
}
