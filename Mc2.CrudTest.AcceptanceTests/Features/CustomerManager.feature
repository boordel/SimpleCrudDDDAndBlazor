Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@CustomerList
Scenario: When we request for customer list, we must get the list 
	Given we are in customers page
	When we request the list
	Then customer list should be returned