Feature: Language

As a seller, I need a feature to manage my language details 
so that I can perform actions such as adding, editing, or deleting my language records

@Order(1)
Scenario Outline:Add a language
	Given I signed in the portal
	When I click on Languages tab
	And I add a '<language>' at a '<language level>'
	Then The '<language>' with '<language level>' should be added successfully

	Examples:
	| language | language level   |
	| Kannada  | Native/Bilingual |
	| G#*r$&Y  | Conversational   |
	|     1    | Fluent           |
	| English  | Basic            |
	

@Order(2)
Scenario Outline:Edit a language
	Given I signed in the portal
	When I click on Languages tab
	And I edit the last '<language>' at a different '<language level>'
	Then The '<language>' and '<language level>' should be edited successfully

	Examples:
	| language   | language level |
	|  English   | Fluent         |

@Order(3)
Scenario Outline:Delete a language
	Given I signed in the portal
	When I click on Languages tab 
	And I delete the last '<language>'
	Then The '<language>' should be deleted successfully

	Examples: 
	| language   |language level   |
	| English    |Fluent           |