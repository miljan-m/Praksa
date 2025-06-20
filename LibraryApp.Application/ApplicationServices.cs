using Microsoft.Extensions.DependencyInjection;
using LibraryApp.Application.Services;
using LibraryApp.Application.Interfaces;
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

        return services;
    }
}