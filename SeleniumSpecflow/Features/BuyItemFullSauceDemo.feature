Feature: BuyItemFullSauceDemo
	As a user
	I want to purchase an item from the store's inventory

@smokeTest
Scenario: User buys a single product from the site
	Given The user is able to log into the site with 'standard_user' and 'secret_sauce'
	And The user adds an item to their cart
	And The user proceeds to the cart page
	And The user proceeds to the checkout page
	And The user enters <firstName> and <lastName> and <postCode> and continues to the checkout overview
	And The user clicks finish
	Then The purchase should have been successfully purchased
Examples: 
| firstName | lastName   | postCode |
| Jimmy     | Jones      | SK9 3CD  |
| Horatio   | Henry      | M10 4HD  |
| Heather   | Brown      | LL57 1KP |
| Samanther | Winchester | P40 5TK  |