using System.Text.Json.Serialization;

namespace PeopleWebApi.Models {
public class Person {
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    [JsonPropertyName("HairColor")]
    public string HairColor { get; set; }
    [JsonPropertyName("EyeColor")]
    public string EyeColor { get; set; }
    [JsonPropertyName("Age")]
    public int Age { get; set; }
    [JsonPropertyName("Weight")]
    public float Weight { get; set; }
    [JsonPropertyName("Height")]
    public int Height { get; set; }
    [JsonPropertyName("Sex")]
    public string Sex { get; set; }
}

}