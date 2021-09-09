using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CovidPassportBDDTest.libs.pages
{
    public class CovidPassport_LocationPage
    {
        public CovidPassport_LocationPage(IWebDriver driver)
        {
            Driver = driver;
        }
        #region Properties
        public IWebDriver Driver { get; }
        public string _url = AppConfigReader.LocationUrl;
        #region mainpage
        private IWebElement _addCentre => Driver.FindElement(By.XPath("/html/body/div/main/p/a"));
        private IWebElement _homeBtn => Driver.FindElement(By.XPath("/html/body/header/nav/div/a[2]"));
        private IWebElement _healthCentreTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]"));
        private IWebElement _usersTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]"));
        private IWebElement _locationList => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody"));
        private IWebElement _privacyTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/a[3]"));
        #endregion
        #region create page
        private IWebElement _centreID => Driver.FindElement(By.Id("HealthCentre_HealthCentreId"));
        private IWebElement _address => Driver.FindElement(By.Id("HealthCentre_AddressId"));
        private IWebElement _centreName => Driver.FindElement(By.Id("HealthCentre_Name"));
        private IWebElement _createButton => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[4]/input"));
        private IWebElement _errorIDMessage => Driver.FindElement(By.Id("HealthCentre_HealthCentreId-error"));
        private IWebElement _errorNameMessage => Driver.FindElement(By.Id("HealthCentre_Name-error"));
        #endregion
        #region edit page
        private IWebElement _addressDropdown => Driver.FindElement(By.Id("HealthCentre_AddressId"));
        private IWebElement _saveEditChanges => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[3]/input"));
        private IWebElement _healthCentreName => Driver.FindElement(By.Id("HealthCentre_Name"));
        #endregion
        #region delete page
        private IWebElement _deleteConfirm => Driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]"));
        #endregion
        #endregion
        #region Methods
        public void HoverHealthOption()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_healthCentreTab).Build().Perform();
        }
        public void HoverUserOption()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_usersTab).Build().Perform();
        }
        public void VisitLocationPage() => Driver.Navigate().GoToUrl(_url);
        public void VisitCreateLocationPage() => Driver.Navigate().GoToUrl("https://localhost:44312/HealthCentres/Create");
        public string ReturnUrl() => Driver.Url.ToString();
        public void ClickAddCentre() => _addCentre.Click();
        public void ClickHome() => _homeBtn.Click();
        public void ClickPrivacy() => _privacyTab.Click();
        public void ClickHealthCentreOption(int option) => Driver.FindElement(By.XPath($"/html/body/header/nav/div/div[1]/div/a[{option}]")).Click();
        public void ClickUsersOption(int option) => _usersTab.FindElement(By.XPath($"/html/body/header/nav/div/div[2]/div/a[{option}]")).Click();
        public string FindLocation(int row, int data) => _locationList.FindElement(By.XPath($"//tr[{row}]/td[{data}]")).Text;
        public void ClickLocationOption(int row,int option) => _locationList.FindElement(By.XPath($"//tr[{row}]/td[3]/a[{option}]")).Click();
        #region create page methods
        public void InputCentreId()
        {
            Random rnd = new Random();
            _centreID.SendKeys(rnd.Next(10, 100000000).ToString());
        }
        public void InputExistingId() => _centreID.SendKeys("1");
        public void InputTextId(string text) => _centreID.SendKeys(text);
        public string GetIDField() => _centreID.Text;
        public void SelectAddress(string option)
        {
            var addressLists =_address.FindElements(By.TagName("option"));
            foreach (var address in addressLists)
            {
                if (address.GetAttribute("value") == option)
                {
                    address.Click();
                    break;
                }
            }
        }
        public string RetrieveIDError() => _errorIDMessage.Text;
        public string RetrieveNameError() => _errorNameMessage.Text;
        public void DeleteLastCentre()
        {
            var count = _locationList.FindElements(By.TagName("tr")).ToList().Count;
            Driver.FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{count}]/td[3]/a[3]")).Click();
        }
        public string LastCentreName()
        {
            var count = _locationList.FindElements(By.TagName("tr")).ToList().Count;
            return Driver.FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{count}]/td[1]")).ToString();
        }
        public void InputCentreName(string name) => _centreName.SendKeys(name);
        public void ClickCreate() => _createButton.Click();
        #endregion
        #region edit methods
        public void SelectAddressInEdit(string option)
        {
            var addressList = _addressDropdown.FindElements(By.TagName("option"));
            foreach (var address in addressList)
            {
                if (address.GetAttribute("value") == option)
                {
                    address.Click();
                    break;
                }
            }
        }
        public void EditCentreName(string name)
        {
            _healthCentreName.Clear();
            _healthCentreName.SendKeys(name);
        }
        public void ClickSaveEditChanges() => _saveEditChanges.Click();
        #endregion
        public void ClickConfirmDelete() => _deleteConfirm.Click();
        #endregion
    }
}
