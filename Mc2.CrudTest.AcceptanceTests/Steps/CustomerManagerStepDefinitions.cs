using Mc2.CrudTest.Presentation.Client.Services;
using Mc2.CrudTest.Presentation.Client.Services.Contracts;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using static Io.Cucumber.Messages.TestResult.Types;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerManagerStepDefinitions
    {
        private readonly HttpClient _httpClient;

        public CustomerManagerStepDefinitions(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private ICustomerService? customerService;
        private IEnumerable<CustomerDto>? customerList;

        [Given(@"we are in customers page")]
        public void GivenWeAreInCustomersPage()
        {
            customerService = new CustomerService(_httpClient);
        }

        [When(@"we request the list")]
        public async void WhenWeRequestTheList()
        {
            customerList = await customerService!.GetCustomers();
        }

        [Then(@"customer list should be returned")]
        public void ThenCustomerListShouldBeReturned()
        {
            Assert.IsNotNull(customerList);
        }
    }
}
