using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Required(ErrorMessage = "Type a valid username"), MaxLength(36)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Type a valid password"), MaxLength(Int32.MaxValue)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}