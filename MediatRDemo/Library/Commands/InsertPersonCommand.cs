using MediatR;
using MediatRDemo.Library.Models;

namespace MediatRDemo.Library.Commands;

public record InsertPersonCommand(string SurName, string GivenName) : IRequest<PersonModel>;