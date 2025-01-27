using System.ComponentModel.DataAnnotations;
namespace AccessControl_backend.Models
{
    public class UserField
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool Required { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
