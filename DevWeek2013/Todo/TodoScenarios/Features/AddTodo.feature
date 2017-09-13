Feature: AddTodo
	As a user
	In order to know what I should be doing
	I want to be able to add a todo

@mytag
Scenario: Add a todo when authenticated
	Given I am authenticated
	And I have entered a title
	And I have entered a date
	When I add the todo
	Then the todo should be added to the list displayed 

Scenario: Delete
	Given I have a todo
	When I remove the todo
	Then the todo should be removed from the list displayed 
	
