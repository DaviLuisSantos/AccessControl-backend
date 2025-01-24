﻿using System.ComponentModel.DataAnnotations;

namespace AccessControl_backend.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
