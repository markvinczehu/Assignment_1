namespace Models {
public class Adult : Person {
    public Job JobTitle { get; set; }

    public Adult()
    {
        Id = 0;
        FirstName = "";
        LastName = "";
        JobTitle = null;
        EyeColor = "";
        HairColor = "";
        Age = 0;
        Weight = 0;
        Height = 0;
        Sex = "";
    }
    }
}