using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime_Financial_Holdings.Models
{
    public class User
    {
        public User()
        {

        }
        [Required]
        public string Password { get; set; }
   
        [Key]
        public string Username { get; set; }
        
        public int? AccountNumber { get; set; }
        [ForeignKey("AccountNumber")]
        public virtual Account Account { get; set; }
    }
}
