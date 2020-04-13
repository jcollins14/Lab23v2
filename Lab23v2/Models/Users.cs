using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab23v2.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="Password requires at least 5 characters.")]
        [MaxLength(20,ErrorMessage ="Password may not be more than 20 characters long.")]
        public string Pass { get; set; }
        [Required]
        public int? Wallet { get; set; }
    }
}
