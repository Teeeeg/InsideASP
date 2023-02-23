using MediatR;
using MediatRDemo.Library.Commands;
using MediatRDemo.Library.DataAccess;
using MediatRDemo.Library.Models;
using MediatRDemo.Library.Queries;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataAccess, PersonDataAccess>()
.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/GetAll", async () =>
{
    var mediator = app.Services.GetRequiredService<IMediator>();
    return await mediator.Send(new GetPersonListQuery());
});

app.MapGet("/GetById/{Id}", async ([FromRoute] int Id) =>
{
    var mediator = app.Services.GetRequiredService<IMediator>();
    return await mediator.Send(new GetPersonByIdQuery(Id));
});

app.MapPost("/Insert", async ([FromBody] PersonModel person) =>
{
    var mediator = app.Services.GetRequiredService<IMediator>();
    return await mediator.Send(new InsertPersonCommand(person.SurName, person.GivenName));
});

app.Run();
