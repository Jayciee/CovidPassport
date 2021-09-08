using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using CovidPassportBDDTest.libs;

namespace CovidPassportBDDTest.BDD
{
    [Binding]
    public class AddressFeatureSteps
    {
        private CovidPassport_Website<ChromeDriver> _website = new CovidPassport_Website<ChromeDriver>();

        [Given(@"I am on the Addresses page")]
        public void GivenIAmOnTheAddressesPage()
        {
            _website.AddressPage.GoToAddressPage();
        }
        
        [When(@"I click details on the first item")]
        public void WhenIClickDetailsOnTheFirstItem()
        {
            _website.AddressPage.ItemByPosition_Details(0);
        }
        
        [Then(@"I should be brought to this URL ""(.*)""")]
        public void ThenIShouldBeBroughtToThisURL(string address)
        {
            Assert.That(_website.Driver.Url, Is.EqualTo(address));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.Driver.Quit();
            _website.Driver.Dispose();
        }
    }
}
