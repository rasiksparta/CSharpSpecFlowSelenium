Feature: BBCLogin
	In order to login into my account
	As a user
	I want to be able to see my account page

@BBCLogin
Scenario: Invalid password
	Given I am on the login page
	And I have entered a valid username
	And I have entered a invalid password
	When I press login 
	Then I should see the appropriate error
