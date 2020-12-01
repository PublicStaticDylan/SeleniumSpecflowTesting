Feature: LoginWithMultipleUsers
	as a user
	I want to log into SauceDemo
	to gain access to the inventory page

@mytag
Scenario: Login to site with several login credentials
	Given the user is able to see the login portal
	When the user enters <userName> and <password>
	Then I should be logged into the inventory page
Examples: 
	| userName                | password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |