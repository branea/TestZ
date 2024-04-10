Feature: CheckoutPage

A short summary of the feature


Background: 
Given I am on the login page

@Standard
Scenario: User can add product to the cart and checkout
	And I fill the credentials 
	And Click the login button
	When I add a '<productName>' to card
	And I do the checkout
	And I fill in all the Checkout Information fields
	And I click on the finish button
	Then I can see successfully order message
Examples: 
|productName|
| add-to-cart-sauce-labs-backpack   |

@Standard @EmptyCheckoutLastName
Scenario: Problem user can login
	And I fill the credentials 
	And Click the login button
	When I add a '<product>' to card
	And I do the checkout
	And I fill in all the Checkout Information fields
	Then I can see the error message "Last Name is required" popped for missing value for Last Name field
Examples: 
| product                         |
| add-to-cart-sauce-labs-backpack |