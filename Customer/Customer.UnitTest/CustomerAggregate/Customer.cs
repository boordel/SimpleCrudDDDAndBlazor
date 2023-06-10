using System.Text.Json.Serialization;

namespace Customer.Domain.Entities.CustomerAggregate;
public class Customer: Entity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    [JsonConstructorAttribute]
    public Customer(string firstName, string lastName, string dateOfBirth, string phoneNumber, string email, 
        string bankAccountNumber)
    {
        // Cretical arguments must not be null or empty
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentNullException(nameof(lastName));
        if (string.IsNullOrEmpty(dateOfBirth))
            throw new ArgumentNullException(nameof(dateOfBirth));
        if (string.IsNullOrEmpty(phoneNumber))
            throw new ArgumentNullException(nameof(phoneNumber));
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrEmpty(bankAccountNumber))
            throw new ArgumentNullException(nameof(bankAccountNumber));

        // Email must be in valid format
        if (!CommonArgumentValidation.IsValidEmail(email))
            throw new ArgumentException("Email must be in valid format", nameof(email));

        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }
    public Customer(int id, string firstName, string lastName, string dateOfBirth, string phoneNumber, 
        string email, string bankAccountNumber):
        this(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber)
    {
        SetId(id);
    }
}
