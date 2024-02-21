Feature: SignIn

As a Seller, I desire the ability to include my profile details.
This will enable individuals seeking specific skills to view my information.

@SignIn
Scenario: SignIn
	Given I signed into the portal successfully
	Then I am able to see my profile page