using MediatR;
using MediatRDemo.Library.DataAccess;
using MediatRDemo.Library.Models;
using MediatRDemo.Library.Queries;

namespace MediatRDemo.Library.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, IEnumerable<PersonModel>>
{
    private readonly IDataAccess _dataAccess;

    public GetPersonListHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.GetAllPersons());
    }
}