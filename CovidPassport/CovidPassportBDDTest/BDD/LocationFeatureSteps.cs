using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using CovidPassportBDDTest.libs;
using System.Linq;

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

        [Given(@"I am on the create location page")]
        public void GivenIAmOnTheCreateLocationPage()
        {
            _website.LocationPage.VisitCreateLocationPage();
        }

        [When(@"I fill out the form with the options:")]
        public void WhenIFillOutTheFormWithTheOptions(Table table)
        {
            var address = table.Rows.Select(i => i["address"]).FirstOrDefault();
            var name = table.Rows.Select(i => i["name"]).FirstOrDefault();
            _website.LocationPage.InputCentreId();
            _website.LocationPage.SelectAddress(address);
            _website.LocationPage.InputCentreName(name);
        }

        [When(@"I press the create location button")]
        public void WhenIPressTheCreateLocationButton()
        {
            _website.LocationPage.ClickCreate();
        }

        [When(@"I delete the new location")]
        public void WhenIDeleteTheNewLocation()
        {
            _website.LocationPage.DeleteLastCentre();
        }

        [When(@"I confirm deletion")]
        public void WhenIConfirmDeletion()
        {
            _website.LocationPage.ClickConfirmDelete();
        }

        [Then(@"the last name on location list should not be ""(.*)""")]
        public void ThenTheLastNameOnLocationListShouldNotBe(string name)
        {
            Assert.False(_website.LocationPage.LastCentreName() == name);
        }

        [When(@"I fill out the ID with an existing location ID")]
        public void WhenIFillOutTheIDWithAnExistingLocationID()
        {
            _website.LocationPage.InputExistingId();
        }
        [When(@"I fill out the centre name with: ""(.*)""")]
        public void WhenIFillOutTheCentreNameWith(string name)
        {
            _website.LocationPage.InputCentreName(name);
        }

        [Then(@"id error message should be: ""(.*)""")]
        public void ThenIdErrorMessageShouldBe(string error)
        {
            Assert.That(_website.LocationPage.RetrieveIDError(), Does.Contain(error));
        }

        [Then(@"name error message should be: ""(.*)""")]
        public void ThenNameErrorMessageShouldBe(string error)
        {
            Assert.That(_website.LocationPage.RetrieveNameError(), Does.Contain(error));
        }

        [When(@"I fill out the ID with a: ""(.*)""")]
        public void WhenIFillOutTheIDWithA(string text)
        {
            _website.LocationPage.InputTextId(text);
        }

        [Then(@"ID field should be empty")]
        public void ThenIDFieldShouldBeEmpty()
        {
            Assert.That(_website.LocationPage.GetIDField, Is.EqualTo(""));
        }

        [AfterScenario]
        public void QuitWebDriver()
        {
            _website.Driver.Quit();            
        }

        [OneTimeTearDown]
        public void DisposeWebDriver()
        {
            _website.Driver.Dispose();
        }
    }
}
