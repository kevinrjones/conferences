Feature: Movie
	I want to be able to list movies
@mytag
Scenario: List movies
	Given I have movies in the database
	When I press list the movies
	Then the correct number of movies should be shown

