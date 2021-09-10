using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPassportBDDTest.libs.pages
{
    public class CovidPassport_PassportPage
    {
        public CovidPassport_PassportPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region Properties
        public IWebDriver Driver { get; }
        private string _url => AppConfigReader.PassportUrl;

        private IReadOnlyList<IWebElement> _approvedPassportList => Driver.FindElements(By.XPath("/html/body/div/main/table/tbody/tr"));

        private IWebElement _editLink => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[6]/a[1]"));

        private IWebElement _saveButton => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[5]/input"));

        private IWebElement _backToListLinkEdit => Driver.FindElement(By.XPath("/html/body/div/main/div[2]/a"));

        private IWebElement _backToListLinkDetails => Driver.FindElement(By.XPath("/html/body/div/main/div[2]/a[2]"));

        private IWebElement _backToListLinkDelete => Driver.FindElement(By.XPath("/html/body/div/main/div/form/a"));

        private IWebElement _detailsLink => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[6]/a[2]"));

        private IWebElement _deleteLink => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[6]/a[3]"));

        private IWebElement _deleteButton => Driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]"));

        private IWebElement _nhsSitesLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[1]"));
        #endregion

        #region Methods
        public void VisitPassportPage() => Driver.Navigate().GoToUrl(_url);

        public bool EditLinkIsVisible() => _editLink.Displayed;

        public bool SaveButtonIsVisible() => _saveButton.Displayed;

        public string EditLinkText() => _editLink.Text;

        public string SaveButtonText() => _saveButton.Text;

        public void ClickEdit() => _editLink.Click();

        public void ClickSave() => _saveButton.Click();

        public void ClickBackToListEdit() => _backToListLinkEdit.Click();

        public void ClickBackToListDetails() => _backToListLinkDetails.Click();

        public void ClickBackToListDelete() => _backToListLinkDelete.Click();

        public void ClickDetailsButton() => _detailsLink.Click();

        public void ClickDeleteLink() => _deleteLink.Click();

        public void ClickDeleteButton() => _deleteButton.Click();

        public void ClickNHSSitesButton() => _nhsSitesLink.Click();

        public int ApprovedPassportListCount() => _approvedPassportList.Count();

        public void GetApprovedPassportListItems(int pos) => _approvedPassportList[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos+1}]"));
        #endregion
    }
}
