using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.AdminsQueries;

public record GetAdminQuery(string Id) : IRequest<Admin>;