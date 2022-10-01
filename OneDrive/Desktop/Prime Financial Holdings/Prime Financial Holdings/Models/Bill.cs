using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime_Financial_Holdings.Models
{
    public class Bill
    {
        [Key]
        public int billReferenceNumber { get; set; }

        [Required]
        public float billAmount { get; set; }
        
        public int? paidby { get; set; }
        [ForeignKey("paidby")]
        public virtual Account Account { get; set; }

        public string? companyName { get; set; }
        [ForeignKey("companyName")]
        public virtual Company company { get; set; }
    }
}
