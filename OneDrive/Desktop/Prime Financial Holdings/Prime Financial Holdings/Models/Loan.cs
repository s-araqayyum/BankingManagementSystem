using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime_Financial_Holdings.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public float amount { get; set; }
    }
}

