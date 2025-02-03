using System.ComponentModel.DataAnnotations;

namespace AccessControl_backend.Models
{
    public class AccessLocality
    {

        [Key]
        private int Id { get; set; }

        private int EntityAcessId { get; set; }
        private EntityAcess entityAcess { get; set; }

        private int LocalityId { get; set; }  
        private Locality locality { get; set; }

        private string TypeAcess { get; set; }

    }
}
