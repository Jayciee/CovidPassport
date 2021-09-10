using CovidPassportBDDTest.libs;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace CovidPassportBDDTest.BDD
{
    [Binding]
    public class PassportFeatureSteps
    {
        private CovidPassport_Website<ChromeDriver> _website = new CovidPassport_Website<ChromeDriver>();

        [Given(@"I am on the passport page")]
        public void GivenIAmOnThePassportPage()
        {
            _website.PassportPage.VisitPassportPage();
        }

        [When(@"I click the edit button")]
        public void WhenIClickTheEditButton()
        {
            _website.PassportPage.ClickEdit();
        }

        [When(@"I click the details link")]
        public void WhenIClickTheDetailsLink()
        {
            _website.PassportPage.ClickDetailsButton();
        }

        [When(@"I click the details link it should be directed to the view details URL ""(.*)""")]
        public void WhenIClickTheDetailsLinkItShouldBeDirectedToTheViewDetailsURL(string URL)
        {
            _website.PassportPage.ClickDetailsButton();
        }

        [When(@"I click the back to list link")]
        public void WhenIClickTheBackToListLink()
        {
            _website.PassportPage.ClickBackToListDetails();
        }

        [When(@"I click the delete link")]
        public void WhenIClickTheDeleteLink()
        {
            _website.PassportPage.ClickDeleteLink();
        }

        [When(@"I click the edit button and I am directed to the edit page URL")]
        public void WhenIClickTheEditButtonAndIAmDirectedToTheEditPageURL()
        {
            _website.PassportPage.ClickEdit();
        }

        [When(@"I am directed to the delete confirmation page and I click the delete button")]
        public void WhenIClickTheDeleteButton()
        {
            _website.PassportPage.ClickDeleteButton();
        }

        [When(@"I click the delete link and I am directed to the delete page")]
        public void WhenIClickTheBackToListLinkAndIAmDirectedToTheDeletePage()
        {
            _website.PassportPage.ClickDeleteLink();
        }

        [When(@"I click the nhs sites link")]
        public void WhenIClickTheNhsSitesLink()
        {
            _website.PassportPage.ClickNHSSitesButton();
        }

        [When(@"I click the nhs app link")]
        public void WhenIClickTheNhsAppLink()
        {
            _website.PassportPage.ClickNHSAppButton();
        }

        [When(@"I click the about us link")]
        public void WhenIClickTheAboutUsLink()
        {
            _website.PassportPage.ClickAboutUsButton();
        }

        [When(@"I click the contact us link")]
        public void WhenIClickTheContactUsLink()
        {
            _website.PassportPage.ClickContactUsButton();
        }

        [When(@"I click the site map link")]
        public void WhenIClickTheSiteMapLink()
        {
            _website.PassportPage.ClickSiteMapButton();
        }

        [When(@"I click the accessibility statement link")]
        public void WhenIClickTheAccessibilityStatementLink()
        {
            _website.PassportPage.ClickAccessibilityStatementButton();
        }

        [When(@"I click our policies link")]
        public void WhenIClickOurPoliciesLink()
        {
            _website.PassportPage.ClickPolicyButton();
        }

        [When(@"I click the cookie link")]
        public void WhenIClickTheCookieLink()
        {
            _website.PassportPage.ClickCookieButton();
        }

        [When(@"I click our privacy link")]
        public void WhenIClickOurPrivacyLink()
        {
            _website.PassportPage.ClickPrivacyButton();
        }

        [Then(@"I must be directed to the selected page URL ""(.*)""")]
        public void ThenIMustBeDirectedToTheSelectedPageURL(string URL)
        {
            Assert.That(_website.PassportPage.GetURLFromLink(_website.PassportPage.GetNHSAppLinkURL()), Is.EqualTo(URL));
        }


        [Then(@"I am directed to passport approval URL ""(.*)""")]
        public void ThenIAmDirectedToPassportApprovalURL(string URL)
        {
            Assert.That(_website.Driver.Url, Is.EqualTo(URL));
        }


        [Then(@"I must be directed to the delete confirmation page URL ""(.*)""")]
        public void ThenIMustBeDirectedToTheDeleteConfirmationPageURL(string URL)
        {
            Assert.That(_website.Driver.Url, Does.Contain(URL));
        }


        [Then(@"I should be redirected to the passport page URL ""(.*)""")]
        public void ThenIShouldBeRedirectedToThePassportPageURL(string URL)
        {
            Assert.That(_website.Driver.Url, Does.Contain(URL));
        }


        [Then(@"I should be directed to the view details URL ""(.*)""")]
        public void ThenIShouldBeDirectedToTheViewDetailsURL(string URL)
        {
            Assert.That(_website.Driver.Url, Does.Contain(URL));
        }


        [Then(@"I am directed to the edit page URL ""(.*)""")]
        public void ThenIAmDirectedToTheEditPageURL(string URL)
        {
            Assert.That(_website.Driver.Url, Does.Contain(URL));
        }
        
        [Then(@"I select the save button then the user is directed to the passport page URL ""(.*)""")]
        public void ThenISelectTheSaveButtonThenTheUserIsDirectedToThePassportPageURL(string URL)
        {
            _website.PassportPage.ClickSave();
            Assert.That(_website.Driver.Url, Is.EqualTo(URL));
        }
        
        [Then(@"The selected user details gets updated")]
        public void ThenTheSelectedUsersDetailsGetsUpdated()
        {
            Assert.That(_website.PassportPage.ApprovedPassportListCount, Is.EqualTo(_website.PassportPage.ApprovedPassportListCount()));
        }

        [Then(@"I click on the back to list brings me back to the approval list URL ""(.*)""")]
        public void ThenIClickOnTheBackToListBringsMeBackToTheApprovalListURL(string URL)
        {
            Assert.That(_website.Driver.Url, Is.EqualTo(URL));
        }

        [When(@"I click on the back to list")]
        public void WhenIClickOnTheBackToList()
        {
            _website.PassportPage.ClickBackToListDelete();
        }

        [Then(@"I am brought me back to the approval list URL ""(.*)""")]
        public void ThenIAmBroughtMeBackToTheApprovalListURL(string URL)
        {
            _website.PassportPage.ClickBackToListEdit();
            Assert.That(_website.Driver.Url, Is.EqualTo(URL));
        }

        [When(@"The picture textbox is empty")]
        public void WhenThePictureTextboxIsEmpty()
        {
            _website.PassportPage.ClearPicture();
            _website.PassportPage.ClickSave();
        }

        [When(@"The expiration date textbox is empty")]
        public void WhenTheExpirationDateTextboxIsEmpty()
        {
            _website.PassportPage.ClearExpriationDate();
            _website.PassportPage.ClickSave();
        }

        [Then(@"I get an error if the expiration date edit text is empty ""(.*)""")]
        public void ThenIGetAnErrorIfTheExpirationDateEditTextIsEmpty(string errorText)
        {
            Assert.That(_website.PassportPage.GetExpirationDateErrorIsDisplayed, Is.True);
            Assert.That(_website.PassportPage.GetExpirationDateErrorText, Is.EqualTo(errorText));
        }

        [Then(@"I get an error if the picture edit text is empty ""(.*)""")]
        public void ThenIGetAnErrorIfThePictureEditTextIsEmpty(string errorText)
        {
            Assert.That(_website.PassportPage.GetPictureMissingErrorIsDisplayed, Is.True);
            Assert.That(_website.PassportPage.GetMissingPictureErrorText, Is.EqualTo(errorText));
        }

        [AfterScenario]
        public void QuitDriver()
        {
            _website.Driver.Quit();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _website.Driver.Dispose();
        }
    }
}
