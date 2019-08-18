using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Profile { get; set; }
        
    }
}