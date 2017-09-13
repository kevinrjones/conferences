Feature: List Todos
	In order to see what I need to do
	As a forgetful person
	I want to see the list of outstanding todos

@mytag
Scenario: See todo list
	Given I am logged in
	When When I navigate to the home page
	Then I see the list of todos on the page
