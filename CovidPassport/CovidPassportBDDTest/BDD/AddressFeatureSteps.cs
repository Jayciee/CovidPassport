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
        private int countBefore, countAfter;

        [Given(@"I am on the Addresses page")]
        public void GivenIAmOnTheAddressesPage()
        {
            _website.AddressPage.GoToAddressPage();
        }

        [When(@"I click details on the first address")]
        public void WhenIClickDetailsOnTheFirstAddress()
        {
            _website.AddressPage.ItemByPosition_Details(0);
        }


        [When(@"I click edit on the first address")]
        public void WhenIClickEditOnTheFirstAddress()
        {
            _website.AddressPage.ItemByPosition_Edit(0);
        }

        [Then(@"I should see addresses on the screen")]
        public void ThenIShouldSeeAddressesOnTheScreen()
        {
            Assert.That(_website.AddressPage.GetAddressCount(), Is.Not.Null);
        }      

        [Then(@"I should be redirected to address URL ""(.*)""")]
        public void ThenIShouldBeRedirectedToAddressURL(string address)
        {
            Assert.That(_website.AddressPage.ReturnUrl(), Is.EqualTo(address));
        }

        [When(@"I click the create new address hyperlink")]
        public void WhenIClickTheCreateNewAddressHyperlink()
        {
            _website.AddressPage.CreateNewAddress();
        }

        [When(@"I am redirected to address URL ""(.*)""")]
        public void WhenIAmRedirectedToAddressURL(string address)
        {
            Assert.That(_website.AddressPage.ReturnUrl(), Is.EqualTo(address));
        }

        [When(@"I enter the details (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIEnterTheDetails(string id, string house_number, string street_name, string city, string postcode)
        {
            _website.AddressPage.EnterAddressId(id);
            _website.AddressPage.EnterHouseNumber(house_number);
            _website.AddressPage.EnterStreetName(street_name);
            _website.AddressPage.EnterCityName(city);
            _website.AddressPage.EnterPostcode(postcode);
        }

        [When(@"I click the create button on the create address page")]
        public void WhenIClickTheCreateButtonOnTheCreateAddressPage()
        {
            _website.AddressPage.ClickCreate();
        }

        [When(@"I click delete address on my created item")]
        public void WhenIClickDeleteAddressOnMyCreatedItem()
        {
            countBefore = _website.AddressPage.GetAddressCount();
            _website.AddressPage.ItemByPosition_Delete(_website.AddressPage.GetAddressCount() - 1);
        }

        [When(@"I click the delete button again on the address deletion confirmation page")]
        public void WhenIClickTheDeleteButtonAgainOnTheAddressDeletionConfirmationPage()
        {
            _website.AddressPage.ClickDelete();            
        }

        [Then(@"The address should be removed")]
        public void ThenTheAddressShouldBeRemoved()
        {
            countAfter = _website.AddressPage.GetAddressCount();
            Assert.That(countAfter, Is.EqualTo(countBefore - 1));
        }


        [Then(@"I should be redirected back to the address page")]
        public void ThenIShouldBeRedirectedBackToTheAddressPage()
        {
            Assert.That(_website.AddressPage.ReturnUrl(), Is.EqualTo("https://localhost:44312/Addresses"));
        }         

        [Then(@"My created user should appear with id (.*)")]
        public void ThenMyCreatedUserShouldAppearWithId(string id)
        {
            _website.AddressPage.ItemByPosition_Details(_website.AddressPage.GetAddressCount()-1);
            Assert.That(_website.AddressPage.ReturnUrl(), Is.EqualTo($"https://localhost:44312/Addresses/Details?id={id}"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.Driver.Quit();
            _website.Driver.Dispose();
        }
    }
}
