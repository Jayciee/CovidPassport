Feature: PassportApprovalFeature
	As a Healthcare Centre, I want to see all the people who have received two jabs, 
	so I can see who is waiting for passport approval.


#two steps
@good
Scenario: Approve a passport
	Given I am on the Passport Approval Page
	When I click on Passport Approval button
	Then I should be directed to a approval confirmation page URL "https://localhost:44312/Approval/Edit?id="
	And on clicking the confirm approve redirectes user to the approve URL "https://localhost:44312/Approval"