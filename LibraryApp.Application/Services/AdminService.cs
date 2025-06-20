using LibraryApp.Application.Interfaces;
using LibraryApp.Mappers;
using LibraryApp.Application.CustomExceptions;
using MediatR;
using LibraryApp.Application.CQRS.Queries.GetOne.AdminsQueries;
using LibraryApp.Application.CQRS.Queries.GetAll.AdminsQueries;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteAdminCommands;
using LibraryApp.Application.CQRS.Commands.Update.UpdateAdminCommands;
using LibraryApp.Application.CQRS.Commands.Update.CreateAdminCommands;

namespace LibraryApp.Application.Services;


public class AdminService : IAdminService
{
    private readonly IGenericRepository<Admin> adminRepository;
    private readonly IMediator mediator;
    public AdminService(IGenericRepository<Admin> adminRepository, IMediator mediator)
    {
        this.adminRepository = adminRepository;
        this.mediator = mediator;
    }
    
    public async Task<IEnumerable<GetAdminsDTO>> GetAdmins()
    {
        var adminsList = await mediator.Send(new GetAllAdminsQuery());
        var admins = adminsList.Select(a => a.MapDomainEntitiesToDTO()).ToList();
        if (admins == null) throw new NotFoundException("Database is empty");
        return admins;
    }

    public async Task<GetAdminDTO> GetAdmin(string adminId)
    {
        var admin = await mediator.Send(new GetAdminQuery(adminId));
        if (admin == null) throw new AdminNotFoundException(adminId);
        var adminDto = admin.MapDomainEntityToDTO();
        return adminDto;
    }

    public async Task<bool> DeleteAdmin(string adminId)
    {
        return await mediator.Send(new DeleteAdminCommand(adminId));
    }

    public async Task<GetAdminDTO> UpdateAdmin(string adminId, UpdateAdminDTO adminDto)
    {
        var admin = await adminRepository.GetOneAsync(adminId);
        if (admin == null) throw new AdminNotFoundException(adminId);
        var updatedAdmin = await mediator.Send(new UpdateAdminCommand(adminId,adminDto.MapDtoToDomainEntity(admin)));
        return updatedAdmin.MapDomainEntityToDTO();
    }

    public async Task<Admin> CreateAdmin(CreateAdminDTO adminDto)
    {
        var admin = adminDto.MapDtoToDomainEntity();
        return await mediator.Send(new CreateAdminCommand(admin));
    }
}