using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime_Financial_Holdings.Models
{
    public class Account
    {
        [Key]
        public int accountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float balance { get; set; }
       
        public bool requestedCheckbook { get; set; } = false;
        
        public int? LoanID { get; set; }

        [ForeignKey("LoanID")]
        
        public virtual Loan Loan { get; set; }

        public float loanAmount { get; set; } = 0;
    }
}
