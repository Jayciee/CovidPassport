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
            _website.PassportPage.ClickBackToListEdit();
            Assert.That(_website.Driver.Url, Is.EqualTo(URL));
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
