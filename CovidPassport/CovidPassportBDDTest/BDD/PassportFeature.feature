Feature: Passport Feature
	As a user I want to be able to edit, view and delete
	everyone who covid passport has been approved

@update
Scenario: Edit a passport
	Given I am on the passport page
	When I click the edit button and I am directed to the edit page URL
	Then I select the save button then the user is directed to the passport page URL "https://localhost:44312/Passports"
	And The selected user details gets updated

@redirect
Scenario: Edit Passport Page
	Given I am on the passport page
	When I click the edit button
	Then I am directed to the edit page URL "https://localhost:44312/Passports/Edit"

@happy
Scenario: Back to list from edit page
	Given I am on the passport page
	When I click the edit button and I am directed to the edit page URL
	Then I click on the back to list brings me back to the approval list URL "https://localhost:44312/Passports"

@redirect
Scenario: View User's Passport Approval Details
	Given I am on the passport page
	When I click the details link
	Then I should be directed to the view details URL "https://localhost:44312/Passports/Details"

@happy
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
	When I click the delete link
	And I am directed to the delete confirmation page and I click the delete button 
	Then I am directed to passport approval URL "https://localhost:44312/Passports"

@happy
Scenario: Back to list from delete page
	Given I am on the passport page
	When I click the delete link and I am directed to the delete page
	And I click on the back to list
	Then I am brought me back to the approval list URL "https://localhost:44312/Passports"

@redirect
Scenario: NHS sites link
	Given I am on the passport page
	When I click the nhs sites link
	Then I must be directed to the selected page URL "https://www.nhs.uk/nhs-sites/"

@redirect
Scenario: NHS App link
	Given I am on the passport page
	When I click the nhs app link
	Then I must be directed to the selected page URL "https://www.nhs.uk/nhs-app/"

@redirect
Scenario: About us link
	Given I am on the passport page
	When I click the about us link
	Then I must be directed to the selected page URL "https://www.nhs.uk/about-us/"

@redirect
Scenario: Contact us link
	Given I am on the passport page
	When I click the contact us link
	Then I must be directed to the selected page URL "https://www.nhs.uk/contact-us/"

@redirect
Scenario: Site map link
	Given I am on the passport page
	When I click the site map link
	Then I must be directed to the selected page URL "https://www.nhs.uk/about-us/site-map/"

@redirect
Scenario: Accessibility statement link
	Given I am on the passport page
	When I click the accessibility statement link
	Then I must be directed to the selected page URL "https://www.nhs.uk/accessibility-statement/"

@redirect
Scenario: Policies link
	Given I am on the passport page
	When I click our policies link
	Then I must be directed to the selected page URL "https://www.nhs.uk/our-policies/"

@redirect
Scenario: Cookies link
	Given I am on the passport page
	When I click the cookie link
	Then I must be directed to the selected page URL "https://www.nhs.uk/our-policies/cookies-policy/"

@redirect
Scenario: Privacy link
	Given I am on the passport page
	When I click our privacy link
	Then I must be directed to the selected page URL "https://localhost:44312/Privacy"

@sad
Scenario: Missing Link Picture
	Given I am on the passport page
	When I click the edit button and I am directed to the edit page URL
	And The picture textbox is empty
	Then I get an error if the picture edit text is empty "Missing Picture Link"

@sad
Scenario: Missing Expiration Date
	Given I am on the passport page
	When I click the edit button and I am directed to the edit page URL
	And The expiration date textbox is empty
	Then I get an error if the expiration date edit text is empty "Missing Expiration Date"