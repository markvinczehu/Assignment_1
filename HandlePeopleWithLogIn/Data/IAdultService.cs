using System.Collections.Generic;
using Models;

namespace HandlePeopleWithLogIn.Data
{
    public interface IAdultService
    {
        IList<Adult> Adults { get; }
    }
}