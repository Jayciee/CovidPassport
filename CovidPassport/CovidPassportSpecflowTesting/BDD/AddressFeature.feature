Feature: AddressFeature
	As a user of the CovidPassport Website
	I want to be able to navigate through the Address page
	So that I can create, edit, review and delete Addresses

@read/get
Scenario: Click Details on first item
	Given I am on the Addresses page	
	When I click details on the first item 
	Then I should be brought to this URL "https://localhost:44312/Addresses/Details?id=1"