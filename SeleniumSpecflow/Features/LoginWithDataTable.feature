Feature: LoginWithDataTable
	as a user
	I want to log into SauceDemo
	to gain access to the inventory page

@mytag
Scenario: Login to site using data tables
	Given the user is able to see the login portal
	When the user enters the following credentials
	| userName                | password     |
	| standard_user           | secret_sauce |
	Then I should be logged into the inventory page