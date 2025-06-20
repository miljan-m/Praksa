using LibraryApp.Application.Services;
using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.CustomerQueries;


public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
{
    private readonly IGenericRepository<Customer> _customerRepository;

    public GetAllCustomersQueryHandler(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetAllAsync();
    }
}
