using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PeopleWebApi.Models {
public class Person {
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(32)]
    public string FirstName { get; set; }
    [Required, MaxLength(32)]
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid age!")]
    public int Age { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid weight!")]
    public float Weight { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid height!")]
    public int Height { get; set; }
    public string Sex { get; set; }
    
    public void Update(Person toUpdate) {
        Age = toUpdate.Age;
        Height = toUpdate.Height;
        HairColor = toUpdate.HairColor;
        Sex = toUpdate.Sex;
        Weight = toUpdate.Weight;
        EyeColor = toUpdate.EyeColor;
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
    }
}

}