Feature: PlaceOrder
	
Background:
Given the user has navigated to the demo site
And : Click on Login Icon
When : I enter testinguser1234 and 12345678
And : I click on the login button
Then : I am able to login
When I click on Samsung galaxy s6 mobile to add to cart
Then I am on details page of phone
When I click on Add to Cart
Then I can see an Alert of Product Added 
When I click on Cart in Home Page
Then I am able to see the Samsung galaxy s6 in the cart 

@mytag
Scenario Outline: Place Order of the Item
Given I am on details page of phone
When I click on Place Order
Then I am on purchase order details modal
When I enter details like <Name> <Country> <City> <CreditCard> <Month> <Year>
And I click on Purchase
Then The order is placed with correct details
When I click ok
Then The user is on Home Page  

Examples:
| Name     | Country | City | CreditCard          | Month | Year |
| TestUser | Country | City | xxxx-xxxx-xxxx-xxxx | 12    | 2999 |


	