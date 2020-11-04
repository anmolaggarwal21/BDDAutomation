Feature: Login functionality

@login @critical



Scenario: Login

Given the user has navigated to the demo site
And : Click on Login Icon
When : I enter testinguser1234 and 12345678
And : I click on the login button
Then : I am able to login

Scenario Outline: Login For Multiple Users

Given the user has navigated to the demo site
And : Click on Login Icon
When : I enter <username> and <password>
And : I click on the login button
Then : I am able to login
Examples:
| username     | password |
| testinguser1234  | 12345678 |
| testuser1234 | password |



