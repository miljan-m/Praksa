using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.AdminsQueries;


public class GetAllAdminQueryHandler : IRequestHandler<GetAllAdminsQuery, List<Admin>>
{
    

    private readonly IGenericRepository<Admin> _adminRepository;

    public GetAllAdminQueryHandler(IGenericRepository<Admin> adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<List<Admin>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
    {
        return await  _adminRepository.GetAllAsync();
    }
}