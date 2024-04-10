Feature: LogIn

Login functionality

Background: 
Given I am on the login page



@Locked
Scenario: Locked user can't login
	When I fill the credentials 
	And Click the login button
	Then I can see the error message "Sorry, this user has been locked out."



@Performance
Scenario: Performance glitch user can login but slowly
	When I fill the credentials 
	And Click the login button
	Then I can see that there is a delay for loading the page

Examples: 
| productName                     |
| add-to-cart-sauce-labs-backpack |

@UsernameEmpty
Scenario: User receives error when trying to login with empty username field
	When I fill the credentials 
	And Click the login button
	Then I can see the "Username is required" message


