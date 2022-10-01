using Prime_Financial_Holdings.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime_Financial_Holdings.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }
        [Key]
        public int TRX_ID { get; set; }

        public int? accountNumber { get; set; } = HomeController.loggedInAccount.accountNumber;
        [ForeignKey("accountNumber")]
        public virtual Account Account { get; set; }

        [Required]
        public float amount { get; set; } = 0;

        public int? beneficiaryAccount { get; set; }
        [ForeignKey("beneficiaryAccount")]
        public virtual Account benAccount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public String time { get; set; } = DateTime.Now.ToShortTimeString();

        public String type { get; set; }
    }
}
