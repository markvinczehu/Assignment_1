
namespace PeopleWebApi.Models {
public class Adult : Person {
    public Job JobTitle { get; set; }
    
    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }
}
}