using System.ComponentModel.DataAnnotations;

namespace AccessControl_backend.Models
{
    public class EntityAcess
    {
        [Key]
        private int Id { get; set; }

        [Required]
        private string Name { get; set ; }

        [Required]
        private string TypeEntity { get; set; }

        private List<AccessLocality> acess { get; set; }

    }
}
