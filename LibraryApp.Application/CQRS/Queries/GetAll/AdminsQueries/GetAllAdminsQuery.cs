using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.AdminsQueries;

public record GetAllAdminsQuery : IRequest<List<Admin>>;