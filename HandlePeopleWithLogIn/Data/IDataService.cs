using System.Collections.Generic;
using Models;

namespace HandlePeopleWithLogIn.Data
{
    public interface IDataService
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int Id);
        void Update(Adult adult);
        Adult Get(int Id);
    }
}