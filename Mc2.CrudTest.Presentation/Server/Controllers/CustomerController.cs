using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Mc2.CrudTest.Presentation.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private HttpClient CreateClientHttp()
    {
        return _httpClientFactory.CreateClient("CustomerService");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
    {
        var client = CreateClientHttp();
        try
        {
            var result = await client.GetAsync("api/Customer");
            if (result.IsSuccessStatusCode)
            {
                using var contentStream = await result.Content.ReadAsStreamAsync();
                var customerList = await JsonSerializer.DeserializeAsync<IEnumerable<CustomerDto>>(contentStream);
                return Ok(customerList);
            }
            else
                return NotFound();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> Get(int id)
    {
        var result = await CreateClientHttp().GetAsync($"api/Customer/{id}");
        if (result.IsSuccessStatusCode)
        {
            using var contentStream = await result.Content.ReadAsStreamAsync();
            var customer = await JsonSerializer.DeserializeAsync<CustomerDto>(contentStream);
            return Ok(customer);
        }
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Post([FromBody] CustomerDto data)
    {
        var result = await CreateClientHttp().PostAsJsonAsync("api/Customer", data);
        if (result.IsSuccessStatusCode)
        {
            return Ok(true);
        }
        else
            return BadRequest(false);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Put(int id, [FromBody] CustomerDto data)
    {
        var result = await CreateClientHttp().PutAsJsonAsync($"api/Customer/{id}", data);
        if (result.IsSuccessStatusCode)
        {
            return Ok(true);
        }
        else
            return BadRequest(false);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await CreateClientHttp().DeleteAsync($"api/Customer/{id}");
        if (result.IsSuccessStatusCode)
        {
            return Ok(true);
        }
        else
            return BadRequest(false);
    }
}
