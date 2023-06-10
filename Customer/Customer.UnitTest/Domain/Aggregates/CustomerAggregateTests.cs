namespace Customer.UnitTest.Domain.Aggregates;
public class CustomerAggregateTests
{
    [Fact]
    public void Create_ShouldCreateCustomer()
    {
        // Arrange
        var customerId = 1;
        var firstName = "Mahmood";
        var lastName = "Sabzehi";
        var dateOfBirth = "25-08-79";
        var phoneNumber = "989122085789";
        var email = "boordel@outlook.com";
        var bankAccountNumber = "123-445-445";

        // Act
        var customer = new Customer.Domain.Entities.CustomerAggregate.Customer(
            customerId,
            firstName,
            lastName,
            dateOfBirth,
            phoneNumber,
            email,
            bankAccountNumber
            );

        // Assert
        Assert.NotNull(customer);
    }

    [Theory]
    [InlineData("firstName", "", "Sabzehi", "25-08-79", "98912", "b@o.com", "123-123-123")]
    [InlineData("lastName", "Mahmood", "", "25-08-79", "98912", "b@o.com", "123-123-123")]
    [InlineData("dateOfBirth", "Mahmood", "Sabzehi", "", "98912", "b@o.com", "123-123-123")]
    [InlineData("phoneNumber", "Mahmood", "Sabzehi", "25-08-79", "", "b@o.com", "123-123-123")]
    [InlineData("email", "Mahmood", "Sabzehi", "25-08-79", "98912", "", "123-123-123")]
    [InlineData("bankAccountNumber", "Mahmood", "Sabzehi", "25-08-79", "98912", "b@o.com", "")]
    public void Create_ShouldNotHaveNullArguments(string paramName, string firstName, string lastName, 
        string dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        // Arrange 
        var customerId = 1;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(paramName, () => new Customer.Domain.Entities.CustomerAggregate.Customer(
            customerId,
            firstName,
            lastName,
            dateOfBirth,
            phoneNumber,
            email,
            bankAccountNumber
            ));
    }

    [Theory]
    [InlineData("boordeloutlook.com")]
    [InlineData("boordel@outlook")]
    [InlineData("abc")]
    public void Create_ShouldEmailBeInValidFormat(string email)
    {
        // Arrange
        var customerId = 1;
        var firstName = "Mahmood";
        var lastName = "Sabzehi";
        var dateOfBirth = "25-08-79";
        var phoneNumber = "989122085789";
        var bankAccountNumber = "123-445-445";

        var paramName = "email";

        // Act

        // Assert
        Assert.Throws<ArgumentException>(paramName, () => new Customer.Domain.Entities.CustomerAggregate.Customer(
            customerId,
            firstName,
            lastName,
            dateOfBirth,
            phoneNumber,
            email,
            bankAccountNumber
            ));
    }
}
