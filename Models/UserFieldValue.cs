using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AccessControl_backend.Models;
namespace AccessControl_backend.Models
{
    public class UserFieldValue
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserFieldId { get; set; }
        [ForeignKey("UserFieldId")]
        public UserField UserField { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
