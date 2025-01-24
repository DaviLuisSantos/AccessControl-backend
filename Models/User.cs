using System.ComponentModel.DataAnnotations;

namespace AccessControl_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
