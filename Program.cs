using LibraryApp.Middlewares;
using LibraryApp.MiddlewaresExtensionMethods;
using LibraryApp.Services;
using LibraryApp.Services.Implementations;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISpecialEditionBookService, SpecialEditionBookService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options=>options.AddDocumentTransformer((document,context,CancellationToken)=>
{
    document.Info.Title = "My Library App";
    document.Info.Contact = new OpenApiContact()
    {
        Email = "miljan@gmail.com",
        Name = "Miljan"
    };
    document.Info.Description = "This is my librarry app";
    return Task.CompletedTask;
}));


builder.Services.AddDbContext<LibraryDBContext>(options =>
{
    string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseSqlServer(ConnectionString);
});

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseRequestResponseLogging();

app.MapControllers();

app.Run();
