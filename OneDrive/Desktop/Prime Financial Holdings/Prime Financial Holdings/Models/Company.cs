using System.ComponentModel.DataAnnotations;

namespace Prime_Financial_Holdings.Models
{
    public class Company
    {
        [Key]
        public String registeredName { get; set; }

        [Required]
        public long contactNumber { get; set; }
    }
}
