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

        private IWebElement _nhsAppLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[2]"));

        private IWebElement _aboutUsLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[3]"));

        private IWebElement _contactUsLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[4]"));

        private IWebElement _siteMap => Driver.FindElement(By.XPath("/html/body/footer/div/a[5]"));

        private IWebElement _accessibilityStatementLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[6]"));

        private IWebElement _policyLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[7]"));

        private IWebElement _cookiesLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[8]"));

        private IWebElement _privacyLink => Driver.FindElement(By.XPath("/html/body/footer/div/a[9]"));

        private IWebElement _missingPictureErrorText => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[3]/span"));

        private IWebElement _pictureEditBox => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[3]/input"));

        private IWebElement _expirationDateEditBox => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[4]/input"));

        private IWebElement _expirationDateErrorText => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[4]/span"));
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

        public IWebElement GetNHSSitesLinkURL() => _nhsSitesLink;

        public void ClickNHSAppButton() => _nhsAppLink.Click();

        public IWebElement GetNHSAppLinkURL() => _nhsAppLink;

        public void ClickAboutUsButton() => _aboutUsLink.Click();

        public IWebElement GetAboutUsLinkURL() => _aboutUsLink;

        public void ClickContactUsButton() => _contactUsLink.Click();

        public IWebElement GetContactUsLinkURL() => _contactUsLink;

        public void ClickSiteMapButton() => _siteMap.Click();

        public IWebElement GetSiteMapLinkURL() => _siteMap;

        public void ClickAccessibilityStatementButton() => _accessibilityStatementLink.Click();

        public IWebElement GetAccessibilityStatementLinkURL() => _accessibilityStatementLink;

        public void ClickPolicyButton() => _policyLink.Click();

        public IWebElement GetPolicyLinkURL() => _policyLink;

        public void ClickPrivacyButton() => _privacyLink.Click();

        public IWebElement GetPrivacyLinkURL() => _privacyLink;

        public void ClickCookieButton() => _cookiesLink.Click();

        public IWebElement GetCookiesLinkURL() => _cookiesLink;

        public int ApprovedPassportListCount() => _approvedPassportList.Count();

        public void GetApprovedPassportListItems(int pos) => _approvedPassportList[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos+1}]"));

        public string GetMissingPictureErrorText() => _missingPictureErrorText.Text;

        public bool GetPictureMissingErrorIsDisplayed() => _missingPictureErrorText.Displayed;

        public string GetPictureEditBoxText() => _pictureEditBox.Text;

        public void ClearPicture() => _pictureEditBox.Clear();

        public string GetExpirationDateEditBoxText() => _expirationDateEditBox.Text;

        public void ClearExpriationDate() => _expirationDateEditBox.Clear();

        public string GetExpirationDateErrorText() => _expirationDateErrorText.Text;

        public bool GetExpirationDateErrorIsDisplayed() => _expirationDateErrorText.Displayed;

        public void VisitSite(string url) => Driver.Navigate().GoToUrl(url);

        public string GetURLFromLink(IWebElement link) => link.GetAttribute("href");
        #endregion
    }
}
