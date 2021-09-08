Feature: AddressFeature
	As a user of the CovidPassport Website
	I want to be able to navigate through the Address page
	So that I can create, edit, review and delete Addresses

@happy
Scenario: First time entering Addresses
	Given I am on the Addresses page
	Then I should see addresses on the screen

@redirect
Scenario: Click Edit on first item
	Given I am on the Addresses page
	When I click edit on the first item
	Then I should be redirected to address URL "https://localhost:44312/Addresses/Edit?id=1"


@redirect
Scenario: Click Details on first item
	Given I am on the Addresses page	
	When I click details on the first item 
	Then I should be redirected to address URL "https://localhost:44312/Addresses/Details?id=1"
