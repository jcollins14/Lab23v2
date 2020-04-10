using System;
using System.Collections.Generic;

namespace Lab23v2.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int? Wallet { get; set; }
    }
}
