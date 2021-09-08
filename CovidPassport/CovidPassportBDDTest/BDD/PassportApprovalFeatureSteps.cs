using CovidPassportBDDTest.libs;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace CovidPassportBDDTest.BDD
{
    [Binding]
    public class PassportApprovalFeatureSteps
    {
        private CovidPassport_Website<ChromeDriver> _website = new CovidPassport_Website<ChromeDriver>();
        [Given(@"I am on the Passport Approval Page")]
        public void GivenIAmOnTheHomePage()
        {
            _website.PassportApprovalPage.VisitPassportApprovalPage();
        }
        
        [When(@"I click on Passport Approval button")]
        public void WhenIClickOnPassportApprovalButton()
        {
            _website.PassportApprovalPage.ClickApprovalLink();
        }

        [Then(@"I should be directed to a approval confirmation page URL ""(.*)""")]
        public void ThenIShouldBeDirectedToAApprovalConfirmationPageURL(string URL)
        {
            Assert.That(_website.Driver.Url, Does.Contain(URL));
        }

        [Then(@"on clicking the confirm approve redirectes user to the approve URL ""(.*)""")]
        public void ThenOnClickingTheConfirmApproveRedirectesUserToTheApproveURL(string URL)
        {
            _website.PassportApprovalPage.ClickConfirmationPassportApprovalLink();
            Assert.That(_website.Driver.Url, Does.Contain(URL));
        }

        [AfterScenario]
        public void CleanUp()
        {
            _website.Driver.Quit();
            _website.Driver.Dispose();
        }
    }
}
