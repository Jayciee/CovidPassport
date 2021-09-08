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

        [When(@"I click the create location button")]
        public void WhenIClickTheCreateLocationButton()
        {
            _website.LocationPage.ClickAddCentre();
        }

        [Then(@"I should be redirected to location URL ""(.*)""")]
        public void ThenIShouldBeRedirectedToLocationURL(string address)
        {
            Assert.That(_website.LocationPage.ReturnUrl(), Does.Contain(address));
        }

        [When(@"I click the edit location button")]
        public void WhenIClickTheEditLocationButton()
        {
            _website.LocationPage.ClickLocationOption(1, 1);
        }

        [When(@"I click the detail location button")]
        public void WhenIClickTheDetailLocationButton()
        {
            _website.LocationPage.ClickLocationOption(1, 2);
        }

        [When(@"I click the home button from locations")]
        public void WhenIClickTheHomeButtonFromLocations()
        {
            _website.LocationPage.ClickHome();
        }
        [When(@"I click the option from the Health Centre Dropdown: ""(.*)""")]
        public void WhenIClickTheOptionFromTheHealthCentreDropdown(int option)
        {
            _website.LocationPage.HoverHealthOption();
            _website.LocationPage.ClickHealthCentreOption(option);
        }

        [When(@"I click the option from the Users Dropdown: ""(.*)""")]
        public void WhenIClickTheOptionFromTheUsersDropdown(int option)
        {
            _website.LocationPage.HoverUserOption();
            _website.LocationPage.ClickUsersOption(option);
        }
        [When(@"I click the privacy button from locations")]
        public void WhenIClickThePrivacyButtonFromLocations()
        {
            _website.LocationPage.ClickPrivacy();
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.Driver.Quit();
            _website.Driver.Dispose();
        }
    }
}
