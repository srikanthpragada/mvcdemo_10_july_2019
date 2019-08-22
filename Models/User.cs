using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Column]
        [Required]
        public string Password { get; set; }
        [Column]
        [Required]
        public string Email { get; set; }
    }
}