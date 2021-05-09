using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleWebApi.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string JobTitle { get; set; }
        [Required, Range(0, Int32.MaxValue, ErrorMessage = "Salary must be over 0!")]
        public int Salary { get; set; }
    }
}