using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime_Financial_Holdings.Models
{
    public class Feedback
    {
        [Key]
        public int feedbackId { get; set; }

        public string? userName { get; set; }
        [ForeignKey("userName")]
        public virtual User User { get; set; }

        [Required]
        public String feedbackMessage { get; set; }
    }
}
