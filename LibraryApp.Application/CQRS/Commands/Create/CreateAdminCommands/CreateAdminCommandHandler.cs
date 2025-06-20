using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.CreateAdminCommands;

public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Admin>
{
    private readonly IGenericRepository<Admin> _adminRepository;
    public CreateAdminCommandHandler(IGenericRepository<Admin> adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Admin> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        return await _adminRepository.CreateAsync(request.admin);

    }
}