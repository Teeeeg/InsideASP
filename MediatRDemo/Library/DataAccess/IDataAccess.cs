using MediatRDemo.Library.Models;

namespace MediatRDemo.Library.DataAccess;

public interface IDataAccess
{
    IEnumerable<PersonModel> GetAllPersons();
    PersonModel AddToList(string surName, string givenName);
}
