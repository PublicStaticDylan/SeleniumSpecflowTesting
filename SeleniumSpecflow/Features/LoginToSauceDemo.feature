Feature: LoginSauceDemo
	as a user
	I want to log into SauceDemo
	to gain access to the inventory page

@smokeTest
Scenario: Login to site
	Given the user is able to see the login portal
	When user enters 'standard_user' and 'secret_sauce'
	Then I should be logged into the inventory page