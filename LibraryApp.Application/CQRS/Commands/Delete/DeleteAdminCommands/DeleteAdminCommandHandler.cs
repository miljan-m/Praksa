using System.Reflection.Metadata.Ecma335;
using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteAdminCommands;

public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, bool>
{
    private readonly IGenericRepository<Admin> _adminRepository;
    public DeleteAdminCommandHandler(IGenericRepository<Admin> adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<bool> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
       return await _adminRepository.DeleteAsync(request.AdminId);      
    }
}