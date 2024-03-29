﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "Invalid Person Name")]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(50)]
        [RegularExpression("[0-9]*", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Profile { get; set; }

        [NotMapped]
        public string ShortProfile
        {
            get
            {
                if (Profile != null)
                {
                    if (Profile.Length > 30)
                        return Profile.Substring(0, 30) + " [more] ";
                    else
                        return Profile;
                }
                else
                    return null;
            }
        }

        [NotMapped]
        public string PhotoURL
        {
            get
            {
                return "/photos/" + Id.ToString() + ".jpg";
            }
        }

        [NotMapped]
        public HttpPostedFileBase ContactPhoto { get; set; }

        public string Username { get; set; }

        //[ForeignKey("Username")]
        //public User User { get; set; }
    }
}