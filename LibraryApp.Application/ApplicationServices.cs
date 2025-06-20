using Microsoft.Extensions.DependencyInjection;
using LibraryApp.Application.Services;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.CQRS.Queries.GetOne.AdminsQueries;
using LibraryApp.Application.CQRS.Queries.GetAll.AdminsQueries;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteAdminCommands;
using LibraryApp.Application.CQRS.Commands.Update.UpdateAdminCommands;
using LibraryApp.Application.CQRS.Commands.Update.CreateAdminCommands;
using LibraryApp.Application.CQRS.Queries.GetOne.AuthorQueries;
using LibraryApp.Application.CQRS.Queries.GetAll.AuthorQueries;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteAuthorCommands;
using LibraryApp.Application.CQRS.Commands.Create.CreateAuthorCommands;
using LibraryApp.Application.CQRS.Commands.Update.UpdateAuthorCommands;
using LibraryApp.Application.CQRS.Queries.GetAll.BookQueries;
using LibraryApp.Application.CQRS.Queries.GetOne.BookQueries;
using LibraryApp.Application.CQRS.Commands.Update.UpdateBookCommands;
using LibraryApp.Application.CQRS.Commands.Create.CreateBookCommands;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteBookCommands;
using LibraryApp.Application.CQRS.Queries.GetAll.CustomerQueries;
using LibraryApp.Application.CQRS.Queries.GetOne.CustomersQueries;
using LibraryApp.Application.CQRS.Commands.Update.UpdateCustomerCommands;
using LibraryApp.Application.CQRS.Commands.Create.CreateCustomerCommands;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteCustomerCommands;
using LibraryApp.Application.CQRS.Commands.Update.UpdateSpecialEditionBookCommands;
using LibraryApp.Application.CQRS.Queries.GetAll.SpecialEditionBookQueries;
using LibraryApp.Application.CQRS.Commands.Create.CreateSpecialEditionBookCommands;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteSpecialEditionBook;
using LibraryApp.Application.CQRS.Queries.GetOne.SpecialEditionBookQueries;

namespace LibraryApp.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ISpecialEditionBookService, SpecialEditionBookService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IAuthorService, AuthorService>();
        
        services.AddMediatR(cfg =>
                            cfg.RegisterServicesFromAssembly(typeof(ApplicationServices).Assembly));

        return services;
    }
}