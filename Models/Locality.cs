using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControl_backend.Models
{
    public class Locality
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
