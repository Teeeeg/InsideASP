using MediatRDemo.Library.Models;

namespace MediatRDemo.Library.DataAccess;

public class PersonDataAccess : IDataAccess
{
    private readonly List<PersonModel> _personList = new();

    public PersonDataAccess()
    {
        _personList.Add(new PersonModel { Id = 1, SurName = "Tom", GivenName = "Cory" });
        _personList.Add(new PersonModel { Id = 2, SurName = "Tex", GivenName = "Cory" });
        _personList.Add(new PersonModel { Id = 3, SurName = "Tao", GivenName = "Cory" });
    }

    public IEnumerable<PersonModel> GetAllPersons()
    {
        return _personList;
    }

    public PersonModel AddToList(string surName, string givenName)
    {
        PersonModel personToAdd = new PersonModel { SurName = surName, GivenName = givenName };
        personToAdd.Id = _personList.Max(p => p.Id) + 1;

        return personToAdd;
    }
}
