using MediatR;
using MediatRDemo.Library.Models;

namespace MediatRDemo.Library.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;