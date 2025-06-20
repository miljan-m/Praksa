using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateCustomerCommands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly IGenericRepository<Customer> _customerRepository;

    public CreateCustomerCommandHandler(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerRepository.CreateAsync(request.customer);
    }
}