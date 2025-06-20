using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteCustomerCommands;


public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{

    private readonly IGenericRepository<Customer> _customerRepository;

    public DeleteCustomerCommandHandler(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerRepository.DeleteAsync(request.jmbg);
    }
}