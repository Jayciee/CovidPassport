using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPassportBDDTest.libs.pages
{
    class CovidPassport_AddressPage
    {
        public CovidPassport_AddressPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region Properties
        private IWebDriver Driver { get; }

        private string _url = AppConfigReader.AddressUrl;
        private IReadOnlyList<IWebElement> _tableItems => Driver.FindElements(By.XPath("/html/body/div/main/table/tbody/tr"));        
        private IWebElement _createNewAddress => Driver.FindElement(By.XPath("/html/body/div/main/p/a"));        
        private IWebElement _addressForm => Driver.FindElement(By.XPath("/html/body/div/main/div[1]"));

        #endregion


        // Currently Methods do not have a way to go to other pages
        #region Methods
        public void GoToAddressPage() => Driver.Navigate().GoToUrl(_url);
        public string ReturnUrl() => Driver.Url.ToString();
        public void CreateNewAddress() => _createNewAddress.Click();
        public int GetAddressCount() => _tableItems.Count();
        public string ItemByPosition_HouseNumber(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[1]")).Text;
        public string ItemByPosition_StreetName(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[2]")).Text;
        public string ItemByPosition_City(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[3]")).Text;
        public string ItemByPosition_PostCode(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[4]")).Text;
        public void ItemByPosition_Edit(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[5]/a[1]")).Click();
        public void ItemByPosition_Details(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[5]/a[2]")).Click();
        public void ItemByPosition_Delete(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[5]/a[3]")).Click();
        public void EnterAddressId(string id) => _addressForm.FindElement(By.XPath("//*[@id='Address_AddressId']")).SendKeys(id);
        public void EnterHouseNumber(string house_number) => _addressForm.FindElement(By.XPath("//*[@id='Address_HouseNumber']")).SendKeys(house_number);
        public void EnterStreetName(string street_name) => _addressForm.FindElement(By.XPath("//*[@id='Address_StreetName']")).SendKeys(street_name);
        public void EnterCityName(string city_name) => _addressForm.FindElement(By.XPath("//*[@id='Address_City']")).SendKeys(city_name);
        public void EnterPostcode(string postcode) => _addressForm.FindElement(By.XPath("//*[@id='Address_Postcode']")).SendKeys(postcode);
        public void EditHouseNumber(string house_number)
        {
            _addressForm.FindElement(By.XPath("//*[@id='Address_HouseNumber']")).SendKeys(Keys.Control + "a");
            _addressForm.FindElement(By.XPath("//*[@id='Address_HouseNumber']")).SendKeys(house_number);
        }
        public void EditStreetName(string street_name) 
        {
            _addressForm.FindElement(By.XPath("//*[@id='Address_StreetName']")).SendKeys(Keys.Control + "a");
            _addressForm.FindElement(By.XPath("//*[@id='Address_StreetName']")).SendKeys(street_name); 
        }
        public void EditCityName(string city_name)
        {
            _addressForm.FindElement(By.XPath("//*[@id='Address_City']")).SendKeys(Keys.Control + "a");
            _addressForm.FindElement(By.XPath("//*[@id='Address_City']")).SendKeys(city_name);
        }
        public void EditPostcode(string postcode)
        {
            _addressForm.FindElement(By.XPath("//*[@id='Address_Postcode']")).SendKeys(Keys.Control + "a");
            _addressForm.FindElement(By.XPath("//*[@id='Address_Postcode']")).SendKeys(postcode);
        }
        public void ClickCreate() => _addressForm.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[6]/input")).Click();
        public void ClickDelete() => Driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]")).Click();
        public void ClickSave() => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[5]/input")).Click();
        #endregion
    }
}
