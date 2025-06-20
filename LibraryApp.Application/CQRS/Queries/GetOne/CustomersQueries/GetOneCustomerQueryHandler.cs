using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.CustomersQueries;

public class GetOneCustomerQueryHandler : IRequestHandler<GetOneCustomerQuery, Customer>
{
    private readonly IGenericRepository<Customer> _customerRepository;

    public GetOneCustomerQueryHandler(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Customer> Handle(GetOneCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetOneAsync(request.jmbg);
    }
}