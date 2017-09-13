Feature: Add new Todo Item
	In order to see what needs doing
	As a user
	I want to be able to add a new todo

@mytag
Scenario: Add a new todo
	Given I have entered a title
	And I have entered the todo entry
	When I press create
	Then the todo is shown on the results page
