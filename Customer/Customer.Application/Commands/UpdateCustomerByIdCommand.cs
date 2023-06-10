namespace Customer.Application.Commands;
public record UpdateCustomerByIdCommand(
        int Id,
        string FirstName,
        string LastName,
        string DateOfBirth,
        string PhoneNumber,
        string Email,
        string BankAccountNumber
    ): IRequest<Customer.Domain.Entities.CustomerAggregate.Customer?>;
