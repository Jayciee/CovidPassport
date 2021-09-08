Feature: LocationFeature
	As a user of the CovidPassport Website
	I want to be able to navigate through the Locations page
	So that I can create, edit, review and delete Locations

@create
Scenario: Click Create to add new location
Given I am on the locations page
When I click the create button
Then I should be redirected to location URL "https://localhost:44312/HealthCentres/Create"