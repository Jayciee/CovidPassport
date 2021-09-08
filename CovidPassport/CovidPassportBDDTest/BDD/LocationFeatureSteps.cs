using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using CovidPassportBDDTest.libs;

namespace CovidPassportBDDTest.BDD
{
    [Binding]
    public class LocationFeatureSteps
    {
        private CovidPassport_Website<ChromeDriver> _website = new CovidPassport_Website<ChromeDriver>();

        [Given(@"I am on the locations page")]
        public void GivenIAmOnTheLocationsPage()
        {
            _website.LocationPage.VisitLocationPage();
        }

        [When(@"I click the create button")]
        public void WhenIClickTheCreateButton()
        {
            _website.LocationPage.ClickAddCentre();
        }
 
        [Then(@"I should be redirected to location URL ""(.*)""")]
        public void ThenIShouldBeRedirectedToLocationURL(string address)
        {
            Assert.That(_website.LocationPage.ReturnUrl(), Does.Contain(address));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.Driver.Quit();
            _website.Driver.Dispose();
        }
    }
}
