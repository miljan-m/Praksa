using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.AdminsQueries;


public class HandleGetAdminQuery : IRequestHandler<GetAdminQuery,Admin>
{

    private readonly IGenericRepository<Admin> _adminRepository;

    public HandleGetAdminQuery(IGenericRepository<Admin> adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Admin> Handle(GetAdminQuery request, CancellationToken cancellationToken)
    {
        return await _adminRepository.GetOneAsync(request.Id);
    }
}

   