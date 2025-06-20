using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateAdminCommands;

public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, Admin>
{
    private readonly IGenericRepository<Admin> _adminRepository;
    public UpdateAdminCommandHandler(IGenericRepository<Admin> adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Admin> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        return await _adminRepository.UpdateAsync(request.admin, request.adminId);

    }
}