Feature: LocationFeature
	As a user of the CovidPassport Website
	I want to be able to navigate through the Locations page
	So that I can create, edit, review and delete Locations

@create
Scenario: Click Create button
Given I am on the locations page
When I click the create location button
Then I should be redirected to location URL "https://localhost:44312/HealthCentres/Create"

@create
Scenario: Create a location
Given I am on the create location page
When I fill out the form with the options: 
| address | name        |
| 4       | Test Centre |
And I press the create location button
Then I should be redirected to location URL "https://localhost:44312/HealthCentres"

@create-sad-fail
Scenario: Create a location with existing ID
Given I am on the create location page
When I fill out the ID with an existing location ID
And I fill out the centre name with: "Random Centre"
And I press the create location button
Then id error message should be: "ID already exists"

@create-sad
Scenario: Create location form with no ID or Name input
Given I am on the create location page
When I press the create location button
Then id error message should be: "The HealthCentreId field is required."
And name error message should be: "Name of Establishment missing"

@create-sad
Scenario: Create location form with bad name
Given I am on the create location page
When I fill out the centre name with: "test"
And I press the create location button
Then name error message should be: "The field Name must match the regular expression '^[A-Z][A-Za-z\s]*$'."

#TEST MEANT TO FAIL BUT DOESN'T, CAN'T RETRIEVE THE TEXT FROM FIELD
@create
Scenario: Typing text into ID field doesn't allow
Given I am on the create location page
When I fill out the ID with a: "text"
Then ID field should be empty

@edit
Scenario: Click Edit button on first location
Given I am on the locations page
When I click the edit location button
Then I should be redirected to location URL "https://localhost:44312/HealthCentres/Edit?id=1"

@edit
Scenario: Changing address in the edit page
Given I am on the locations page
When I click the edit location button
And I change the address to: "3"
And I save the changes
Then I should be redirected to location URL "https://localhost:44312/HealthCentres"
And the address shows: "823 Chimera Close , Woodsville"

@edit
Scenario: Changing location name in the edit page
Given I am on the locations page
When I click the edit location button
And I change the location name to: "Chris Pokemon Centre"
And I save the changes
Then I should be redirected to location URL "https://localhost:44312/HealthCentres"
And the location name shows: "Chris Pokemon Centre"


@delete
Scenario: Delete new location
Given I am on the locations page
When I delete the new location
And I confirm deletion 
Then I should be redirected to location URL "https://localhost:44312/HealthCentres"
And the last name on location list should not be "Test Centre"



@details
Scenario: Click Detail button on first location
Given I am on the locations page
When I click the detail location button
Then I should be redirected to location URL "https://localhost:44312/HealthCentres/Details?id=1"

@redirect
Scenario: Click Home button
Given I am on the locations page
When I click the home button from locations
Then I should be redirected to location URL "https://localhost:44312"

@redirect
Scenario: Click Location button in Health Centres dropdown
Given I am on the locations page
When I click the option from the Health Centre Dropdown: "1"
Then I should be redirected to location URL "https://localhost:44312/HealthCentres"

@redirect
Scenario: Click Passports button in Health Centres dropdown
Given I am on the locations page
When I click the option from the Health Centre Dropdown: "2"
Then I should be redirected to location URL "https://localhost:44312/Passports"

@redirect
Scenario: Click Approval button in Health Centres dropdown
Given I am on the locations page
When I click the option from the Health Centre Dropdown: "3"
Then I should be redirected to location URL "https://localhost:44312/Approval"

@redirect
Scenario: Click User Details button in Users dropdown
Given I am on the locations page
When I click the option from the Users Dropdown: "1"
Then I should be redirected to location URL "https://localhost:44312/Persons"

@redirect
Scenario: Click Addresses button in Users dropdown
Given I am on the locations page
When I click the option from the Users Dropdown: "2"
Then I should be redirected to location URL "https://localhost:44312/Addresses"

@redirect
Scenario: Click Privacy button
Given I am on the locations page
When I click the privacy button from locations
Then I should be redirected to location URL "https://localhost:44312/Privacy"

