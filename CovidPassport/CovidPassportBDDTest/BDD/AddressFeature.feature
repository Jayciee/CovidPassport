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
	When I click edit on the first address
	Then I should be redirected to address URL "https://localhost:44312/Addresses/Edit?id=1"


@redirect
Scenario: Click Details on first item
	Given I am on the Addresses page	
	When I click details on the first address 
	Then I should be redirected to address URL "https://localhost:44312/Addresses/Details?id=1"

@create
Scenario: Creating a new address
	Given I am on the Addresses page
	When I click the create new address hyperlink
	And I am redirected to address URL "https://localhost:44312/Addresses/Create"
	And I enter the details <id>, <house number>, <street name>, <city name>, <postcode id>
	And I click the create button on the create address page
	Then I should be redirected back to the address page
	And My created user should appear with id <id>
Examples: 
| id | house number | street name | city name | postcode id |
| 10 | 12           | TestStreet  | Test City | TE27 1DE    |


@defect
Scenario: Creating a new address - Defect
	Given I am on the Addresses page
	When I click the create new address hyperlink
	And I am redirected to address URL "https://localhost:44312/Addresses/Create"
	And I enter the details <id>, <house number>, <street name>, <city name>, <postcode id>
	And I click the create button on the create address page
	Then I should be redirected back to the address page
	And My created user should appear with id <id>
Examples: 
| id | house number | street name | city name | postcode id |
| 10 | 12           | Test Street  | Test City | TE27 1DE   |

@delete
Scenario: Deleting new address
	Given I am on the Addresses page
	When I click delete address on my created item
	And I click the delete button again on the address deletion confirmation page
	Then The address should be removed

@edit
Scenario: Editing the first address
	Given I am on the Addresses page
	When I click edit on the first address
	And I edit the address to <house number>, <street name>, <city name>, <postcode id>
	And I click the save button on the edit address page
	Then I should see the first item with the updated details <house number>, <street name>, <city name>, <postcode id>

Examples: 
| house number | street name   | city name  | postcode id |
| 64           | Zoo lane      | Birkenhead | PO19 6YQ    |
| 55           | Eastside Lane | Birkenhead | PO19 6YQ    | 
