Feature: Skill

As a Seller I want the feature to manage my skill details.
So that I am able to add, edit or delete my skill records.

@Order(1)
Scenario Outline: Add a skill
	Given I logged into the portal successfully
	When I click on tab Skills
	And I add '<Skill>' at '<Skill Level>'
	Then The '<Skill>' with '<Skill Level>'should be added successfully

	Examples: 
	| Skill  | Skill Level  |
	| C++    | Expert       |
	| Python | Beginner     |
	| 35372  | Beginner     |
	| #$%^&  | Intermediate |
	| R      | Intermediate |

@Order(2)
Scenario Outline: Edit a skill
	Given I logged into the portal successfully
	When I click on tab Skills
	And I edit last skill into '<Skill>' with '<Skill Level>'
	Then '<Skill>' with '<Skill Level>' should be edited successfully

	Examples:
	| Skill | Skill Level |
	| R     | Beginner    |

@Order(3)
Scenario Outline: Delete a skill
	Given I logged into the portal successfully
	When I click on tab Skills
	And I delete a '<Skill>'
	Then The '<Skill>' should be deleted accordingly
	
	Examples:
	| Skill  |
	| R      |
