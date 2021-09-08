using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using CovidPassportSpecflowTesting.libs;

namespace CovidPassportSpecflowTesting.BDD
{
    [Binding]
    public class AddressFeatureSteps
    {         
        [Given(@"I am on the Addresses page")]
        public void GivenIAmOnTheAddressesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click details on the first item")]
        public void WhenIClickDetailsOnTheFirstItem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be brought to this URL ""(.*)""")]
        public void ThenIShouldBeBroughtToThisURL(string address)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
