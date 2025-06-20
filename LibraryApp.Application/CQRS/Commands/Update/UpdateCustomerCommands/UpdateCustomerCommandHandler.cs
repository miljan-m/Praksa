using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateCustomerCommands;


public class UpdateCustomerCommandsHandler : IRequestHandler<UpdateCustomerCommand,Customer>
{
    private readonly IGenericRepository<Customer> _customerRepository;

    public UpdateCustomerCommandsHandler(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
        
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerRepository.UpdateAsync(request.cutomer, request.jmbg);

    }

}

