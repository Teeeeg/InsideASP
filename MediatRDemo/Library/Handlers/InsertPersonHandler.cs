using MediatR;
using MediatRDemo.Library.Commands;
using MediatRDemo.Library.DataAccess;
using MediatRDemo.Library.Models;

namespace MediatRDemo.Library.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
{
    private readonly IDataAccess _dataAccess;

    public InsertPersonHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.AddToList(request.SurName, request.GivenName));
    }
}