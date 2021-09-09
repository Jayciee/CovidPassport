Feature: Passport Feature
	As a user I want to be able to edit, view and delete
	everyone who covid passport has been approved

@update
Scenario: Edit a passport
	Given I am on the passport page
	When I click the edit button
	Then I am directed to the edit page URL "https://localhost:44312/Passports/Edit"
	And I select the save button then the user is directed to the passport page URL "https://localhost:44312/Passports"
	And The selected user details gets updated

@redirect
Scenario: Edit Passport Page
	Given I am on the passport page
	When I click the edit button
	Then I am directed to the edit page URL "https://localhost:44312/Passports/Edit"

@backtolist
Scenario: Back to list from edit page
	Given I am on the passport page
	When I click the edit button
	Then I am directed to the edit page URL "https://localhost:44312/Passports/Edit"
	And I click on the back to list brings me back to the approval list URL "https://localhost:44312/Passports"

@redirect
Scenario: View User's Passport Approval Details
	Given I am on the passport page
	When I click the details link
	Then I should be directed to the view details URL "https://localhost:44312/Passports/Details"

@backtolist
Scenario: Back to list from details page
	Given I am on the passport page
	When I click the details link it should be directed to the view details URL "https://localhost:44312/Passports/Details" 
	And I click the back to list link
	Then I should be redirected to the passport page URL "https://localhost:44312/Passports"

@redirect
Scenario: Delete confirmation page
	Given I am on the passport page
	When I click the delete link
	Then I must be directed to the delete confirmation page URL "https://localhost:44312/Passports/Delete"

@delete
Scenario: Delete user from passport approval list
	Given I am on the passport page
	When I click the delete link and I am directed to the delete confirmation page
	And I click the delete button 
	Then I am directed to passport approval URL "https://localhost:44312/Passports"

