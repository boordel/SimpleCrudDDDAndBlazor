using Mc2.CrudTest.Presentation.Client.Services.Contracts;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Mc2.CrudTest.Presentation.Client.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CustomerDto>?> GetCustomers() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<CustomerDto>>("Customer");

    public async Task<CustomerDto?> GetCustomerById(int id) =>
        await _httpClient.GetFromJsonAsync<CustomerDto>($"Customer/{id}");

    public async Task<bool> AddCustomer(CustomerDto customer)
    {
        var result = await _httpClient.PostAsJsonAsync("Customer", customer);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCustomer(CustomerDto customer)
    {
        var result = await _httpClient.PutAsJsonAsync($"Customer/{customer.id}", customer); 
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var result = await _httpClient.DeleteAsync($"Customer/{id}");
        return result.IsSuccessStatusCode;
    }
}
