using MediatR;
using MediatRDemo.Library.Models;
using MediatRDemo.Library.Queries;

namespace MediatRDemo.Library.Handlers;

class GetPersonByIdHandlder : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IMediator _mediator;

    public GetPersonByIdHandlder(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var personList = await _mediator.Send(new GetPersonListQuery());
        PersonModel? person = personList.FirstOrDefault(p => p.Id == request.Id);

        return person;
    }
}