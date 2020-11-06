Feature: AddToCart
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background:
Given the user has navigated to the demo site
And : Click on Login Icon
When : I enter testinguser1234 and 12345678
And : I click on the login button
Then : I am able to login

Scenario Outline: Add Items to Cart
	Given The user is on Home Page 
	When I click on <ProductName> mobile to add to cart
	Then I am on details page of phone
	And I am able to check the product description
	When I click on Add to Cart
	Then I can see an Alert of Product Added 
	When I click on Cart in Home Page
	Then I am able to see the <ProductName> in the cart 
	When I click on delete item of cart
	Then I am not able to see the <ProductName> in the cart 

Examples:
| ProductName       |
| Samsung galaxy s6 |   
| Nokia lumia 1520 | 
| Nexus 6 | 
