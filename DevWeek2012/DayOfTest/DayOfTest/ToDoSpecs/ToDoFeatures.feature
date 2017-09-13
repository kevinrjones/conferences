Feature: Display ToDo List
	In order to know what to do
	As an old person
	I want to be shown a list of todos

@mytag
Scenario: Show todo list
	Given I am logged in
	When I press browse to the home page
	Then the todo list should be displayed
