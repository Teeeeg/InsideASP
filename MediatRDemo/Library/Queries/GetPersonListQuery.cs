using MediatR;
using MediatRDemo.Library.Models;

namespace MediatRDemo.Library.Queries;

public record GetPersonListQuery() : IRequest<IEnumerable<PersonModel>>;
